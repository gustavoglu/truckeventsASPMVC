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
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Controllers.Api
{
    [Authorize]
    public class EnvioConviteController : ApiController
    {
        private readonly SQLContext Db = new SQLContext();

        [HttpPost]
        public async Task<IHttpActionResult> PostEnvio(EnvioConviteViewModel envioConviteViewModel)
        {
            var eventoExist = Db.Eventos.ToList().Exists(e => e.Id == envioConviteViewModel.Id_Evento);
            var usuarioExist = Db.Users.ToList().Exists(u => u.UserName == envioConviteViewModel.Email);
            var claimPrincipal = (ClaimsPrincipal)Thread.CurrentPrincipal ;
            var exist = claimPrincipal.Claims.ToList().Exists(c => c.Type == "id_usuario");
            var id_usuarioLogado = claimPrincipal.Claims.SingleOrDefault(c => c.Type == "id_usuario").Value;
            var organizador = bool.Parse(claimPrincipal.Claims.SingleOrDefault(c => c.Type == "organizador").Value);


            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!eventoExist)
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
                    return BadRequest("Este Usuario já esta vinculado com Este Evento");
                }

            }


            string body = "<p>Email:{0}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(envioConviteViewModel.Email));
            message.From = (new MailAddress("gustavoglu@hotmail.com"));
            message.Body = string.Format(body, envioConviteViewModel.Email);
            message.IsBodyHtml = true;
            message.Subject = "Teste";

            using (var smtp = new SmtpClient())
            {
                var credenciais = new NetworkCredential()
                {
                    UserName = "gustavoglu@hotmail.com"
                    ,Password = "giroldinhufenix"
                };

                smtp.Credentials = credenciais;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);

                return Ok ("Enviado");

            }
        }
    }
}