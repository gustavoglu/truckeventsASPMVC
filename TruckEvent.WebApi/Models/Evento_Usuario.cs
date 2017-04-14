using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.Models
{
    public class Evento_Usuario : BaseEntity
    {
        public string Id_Usuario { get; set; }

        public Guid Id_Evento { get; set; }

        public bool UsuarioConfirmado { get; set; }

        public virtual Evento Evento { get; set; }
    }
}