using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {
        ProdutoViewModel Criar(ProdutoViewModel produtoViewModel);

        ProdutoViewModel Atualizar(ProdutoViewModel produtoViewModel);

        ProdutoViewModel BuscarPorId(Guid Id);

        ProdutoViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<ProdutoViewModel> TrazerTodosAtivos();

        IEnumerable<ProdutoViewModel> TrazerTodosDeletados();

    }
}