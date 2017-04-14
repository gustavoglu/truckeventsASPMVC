using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Infra.Repository.EntityRepository.Interfaces;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.Repository.EntityRepository
{
    public class Venda_Produto_VariacaoRepository : Repository<Venda_Produto_Variacao>, IVenda_Produto_VariacaoRepository
    {
    }
}