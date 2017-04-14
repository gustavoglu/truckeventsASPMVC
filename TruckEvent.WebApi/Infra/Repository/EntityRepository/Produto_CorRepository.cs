using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Infra.Repository.EntityRepository.Interfaces;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.Repository.EntityRepository
{
    public class Produto_CorRepository : Repository<Produto_Cor>, IProduto_CorRepository
    {
    }
}