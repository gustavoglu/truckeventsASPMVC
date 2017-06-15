using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.Models
{
    public enum Tipo_Mov { Entrada, Saida, Estorno };

    public class Movimentacao : BaseEntity
    {

        public Movimentacao(Guid Id_Ficha,double valorAntigo, double valorNovo, bool? estorno) : base()
        {
            this.Id_Ficha = Id_Ficha;

            if (valorAntigo > valorNovo)
            {
                this.Valor = valorAntigo - valorNovo;
                this.Tipo_Mov = Tipo_Mov.Saida;
            }
            else if (valorAntigo < valorNovo)
            {

                if (estorno == true)
                {
                    this.Valor = valorNovo - valorAntigo;
                    this.Tipo_Mov = Tipo_Mov.Estorno;
                }

                else
                {
                    this.Valor = valorNovo - valorAntigo;
                    this.Tipo_Mov = Tipo_Mov.Entrada;
                }
            }
        }

        public Movimentacao() : base()
        {

        }

        public Tipo_Mov Tipo_Mov { get; set; }

        public double Valor { get; set; }

        public virtual Ficha Ficha { get; set; }

        public Guid Id_Ficha { get; set; }

    }
}