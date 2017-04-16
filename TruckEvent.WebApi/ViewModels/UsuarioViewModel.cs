using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            this.Eventos = new List<EventoViewModel>();
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

        public Guid Id_usuario_tipo { get; set; }
        public virtual Usuario_TipoViewModel Usuario_Tipo { get; set; }

        public virtual ICollection<EventoViewModel> Eventos { get; set; }
        public string Id_Usuario_Principal { get; set; } = null;
    }
}