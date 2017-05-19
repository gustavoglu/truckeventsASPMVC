using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.ViewModels
{
    public enum Tipo_Mov { Entrada, Saida, Estorno };

    public class MovimentacaoViewModel : BaseEntityViewModel
    {

        public Tipo_Mov Tipo_Mov { get; set; }

        public double Valor { get; set; }

        public virtual FichaViewModel Ficha { get; set; }

        public Guid Id_Ficha { get; set; }

    }
}