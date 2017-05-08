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
    public class Venda_Pagamento_FichaAppService : IVenda_Pagamento_FichaAppService
    {
        protected IVenda_Pagamento_FichaRepository _venda_Pagamento_FichaRepository;

        public Venda_Pagamento_FichaAppService()
        {
            _venda_Pagamento_FichaRepository = new Venda_Pagamento_FichaRepository();
        }

        public Venda_Pagamento_FichaViewModel Atualizar(Venda_Pagamento_FichaViewModel venda_Pagamento_FichaViewModel)
        {
            var venda_pagamento_fichaDTO = _venda_Pagamento_FichaRepository.BuscarPorId(venda_Pagamento_FichaViewModel.Id);
            var venda_pagamento_ficha = Mapper.Map(_venda_Pagamento_FichaRepository, venda_pagamento_fichaDTO);
            return Mapper.Map<Venda_Pagamento_FichaViewModel>(_venda_Pagamento_FichaRepository.Atualizar(venda_pagamento_ficha));
        }

        public Venda_Pagamento_FichaViewModel BuscarPorId(Guid Id)
        {
            return Mapper.Map<Venda_Pagamento_FichaViewModel>(_venda_Pagamento_FichaRepository.BuscarPorId(Id));
        }

        public Venda_Pagamento_FichaViewModel Criar(Venda_Pagamento_FichaViewModel venda_Pagamento_FichaViewModel)
        {
            var venda_Pagamento_Ficha= Mapper.Map<Venda_Pagamento_Ficha>(venda_Pagamento_FichaViewModel);
            return Mapper.Map<Venda_Pagamento_FichaViewModel>(_venda_Pagamento_FichaRepository.Criar(venda_Pagamento_Ficha));
        }

        public bool Deletar(Guid Id)
        {
            return _venda_Pagamento_FichaRepository.Deletar(Id);
        }

        public void Dispose()
        {
            _venda_Pagamento_FichaRepository.Dispose();
        }

        public Venda_Pagamento_FichaViewModel Reativar(Guid Id)
        {
            return Mapper.Map<Venda_Pagamento_FichaViewModel>(_venda_Pagamento_FichaRepository.Reativar(Id));
        }

        public IEnumerable<Venda_Pagamento_FichaViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<Venda_Pagamento_FichaViewModel>>(_venda_Pagamento_FichaRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<Venda_Pagamento_FichaViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<Venda_Pagamento_FichaViewModel>>(_venda_Pagamento_FichaRepository.TrazerTodosDeletados().ToList());
        }
    }
}