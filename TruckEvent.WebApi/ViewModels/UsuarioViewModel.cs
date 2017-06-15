using Newtonsoft.Json;
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
            this.Eventos = new List<EventoViewModel>();
            this.Lojas = new List<UsuarioViewModel>();
            this.Eventos = new List<EventoViewModel>();
            this.Evento_Usuarios = new List<Evento_UsuarioViewModel>();
        }

        public string Id { get; set; }

        public string Nome { get; set; } = null;

        public string Sobrenome { get; set; } = null;

        public string RazaoSocial { get; set; } = null;

        public string Telefone1 { get; set; } = null;

        public string Telefone2 { get; set; } = null;

        public string Documento { get; set; } = null;

        public string Email { get; set; } = null;

        public bool? UserAdmin { get; set; }

        public bool? UserPrincipal { get; set; }

        public bool? Organizador { get; set; }

        public bool? CaixaEvento { get; set; }

        public string Id_Usuario_Principal { get; set; } = null;

        public virtual UsuarioViewModel Usuario_Principal { get; set; }

        public string id_usuario_organizador { get; set; }

        public virtual UsuarioViewModel Usuario_Organizador { get; set; }

        public virtual ICollection<UsuarioViewModel> Caixas { get; set; }

        public virtual ICollection<UsuarioViewModel> Lojas { get; set; }

        public virtual ICollection<EventoViewModel> Eventos { get; set; }

        public virtual ICollection<Evento_UsuarioViewModel> Evento_Usuarios { get; set; }


    }
}