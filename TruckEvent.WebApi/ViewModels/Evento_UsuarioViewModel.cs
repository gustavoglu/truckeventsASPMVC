using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.ViewModels
{
    public class Evento_UsuarioViewModel
    {

        public Evento_UsuarioViewModel()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid? Id { get; set; }

        public string Id_Usuario { get; set; } = null;

        public Guid? Id_Evento { get; set; }

        public bool? UsuarioConfirmado { get; set; }

        public virtual EventoViewModel Evento { get; set; } = null;
    }
}