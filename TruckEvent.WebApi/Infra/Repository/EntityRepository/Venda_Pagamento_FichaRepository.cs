using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Infra.Repository.EntityRepository.Interfaces;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.Repository.EntityRepository
{
    public class Venda_Pagamento_FichaRepository : Repository<Venda_Pagamento_Ficha>,IVenda_Pagamento_FichaRepository
    {
    }
}