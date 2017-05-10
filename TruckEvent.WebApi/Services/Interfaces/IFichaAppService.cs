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

        FichaViewModel BuscarPorCodigo(string codigo);

        FichaViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<FichaViewModel> TrazerTodosAtivos();

        IEnumerable<FichaViewModel> TrazerTodosAtivos(Guid id_evento);

        IEnumerable<FichaViewModel> TrazerTodosDeletados();

        IEnumerable<FichaViewModel> TrazerTodosDeletados(Guid id_evento);
    }
}