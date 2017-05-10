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
    public class Produto_TipoAppService : AppService<Produto_Tipo, Produto_TipoViewModel>, IProduto_TipoAppService
    {
       
    }
}