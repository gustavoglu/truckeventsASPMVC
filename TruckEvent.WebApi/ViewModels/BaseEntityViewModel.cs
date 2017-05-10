using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.ViewModels
{
    public class BaseEntityViewModel
    {
        public BaseEntityViewModel()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid? Id { get; set; }

        public DateTime? CriadoEm { get; set; }

        public string CriadoPor { get; set; } = null;

        public DateTime? DeletadoEm { get; set; }

        public string DeletadoPor { get; set; } = null;

        public DateTime? AtualizadoEm { get; set; }

        public string AtualizadoPor { get; set; } = null;

        public bool? Deletado { get; set; }
    }
}