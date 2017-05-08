using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class Venda_Pagamento_FichaViewModel
    {
        public Venda_Pagamento_FichaViewModel()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid? Id { get; set; }

        public Guid? Id_Ficha { get; set; }

        public Guid? Id_Venda_Pagamento { get; set; }

        public virtual Venda_Pagamento Venda_Pagamento { get; set; }

        public virtual Ficha Ficha { get; set; }

        public DateTime? CriadoEm { get; set; }

        public string CriadoPor { get; set; } = null;

        public DateTime? DeletadoEm { get; set; }

        public string DeletadoPor { get; set; } = null;

        public DateTime? AtualizadoEm { get; set; }

        public string AtualizadoPor { get; set; } = null;

        public bool? Deletado { get; set; }

    }
}