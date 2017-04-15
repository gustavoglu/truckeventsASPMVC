using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Services.Interfaces;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services
{
    public class Venda_ProdutoAppService : IVenda_ProdutoAppService
    {
        public Venda_ProdutoViewModel Atualizar(Venda_ProdutoViewModel venda_ProdutoViewModel)
        {
            throw new NotImplementedException();
        }

        public Venda_ProdutoViewModel BuscarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Venda_ProdutoViewModel Criar(Venda_ProdutoViewModel venda_ProdutoViewModel)
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

        public Venda_ProdutoViewModel Reativar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Venda_ProdutoViewModel> TrazerTodosAtivos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Venda_ProdutoViewModel> TrazerTodosDeletados()
        {
            throw new NotImplementedException();
        }
    }
}