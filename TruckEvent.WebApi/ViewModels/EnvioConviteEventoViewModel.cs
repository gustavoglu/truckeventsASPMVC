using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.ViewModels
{
    public class EnvioConviteEventoViewModel
    {
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public string Id_usuario_organizador { get; set; }

        [ScaffoldColumn(false)]
        public Guid Id_Evento { get; set; }
    }
}