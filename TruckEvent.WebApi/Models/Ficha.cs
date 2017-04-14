using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.Models
{
    public class Ficha : BaseEntity
    {
        public string Codigo { get; set; }

        public double Saldo { get; set; }

        public Guid Id_Evento { get; set; }

        public virtual Evento Evento { get; set; }
    }
}