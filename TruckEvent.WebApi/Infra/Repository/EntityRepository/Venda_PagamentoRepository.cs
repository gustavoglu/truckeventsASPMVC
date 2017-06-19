using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Infra.Repository.EntityRepository.Interfaces;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.Repository.EntityRepository
{
    public class Venda_PagamentoRepository : Repository<Venda_Pagamento>, IVenda_PagamentoRepository
    {
        public IEnumerable<Venda_Pagamento> TrazerAtivoPorVenda(Guid Id_Venda)
        {
            return this.dbSet.Where(p => p.Id_venda == Id_Venda && p.Deletado == false);
        }
    }
}