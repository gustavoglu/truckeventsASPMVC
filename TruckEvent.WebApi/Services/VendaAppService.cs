using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Services.Interfaces;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services
{
    public class VendaAppService : IVendaAppService
    {
        public VendaViewModel Atualizar(VendaViewModel vendaViewModel)
        {
            throw new NotImplementedException();
        }

        public VendaViewModel BuscarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public VendaViewModel Criar(VendaViewModel vendaViewModel)
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

        public VendaViewModel Reativar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VendaViewModel> TrazerTodosAtivos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VendaViewModel> TrazerTodosDeletados()
        {
            throw new NotImplementedException();
        }
    }
}