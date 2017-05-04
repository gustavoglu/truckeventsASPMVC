using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.Models
{
    public class Usuario_Tipo : BaseEntity
    {
        public string Descricao { get; set; } = null;

        public bool? UserAdmin { get; set; }

        public bool? UserPrincipal { get; set; }

        public bool? Organizador { get; set; }


        public virtual ICollection<Usuario> Usuarios { get; set; }

    
    }
}