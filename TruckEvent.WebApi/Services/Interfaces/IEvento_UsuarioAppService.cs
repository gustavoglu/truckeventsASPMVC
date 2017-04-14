using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IEvento_UsuarioAppService : IDisposable
    {
        Evento_UsuarioViewModel Criar(Evento_UsuarioViewModel evento_UsuarioViewModel);

        Evento_UsuarioViewModel Atualizar(Evento_UsuarioViewModel evento_UsuarioViewModel);

        Evento_UsuarioViewModel BuscarPorId(Guid Id);

        Evento_UsuarioViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<Evento_UsuarioViewModel> TrazerTodosAtivos();

        IEnumerable<Evento_UsuarioViewModel> TrazerTodosDeletados();
    }
}