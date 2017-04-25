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
using TruckEvent.WebApi.Infra;
using TruckEvent.WebApi.Infra.Repository.EntityRepository.Interfaces;
using TruckEvent.WebApi.Migrations;
using TruckEvent.WebApi.Models;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/EnvioConvite")]
    public class EnvioConviteController : ApiController
    {
        private readonly SQLContext Db = new SQLContext();

        private readonly ITokenEnvioRepository _tokenEnvioRepository = new TokenEnvioRepository();

        [HttpPost]
        [Route("ConviteEvento")]
        public async Task<IHttpActionResult> ConviteEventoEnvio(EnvioConviteEventoViewModel envioConviteViewModel)
        {
            var eventoExist = Db.Eventos.ToList().Exists(e => e.Id == envioConviteViewModel.Id_Evento);
            var usuarioExist = Db.Users.ToList().Exists(u => u.UserName == envioConviteViewModel.Email);
            var claimPrincipal = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var exist = claimPrincipal.Claims.ToList().Exists(c => c.Type == "id_usuario");
            var id_usuarioLogado = claimPrincipal.Claims.SingleOrDefault(c => c.Type == "id_usuario").Value;
            var organizador = bool.Parse(claimPrincipal.Claims.SingleOrDefault(c => c.Type == "organizador").Value);


            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //if (!eventoExist)
            //{
            //    return BadRequest("Este Evento não existe.");
            //}

            //if (!organizador)
            //{
            //    return BadRequest("É Necessário ser um Organizador para Enviar um Convite");
            //}

            //if (usuarioExist)
            //{
            //    //Verifica se usuario ja esta vinculado com evento
            //    var eventoUsuarioExist = (from eventoUsuario in Db.Evento_Usuarios
            //                              join evento in Db.Eventos on eventoUsuario.Id_Evento equals evento.Id
            //                              where eventoUsuario.Id_Usuario == id_usuarioLogado
            //                              && eventoUsuario.Id_Evento == envioConviteViewModel.Id_Evento
            //                              && eventoUsuario.Deletado == false
            //                              && evento.Deletado == false
            //                              select eventoUsuario).SingleOrDefault();

            //    if (eventoUsuarioExist != null)
            //    {
            //        return BadRequest("Este Usuario já esta vinculado com este Evento");
            //    }

            //}
         
            var dataExpira = DateTime.Now + TimeSpan.FromDays(7); // Expira em 7 Dias

            TokenEnvio token = new TokenEnvio()
            {
                Token = Guid.NewGuid().ToString()
                ,
                ExpiraEm = dataExpira 
                ,
                Ativo = true

            };

            var tokenCriado = _tokenEnvioRepository.Criar(token);

            string body = "Email Enviado para {0}";
            var message = new MailMessage();
            message.To.Add(new MailAddress(envioConviteViewModel.Email));
            message.From = (new MailAddress("truckeventsenvio@gmail.com"));
            message.Body = string.Format(body, envioConviteViewModel.Email);
            message.IsBodyHtml = true;
            message.Subject = "Teste";

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

                return Ok("Enviado");

            }
        }
        [HttpPost]
        [Route("ConviteFuncionario")]
        public async Task<IHttpActionResult> ConviteFuncionarioEnvio(EnvioConviteFuncionarioViewModel envioConviteFuncionarioViewModel)
        {

            var usuarioExist = Db.Users.ToList().Exists(u => u.UserName == envioConviteFuncionarioViewModel.Email);
            var claimPrincipal = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var id_usuarioLogado = claimPrincipal.Claims.SingleOrDefault(c => c.Type == "id_usuario").Value;
            var usuarioPrincipal = bool.Parse(claimPrincipal.Claims.SingleOrDefault(c => c.Type == "usuarioprincipal").Value);


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
                    BadRequest("Este Usuario já Vinculado a Você");
                }

                if (id_usuarioPrincipal != null && id_usuarioPrincipal != id_usuarioLogado )
                {
                    BadRequest("Este Usuario esta Vinculado a Outro Usuario Principal");
                }

            }

            var dataExpira = DateTime.Now + TimeSpan.FromDays(7); // Expira em 7 Dias

            //TokenEnvio token = new TokenEnvio()
            //{
            //    Token = Guid.NewGuid().ToString()
            //    ,ExpiraEm = dataExpira
            //    ,Ativo = true

            //};

            //var tokenCriado = _tokenEnvioRepository.Criar(token);

            string body = "Email Enviado para {0}";
            var message = new MailMessage();
            message.To.Add(new MailAddress(envioConviteFuncionarioViewModel.Email));
            message.From = (new MailAddress("truckeventsenvio@hotmail.com"));
            message.Body = string.Format(body, envioConviteFuncionarioViewModel.Email);
            message.IsBodyHtml = true;
            message.Subject = "Teste";

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

                return Ok("Enviado");

            }
        }
    }


}