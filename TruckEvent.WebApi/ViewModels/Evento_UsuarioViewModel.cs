using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class Evento_UsuarioViewModel : BaseEntityViewModel
    {
         
        public Evento_UsuarioViewModel() : base()
        {
            
        }

        public string Id_Usuario { get; set; } = null;

        public Guid? Id_Evento { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }

        public virtual EventoViewModel Evento { get; set; } = null;

        public bool? UsuarioConfirmado { get; set; }

    }
}