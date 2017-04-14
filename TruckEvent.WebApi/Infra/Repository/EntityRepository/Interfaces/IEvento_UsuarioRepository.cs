using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Infra.Repository.Interfaces;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.Repository.EntityRepository.Interfaces
{
    public interface IEvento_UsuarioRepository : IRepository<Evento_Usuario>
    {
    }
}