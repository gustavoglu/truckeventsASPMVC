using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IProduto_VariacaoAppService : IDisposable
    {
        Produto_VariacaoViewModel Criar(Produto_VariacaoViewModel produto_VariacaoViewModel);

        Produto_VariacaoViewModel Atualizar(Produto_VariacaoViewModel produto_VariacaoViewModel);

        Produto_VariacaoViewModel BuscarPorId(Guid Id);

        Produto_VariacaoViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<Produto_VariacaoViewModel> TrazerTodosAtivos();

        IEnumerable<Produto_VariacaoViewModel> TrazerTodosDeletados();
    }
}