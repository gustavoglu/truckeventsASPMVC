using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            //this.Eventos = new List<Evento>();
        }

        [ScaffoldColumn(false)]
        public string Id { get; set; }
        public string Nome { get; set; } = null;
        public string Sobrenome { get; set; } = null;
        [DisplayName("Razão Social")]
        public string RazaoSocial { get; set; } = null;
        [DisplayName("Telefone Principal")]
        public string Telefone1 { get; set; } = null;
        [DisplayName("Telefone Opcional")]
        public string Telefone2 { get; set; } = null;
        public string Documento { get; set; } = null;
        public string Email { get; set; } = null;

        [ScaffoldColumn(false)]
        public bool? UserAdmin { get; set; }
        [ScaffoldColumn(false)]
        public bool? UserPrincipal { get; set; }
        [ScaffoldColumn(false)]
        public bool? Organizador { get; set; }

        [ScaffoldColumn(false)]

       // public virtual ICollection<Evento> Eventos { get; set; }
        public string Id_Usuario_Principal { get; set; } = null;

    }
}