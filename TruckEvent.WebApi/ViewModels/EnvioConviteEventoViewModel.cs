using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class EnvioConviteEventoViewModel
    {
        public string Email { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Id_usuario_organizador { get; set; }

        public Usuario Usuario_Organizador { get; set; }

        public Evento Evento { get; set; }

        public Guid? Id_Evento { get; set; }

        public string Token { get; set; }
    }
}