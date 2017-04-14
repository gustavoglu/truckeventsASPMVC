using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IVenda_Produto_VariacaoAppService : IDisposable
    {
        Venda_Produto_VariacaoViewModel Criar(Venda_Produto_VariacaoViewModel venda_Produto_VariacaoViewModel);

        Venda_Produto_VariacaoViewModel Atualizar(Venda_Produto_VariacaoViewModel venda_Produto_VariacaoViewModel);

        Venda_Produto_VariacaoViewModel BuscarPorId(Guid Id);

        Venda_Produto_VariacaoViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<Venda_Produto_VariacaoViewModel> TrazerTodosAtivos();

        IEnumerable<Venda_Produto_VariacaoViewModel> TrazerTodosDeletados();
    }
}