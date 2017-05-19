using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.Models
{
    public class Ficha : BaseEntity
    {
        public string Codigo { get; set; } = null;

        public string NomeCliente { get; set; } = null;

        public string CelularCliente { get; set; } = null;

        public bool? EnviarSMSConfirmacao{ get; set; }

        public int? Senha { get; set; }

        public double? Saldo { get; set; }

        public Guid? Id_Evento { get; set; }

        public virtual Evento Evento { get; set; } = null;

        public virtual ICollection<Ficha_Produto> Ficha_Produtos { get; set; }

        public virtual ICollection<Venda_Pagamento_Ficha> Venda_Pagamento_Fichas { get; set; }

        public virtual ICollection<Movimentacao> Movimentacoes { get; set; }
    }
}