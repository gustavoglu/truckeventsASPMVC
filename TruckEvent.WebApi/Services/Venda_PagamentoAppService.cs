using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Infra.Repository.EntityRepository;
using TruckEvent.WebApi.Infra.Repository.EntityRepository.Interfaces;
using TruckEvent.WebApi.Models;
using TruckEvent.WebApi.Services.Interfaces;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services
{
    public class Venda_PagamentoAppService : IVenda_PagamentoAppService
    {
        private readonly IVenda_PagamentoRepository _venda_PagamentoRepository;

        public Venda_PagamentoAppService()
        {
            _venda_PagamentoRepository = new Venda_PagamentoRepository();
        }

        public Venda_PagamentoViewModel Atualizar(Venda_PagamentoViewModel venda_PagamentoViewModel)
        {
            var venda_PagamentoDTO = _venda_PagamentoRepository.BuscarPorId(venda_PagamentoViewModel.Id);
            var venda_pagamento = Mapper.Map(venda_PagamentoViewModel,venda_PagamentoDTO);
            return Mapper.Map<Venda_PagamentoViewModel>(_venda_PagamentoRepository.Atualizar(venda_pagamento));
        }

        public Venda_PagamentoViewModel BuscarPorId(Guid Id)
        {
            return Mapper.Map<Venda_PagamentoViewModel>(_venda_PagamentoRepository.BuscarPorId(Id));
        }

        public Venda_PagamentoViewModel Criar(Venda_PagamentoViewModel venda_PagamentoViewModel)
        {
            var venda_pagamento = Mapper.Map<Venda_Pagamento>(venda_PagamentoViewModel);
            return Mapper.Map<Venda_PagamentoViewModel>(_venda_PagamentoRepository.Criar(venda_pagamento));

        }

        public bool Deletar(Guid Id)
        {
            return _venda_PagamentoRepository.Deletar(Id);
        }

        public void Dispose()
        {
            _venda_PagamentoRepository.Dispose();
        }

        public Venda_PagamentoViewModel Reativar(Guid Id)
        {
            return Mapper.Map<Venda_PagamentoViewModel>(_venda_PagamentoRepository.Reativar(Id));
        }

        public IEnumerable<Venda_PagamentoViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<Venda_PagamentoViewModel>>(_venda_PagamentoRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<Venda_PagamentoViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<Venda_PagamentoViewModel>>(_venda_PagamentoRepository.TrazerTodosDeletados().ToList());
        }
    }
}