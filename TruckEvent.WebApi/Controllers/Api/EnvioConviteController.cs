using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TruckEvent.WebApi.Infra;
using TruckEvent.WebApi.Infra.Repository.EntityRepository;
using TruckEvent.WebApi.Infra.Repository.EntityRepository.Interfaces;
using TruckEvent.WebApi.Migrations;
using TruckEvent.WebApi.Models;
using TruckEvent.WebApi.Services;
using TruckEvent.WebApi.Services.Interfaces;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Controllers.Api
{
    [System.Web.Http.Authorize]
    [System.Web.Http.RoutePrefix("api/EnvioConvite")]
    public class EnvioConviteController : ApiController
    {
        private readonly SQLContext Db = new SQLContext();

        private readonly ITokenEnvioRepository _tokenEnvioRepository = new TokenEnvioRepository();
        private readonly IEvento_UsuarioAppService _evento_UsuarioAppService = new Evento_UsuarioAppService();

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("ConviteEvento")]
        public async Task<IHttpActionResult> ConviteEventoEnvio(EnvioConviteEventoViewModel envioConviteViewModel)
        {
            // Cria Context Request do Controller da View enviada por Email
            var controller = Util.Utilidades.CreateController<ConviteController>();
            var context = controller.ControllerContext.RequestContext;
         
            var eventoConvite = Db.Eventos.ToList().SingleOrDefault(e => e.Id == envioConviteViewModel.Id_Evento);
            var usuarioExist = Db.Users.ToList().Exists(u => u.UserName == envioConviteViewModel.Email);
            var claimPrincipal = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var exist = claimPrincipal.Claims.ToList().Exists(c => c.Type == "id_usuario");
            var id_usuarioLogado = claimPrincipal.Claims.SingleOrDefault(c => c.Type == "id_usuario").Value;
            var organizador = bool.Parse(claimPrincipal.Claims.SingleOrDefault(c => c.Type == "organizador").Value);
            var usuarioLogado = Db.Users.ToList().SingleOrDefault(u => u.Id == id_usuarioLogado);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (eventoConvite == null)
            {
                return BadRequest("Este Evento não existe.");
            }

            if (!organizador)
            {
                return BadRequest("É Necessário ser um Organizador para Enviar um Convite");
            }

            if (usuarioExist)
            {
              
                //Verifica se usuario ja esta vinculado com evento
                var eventoUsuarioExist = (from eventoUsuario in Db.Evento_Usuarios
                                          join evento in Db.Eventos on eventoUsuario.Id_Evento equals evento.Id
                                          where eventoUsuario.Id_Usuario == id_usuarioLogado
                                          && eventoUsuario.Id_Evento == envioConviteViewModel.Id_Evento
                                          && eventoUsuario.Deletado == false
                                          && evento.Deletado == false
                                          select eventoUsuario).SingleOrDefault();

                if (eventoUsuarioExist != null)
                {
                    return BadRequest("Este Usuario já esta vinculado com este Evento");
                }
           
            }


            var dataExpira = DateTime.Now + TimeSpan.FromDays(7); // Expira em 7 Dias

            TokenEnvio token = new TokenEnvio()
            {
                Token = Guid.NewGuid().ToString(),
                ExpiraEm = dataExpira,
                Ativo = true
            };

            var tokenCriado = _tokenEnvioRepository.Criar(token);

            envioConviteViewModel.Id_Evento = eventoConvite.Id;
            envioConviteViewModel.Id_usuario_organizador = usuarioLogado.Id;
            envioConviteViewModel.Usuario_Organizador = usuarioLogado;
            envioConviteViewModel.Evento = eventoConvite;
            envioConviteViewModel.Token = tokenCriado.Token;

            var viewString = Util.Utilidades.RenderViewToString(new ControllerContext(context, controller), "ConviteUsuarioPrincipal", envioConviteViewModel);

            var message = new MailMessage();
            message.To.Add(new MailAddress(envioConviteViewModel.Email));
            message.From = (new MailAddress("truckeventsenvio@gmail.com"));
            message.Body = string.Format(viewString, envioConviteViewModel.Email);
            message.IsBodyHtml = true;
            message.Subject = "Convite para Particiar de Evento";

            using (var smtp = new SmtpClient())
            {
                var credenciais = new NetworkCredential()
                {
                    UserName = "truckeventsenvio@gmail.com",
                    Password = "@dmin123"
                };

                smtp.Credentials = credenciais;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);

                return Ok("Convite Enviado");

            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("ConviteFuncionario")]
        public async Task<IHttpActionResult> ConviteFuncionarioEnvio(EnvioConviteFuncionarioViewModel envioConviteFuncionarioViewModel)
        {

            // Cria Context Request do Controller da View enviada por Email
            var controller = Util.Utilidades.CreateController<ConviteController>();
            var context = controller.ControllerContext.RequestContext;

            var usuarioExist = Db.Users.ToList().Exists(u => u.UserName == envioConviteFuncionarioViewModel.Email);
            var claimPrincipal = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var id_usuarioLogado = claimPrincipal.Claims.SingleOrDefault(c => c.Type == "id_usuario").Value;
            var usuarioPrincipal = bool.Parse(claimPrincipal.Claims.SingleOrDefault(c => c.Type == "usuarioprincipal").Value);
            var usuarioLogado = Db.Users.SingleOrDefault(u => u.Id == id_usuarioLogado);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!usuarioPrincipal)
            {
                return BadRequest("É Necessário ser um Usuario Principal para Enviar um Convite");
            }

            if (usuarioExist)
            {
                //Verifica se usuario ja esta vinculado com o usuario Principal
                var id_usuarioPrincipal =
                    (from usuario in Db.Users
                     where usuario.UserName == envioConviteFuncionarioViewModel.Email
                     select usuario.Id_Usuario_Principal).SingleOrDefault();

                if (id_usuarioPrincipal == id_usuarioLogado)
                {
                    BadRequest("Este Usuario já esta Vinculado a seu grupo de Funcionários");
                }

                if (id_usuarioPrincipal != null && id_usuarioPrincipal != id_usuarioLogado )
                {
                    BadRequest("Este Usuario esta Vinculado a Outro Usuario Principal");
                }

            }

            var dataExpira = DateTime.Now + TimeSpan.FromDays(7); // Expira em 7 Dias

            TokenEnvio token = new TokenEnvio()
            {
                Token = Guid.NewGuid().ToString(),
                ExpiraEm = dataExpira,
                Ativo = true

            };

            var tokenCriado = _tokenEnvioRepository.Criar(token);

            envioConviteFuncionarioViewModel.Id_usuario_principal = id_usuarioLogado;
            envioConviteFuncionarioViewModel.Usuario_Principal = usuarioLogado;
            envioConviteFuncionarioViewModel.Token = tokenCriado.Token;

            var viewString = Util.Utilidades.RenderViewToString(new ControllerContext(context, controller), "ConviteFuncionario", envioConviteFuncionarioViewModel);

            var message = new MailMessage();
            message.To.Add(new MailAddress(envioConviteFuncionarioViewModel.Email));
            message.From = (new MailAddress("truckeventsenvio@hotmail.com"));
            message.Body = string.Format(viewString, envioConviteFuncionarioViewModel.Email);
            message.IsBodyHtml = true;
            message.Subject = "Convite para Grupo de Funcionários";

            using (var smtp = new SmtpClient())
            {
                var credenciais = new NetworkCredential()
                {
                    UserName = "truckeventsenvio@gmail.com"
                    ,Password = "@dmin123"
                };

                smtp.Credentials = credenciais;
                smtp.Host = "smtp-relay.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);

                return Ok("Convite Enviado");

            }
        }
    }


}