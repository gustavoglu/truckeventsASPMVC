using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IFichaAppService : IDisposable
    {
        FichaViewModel Criar(FichaViewModel fichaViewModel);

        FichaViewModel Atualizar(FichaViewModel fichaViewModel);

        FichaViewModel BuscarPorId(Guid Id);

        FichaViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<FichaViewModel> TrazerTodosAtivos();

        IEnumerable<FichaViewModel> TrazerTodosDeletados();
    }
}