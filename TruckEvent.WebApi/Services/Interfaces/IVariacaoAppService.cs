using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IVariacaoAppService : IDisposable
    {
        VariacaoViewModel Criar(VariacaoViewModel variacaoViewModel);

        VariacaoViewModel Atualizar(VariacaoViewModel variacaoViewModel);

        VariacaoViewModel BuscarPorId(Guid Id);

        VariacaoViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<VariacaoViewModel> TrazerTodosAtivos();

        IEnumerable<VariacaoViewModel> TrazerTodosDeletados();
    }
}