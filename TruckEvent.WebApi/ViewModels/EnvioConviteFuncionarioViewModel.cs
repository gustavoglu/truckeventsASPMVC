using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class EnvioConviteFuncionarioViewModel
    {
        public string Email { get; set; }

        public string Id_usuario_principal { get; set; }

        public Usuario Usuario_Principal { get; set; }

        public string Token { get; set; }

    }
}