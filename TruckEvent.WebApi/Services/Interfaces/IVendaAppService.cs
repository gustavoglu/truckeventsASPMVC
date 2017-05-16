using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Models;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IVendaAppService : IAppService<Venda,VendaViewModel>
    {
        IEnumerable<VendaViewModel> TrazerVendasDeEvento(Guid id_evento);
    }
}