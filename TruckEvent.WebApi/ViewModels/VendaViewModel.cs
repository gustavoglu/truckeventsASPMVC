using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.ViewModels
{
    public class VendaViewModel
    {

        public VendaViewModel()
        {
            this.Id = Guid.NewGuid();
            this.Venda_Pagamentos = new List<Venda_Pagamento>();
            this.Venda_Produtos = new List<Venda_Produto>();
        }
        public Guid? Id { get; set; }

        public DateTime? Data { get; set; }

        public double? TotalVenda { get; set; }

        public double? Troco { get; set; }

        public string NomeCliente { get; set; } = null;

        public bool? Cancelada { get; set; }

        public Guid? Id_evento { get; set; }

        public virtual Evento Evento { get; set; } = null;

        public virtual ICollection<Venda_Pagamento> Venda_Pagamentos { get; set; }

        public virtual ICollection<Venda_Produto> Venda_Produtos { get; set; }

        public DateTime? CriadoEm { get; set; }

        public string CriadoPor { get; set; } = null;

        public DateTime? DeletadoEm { get; set; }

        public string DeletadoPor { get; set; } = null;

        public DateTime? AtualizadoEm { get; set; }

        public string AtualizadoPor { get; set; } = null;

        public bool? Deletado { get; set; }

    }
}