using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Infra.Repository.Interfaces;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.Repository.EntityRepository.Interfaces
{
    public interface IFicha_Repository : IRepository<Ficha>
    {
        Ficha Estornar(Ficha obj, double? valorAntigo);

        Ficha Atualizar(Ficha obj,double? valorAntigo);

        Ficha Atualizar(Venda_Pagamento_Ficha venda_Pagamento_Ficha,double pagamento);

    }
}