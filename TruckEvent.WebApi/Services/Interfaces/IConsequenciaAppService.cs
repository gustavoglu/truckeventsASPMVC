using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IConsequenciaAppService : IDisposable
    {
        ConsequenciaViewModel Criar(ConsequenciaViewModel consequenciaViewModel);

        ConsequenciaViewModel Atualizar(ConsequenciaViewModel consequenciaViewModel);

        ConsequenciaViewModel BuscarPorId(Guid Id);

        ConsequenciaViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<ConsequenciaViewModel> TrazerTodosAtivos();

        IEnumerable<ConsequenciaViewModel> TrazerTodosDeletados();

    }
}