using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Infra.Repository.EntityRepository;
using TruckEvent.WebApi.Infra.Repository.EntityRepository.Interfaces;
using TruckEvent.WebApi.Models;
using TruckEvent.WebApi.Services.Interfaces;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services
{
    public class Venda_Pagamento_FichaAppService : AppService<Venda_Pagamento_Ficha, Venda_Pagamento_FichaViewModel>, IVenda_Pagamento_FichaAppService
    {
        
    }
}