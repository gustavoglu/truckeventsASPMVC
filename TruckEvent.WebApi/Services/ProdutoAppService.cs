using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Services.Interfaces;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        public ProdutoViewModel Atualizar(ProdutoViewModel produtoViewModel)
        {
            throw new NotImplementedException();
        }

        public ProdutoViewModel BuscarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public ProdutoViewModel Criar(ProdutoViewModel produtoViewModel)
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

        public ProdutoViewModel Reativar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProdutoViewModel> TrazerTodosAtivos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProdutoViewModel> TrazerTodosDeletados()
        {
            throw new NotImplementedException();
        }
    }
}