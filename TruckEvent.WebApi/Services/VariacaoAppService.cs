using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Services.Interfaces;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services
{
    public class VariacaoAppService : IVariacaoAppService
    {
        public VariacaoViewModel Atualizar(VariacaoViewModel variacaoViewModel)
        {
            throw new NotImplementedException();
        }

        public VariacaoViewModel BuscarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public VariacaoViewModel Criar(VariacaoViewModel variacaoViewModel)
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

        public VariacaoViewModel Reativar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VariacaoViewModel> TrazerTodosAtivos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VariacaoViewModel> TrazerTodosDeletados()
        {
            throw new NotImplementedException();
        }
    }
}