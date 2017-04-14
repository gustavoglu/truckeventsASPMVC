using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IVendaAppService : IDisposable
    {
        VendaViewModel Criar(VendaViewModel vendaViewModel);

        VendaViewModel Atualizar(VendaViewModel vendaViewModel);

        VendaViewModel BuscarPorId(Guid Id);

        VendaViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<VendaViewModel> TrazerTodosAtivos();

        IEnumerable<VendaViewModel> TrazerTodosDeletados();
    }
}