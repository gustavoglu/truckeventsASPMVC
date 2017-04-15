using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Services.Interfaces;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services
{
    public class Venda_PagamentoAppService : IVenda_PagamentoAppService
    {
        public Venda_PagamentoViewModel Atualizar(Venda_PagamentoViewModel venda_PagamentoViewModel)
        {
            throw new NotImplementedException();
        }

        public Venda_PagamentoViewModel BuscarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Venda_PagamentoViewModel Criar(Venda_PagamentoViewModel venda_PagamentoViewModel)
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

        public Venda_PagamentoViewModel Reativar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Venda_PagamentoViewModel> TrazerTodosAtivos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Venda_PagamentoViewModel> TrazerTodosDeletados()
        {
            throw new NotImplementedException();
        }
    }
}