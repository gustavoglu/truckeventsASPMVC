using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IEventoAppService : IDisposable
    {
        EventoViewModel Criar(EventoViewModel eventoViewModel);

        EventoViewModel Atualizar(EventoViewModel eventoViewModel);

        EventoViewModel BuscarPorId(Guid Id);

        EventoViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<EventoViewModel> TrazerTodosAtivos();

        IEnumerable<EventoViewModel> TrazerTodosDeletados();
    }
}