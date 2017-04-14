using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IVenda_PagamentoAppService : IDisposable
    {
        Venda_PagamentoViewModel Criar(Venda_PagamentoViewModel venda_PagamentoViewModel);

        Venda_PagamentoViewModel Atualizar(Venda_PagamentoViewModel venda_PagamentoViewModel);

        Venda_PagamentoViewModel BuscarPorId(Guid Id);

        Venda_PagamentoViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<Venda_PagamentoViewModel> TrazerTodosAtivos();

        IEnumerable<Venda_PagamentoViewModel> TrazerTodosDeletados();
    }
}