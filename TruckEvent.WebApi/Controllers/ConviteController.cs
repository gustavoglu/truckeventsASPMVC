using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruckEvent.WebApi.Models;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Controllers
{
    public class ConviteController : Controller
    {
        public ActionResult ConviteUsuarioPrincipal()
        {
            Usuario usuario = new Usuario() { RazaoSocial = "Teste razao social" };
            Evento evento = new Evento() { Descricao = "Evento Teste" };
            EnvioConviteEventoViewModel envioconviteViewModel = new EnvioConviteEventoViewModel() { Email = "teste@email.com", Usuario_Organizador = usuario, Evento = evento };

            var viewString = Util.Utilidades.RenderViewToString(new ControllerContext(HttpContext.Request.RequestContext,this), "ConviteUsuarioPrincipal", envioconviteViewModel);


            return View(envioconviteViewModel);
        }
    }
}