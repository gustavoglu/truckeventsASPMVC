using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using TruckEvent.WebApi.Infra.Repository.EntityRepository.Interfaces;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.Repository.EntityRepository
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        //public override Evento Criar(Evento obj)
        //{
        //    var claimidentity = (ClaimsPrincipal)Thread.CurrentPrincipal;
        //    obj.Id_usuario_organizador = claimidentity.Claims.SingleOrDefault(c => c.Type == "id_usuario").Value;

        //    return base.Criar(obj); 
        //}
    }
}