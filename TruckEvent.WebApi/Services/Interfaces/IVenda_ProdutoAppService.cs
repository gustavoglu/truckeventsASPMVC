using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IVenda_ProdutoAppService : IDisposable
    {
        Venda_ProdutoViewModel Criar(Venda_ProdutoViewModel venda_ProdutoViewModel);

        Venda_ProdutoViewModel Atualizar(Venda_ProdutoViewModel venda_ProdutoViewModel);

        Venda_ProdutoViewModel BuscarPorId(Guid Id);

        Venda_ProdutoViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<Venda_ProdutoViewModel> TrazerTodosAtivos();

        IEnumerable<Venda_ProdutoViewModel> TrazerTodosDeletados();
    }
}