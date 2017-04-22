using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            this.Eventos = new List<Evento>();
        }


        public string Id { get; set; }
        public string Nome { get; set; } = null;
        public string Sobrenome { get; set; } = null;
        public string RazaoSocial { get; set; } = null;
        public string Telefone1 { get; set; } = null;
        public string Telefone2 { get; set; } = null;
        public string Documento { get; set; } = null;
        public string Email { get; set; } = null;
        public DateTime? DataNascimento { get; set; }
        public bool? UserAdmin { get; set; }
        public bool? UserPrincipal { get; set; }
        public bool? Organizador { get; set; }

        public Guid? Id_usuario_tipo { get; set; }
        public virtual Usuario_Tipo Usuario_Tipo { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
        public string Id_Usuario_Principal { get; set; } = null;
    }
}