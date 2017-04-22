using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

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

        //public virtual Evento Evento { get; set; } = null;

        public DateTime? CriadoEm { get; set; }

        public string CriadoPor { get; set; } = null;

        public DateTime? DeletadoEm { get; set; }

        public string DeletadoPor { get; set; } = null;

        public DateTime? AtualizadoEm { get; set; }

        public string AtualizadoPor { get; set; } = null;

        public bool? Deletado { get; set; }
    }
}