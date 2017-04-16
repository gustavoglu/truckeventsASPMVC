using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.ViewModels
{
    public class Usuario_TipoViewModel
    {
        public Usuario_TipoViewModel()
        {
            this.Id = Guid.NewGuid();
            this.Usuarios = new List<UsuarioViewModel>();
        }

        public Guid? Id { get; set; }

        public string Descricao { get; set; } = null;

        public bool? UserAdmin { get; set; }

        public bool? UserPrincipal { get; set; }

        public bool? Organizador { get; set; }

        public virtual ICollection<UsuarioViewModel> Usuarios { get; set; }
    }
}