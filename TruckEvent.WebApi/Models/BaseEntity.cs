using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public DateTime CriadoEm{ get; set; }

        public string CriadoPor { get; set; }

        public DateTime DeletadoEm { get; set; }

        public string DeletadoPor { get; set; }

        public DateTime AtualizadoEm { get; set; }

        public string AtualizadoPor { get; set; }

        public bool Deletado { get; set; }
    }
}