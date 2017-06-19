using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Infra.Repository.Interfaces;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.Repository.EntityRepository.Interfaces
{
    public interface IVenda_PagamentoRepository : IRepository<Venda_Pagamento>
    {
        IEnumerable<Venda_Pagamento> TrazerAtivoPorVenda(Guid Id_Venda);
    }
}