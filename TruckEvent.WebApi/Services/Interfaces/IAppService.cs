using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IAppService<T,J> : IDisposable
    {
        J Criar(J objViewModel);

        J Atualizar(J objViewModel);

        J BuscarPorId(Guid Id);

        J Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<J> TrazerTodosAtivos();

        IEnumerable<J> TrazerTodosDeletados();
    }
}