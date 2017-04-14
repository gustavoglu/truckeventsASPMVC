using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IProduto_CorAppService : IDisposable
    {
        Produto_CorViewModel Criar(Produto_CorViewModel produto_CorViewModel);

        Produto_CorViewModel Atualizar(Produto_CorViewModel produto_CorViewModel);

        Produto_CorViewModel BuscarPorId(Guid Id);

        Produto_CorViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<Produto_CorViewModel> TrazerTodosAtivos();

        IEnumerable<Produto_CorViewModel> TrazerTodosDeletados();

    }
}