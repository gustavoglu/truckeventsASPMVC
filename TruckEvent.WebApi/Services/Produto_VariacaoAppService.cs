using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Services.Interfaces;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services
{
    public class Produto_VariacaoAppService : IProduto_VariacaoAppService
    {
        public Produto_VariacaoViewModel Atualizar(Produto_VariacaoViewModel produto_VariacaoViewModel)
        {
            throw new NotImplementedException();
        }

        public Produto_VariacaoViewModel BuscarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Produto_VariacaoViewModel Criar(Produto_VariacaoViewModel produto_VariacaoViewModel)
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

        public Produto_VariacaoViewModel Reativar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto_VariacaoViewModel> TrazerTodosAtivos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto_VariacaoViewModel> TrazerTodosDeletados()
        {
            throw new NotImplementedException();
        }
    }
}