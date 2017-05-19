using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IMovimentacaoAppService : IDisposable
    {
        MovimentacaoViewModel Criar(MovimentacaoViewModel movimentacaoViewModel);

        MovimentacaoViewModel Atualizar(MovimentacaoViewModel movimentacaoViewModel);

        MovimentacaoViewModel BuscarPorId(Guid Id);

        MovimentacaoViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<MovimentacaoViewModel> TrazerTodosAtivos();

        IEnumerable<MovimentacaoViewModel> TrazerTodosDeletados();
    }
}