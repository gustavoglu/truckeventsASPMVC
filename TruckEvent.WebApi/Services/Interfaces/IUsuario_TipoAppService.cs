using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services.Interfaces
{
    public interface IUsuario_TipoAppService : IDisposable
    {
        Usuario_TipoViewModel Criar(Usuario_TipoViewModel usuario_TipoViewModel);

        Usuario_TipoViewModel Atualizar(Usuario_TipoViewModel usuario_TipoViewModel);

        Usuario_TipoViewModel BuscarPorId(Guid Id);

        Usuario_TipoViewModel Reativar(Guid Id);

        bool Deletar(Guid Id);

        IEnumerable<Usuario_TipoViewModel> TrazerTodosAtivos();

        IEnumerable<Usuario_TipoViewModel> TrazerTodosDeletados();
    }
}