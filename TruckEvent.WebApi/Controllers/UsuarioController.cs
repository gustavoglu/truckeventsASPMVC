using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruckEvent.WebApi.Infra;
using TruckEvent.WebApi.Services;
using TruckEvent.WebApi.Services.Interfaces;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Controllers
{
    public class UsuarioController : Controller
    {

        private SQLContext Db = new SQLContext();
        private IEvento_UsuarioAppService _evento_UsuarioAppService = new Evento_UsuarioAppService();

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
             return View();
        }
        [Route("Usuario/{id}/{token}")]
        public ActionResult CadastroConviteEvento(string id,string token,string email)
        {
            var tokenConvite = Db.TokenEnvios.ToList().SingleOrDefault(t => t.Token == token);
            var eventoConvite = Db.Eventos.ToList().SingleOrDefault(e => e.Id == Guid.Parse(id));
            var usuarioConvite = Db.Users.ToList().SingleOrDefault(u => u.UserName == email);
            
            if (DateTime.Now > tokenConvite.ExpiraEm || tokenConvite == null || eventoConvite == null)
            {
                return HttpNotFound();
            }

            if (usuarioConvite != null)
            {
                var eventoUsuario = new Evento_UsuarioViewModel()
                {
                    Id_Evento = Guid.Parse(id),
                    Id_Usuario = usuarioConvite.Id
                };

                _evento_UsuarioAppService.Criar(eventoUsuario);

                return View("Index", "Home");
            }

            return View();

        }

    }
}