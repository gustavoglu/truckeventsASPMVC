using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Services.Interfaces;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services
{
    public class Usuario_TipoAppService : IUsuario_TipoAppService
    {
        public Usuario_TipoViewModel Atualizar(Usuario_TipoViewModel usuario_TipoViewModel)
        {
            throw new NotImplementedException();
        }

        public Usuario_TipoViewModel BuscarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Usuario_TipoViewModel Criar(Usuario_TipoViewModel usuario_TipoViewModel)
        {
            throw new NotImplementedException();
        }

        public bool Deletar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Usuario_TipoViewModel Reativar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario_TipoViewModel> TrazerTodosAtivos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario_TipoViewModel> TrazerTodosDeletados()
        {
            throw new NotImplementedException();
        }
    }
}