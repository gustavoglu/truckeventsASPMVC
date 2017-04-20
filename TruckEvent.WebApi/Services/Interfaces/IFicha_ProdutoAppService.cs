using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IFicha_ProdutoAppService : IDisposable
    {
        Ficha_ProdutoViewModel Criar(Ficha_ProdutoViewModel ficha_ProdutoViewModel);

        Ficha_ProdutoViewModel Atualizar(Ficha_ProdutoViewModel ficha_ProdutoViewModel);

        Ficha_ProdutoViewModel BuscarPorId(Guid Id);

        Ficha_ProdutoViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<Ficha_ProdutoViewModel> TrazerTodosAtivos();

        IEnumerable<Ficha_ProdutoViewModel> TrazerTodosDeletados();
    }
}