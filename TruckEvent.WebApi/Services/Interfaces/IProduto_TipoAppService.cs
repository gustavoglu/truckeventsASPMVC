using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IProduto_TipoAppService : IDisposable
    {
        Produto_TipoViewModel Criar(Produto_TipoViewModel produto_TipoViewModel);

        Produto_TipoViewModel Atualizar(Produto_TipoViewModel produto_TipoViewModel);

        Produto_TipoViewModel BuscarPorId(Guid Id);

        Produto_TipoViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<Produto_TipoViewModel> TrazerTodosAtivos();

        IEnumerable<Produto_TipoViewModel> TrazerTodosDeletados();

    }
}