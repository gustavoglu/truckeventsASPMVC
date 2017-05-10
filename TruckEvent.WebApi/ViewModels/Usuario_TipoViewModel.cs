using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class Usuario_TipoViewModel : BaseEntityViewModel
    {
        public Usuario_TipoViewModel() : base()
        {
            this.Usuarios = new List<UsuarioViewModel>();
        }

        public string Descricao { get; set; } = null;

        public bool? UserAdmin { get; set; }

        public bool? UserPrincipal { get; set; }

        public bool? Organizador { get; set; }

        public virtual ICollection<UsuarioViewModel> Usuarios { get; set; }

      
    }
}