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
    public class Pagamento_TipoAppService : IPagamento_TipoAppService
    {
        private readonly IPagamento_TipoRepository _pagamento_TipoRepository;

        public Pagamento_TipoAppService()
        {
            _pagamento_TipoRepository = new Pagamento_TipoRepository();
        }

        public Pagamento_TipoViewModel Atualizar(Pagamento_TipoViewModel pagamento_TipoViewModel)
        {
            var pagamento_TipoDTO = _pagamento_TipoRepository.BuscarPorId(pagamento_TipoViewModel.Id);
            var pagamento_tipo = Mapper.Map(pagamento_TipoViewModel, pagamento_TipoDTO);
            return Mapper.Map<Pagamento_TipoViewModel>(_pagamento_TipoRepository.Atualizar(pagamento_tipo));
        }

        public Pagamento_TipoViewModel BuscarPorId(Guid Id)
        {
            return Mapper.Map<Pagamento_TipoViewModel>(_pagamento_TipoRepository.BuscarPorId(Id));
        }

        public Pagamento_TipoViewModel Criar(Pagamento_TipoViewModel pagamento_TipoViewModel)
        {
            var pagamento_tipo = Mapper.Map<Pagamento_Tipo>(pagamento_TipoViewModel);
            return Mapper.Map<Pagamento_TipoViewModel>(_pagamento_TipoRepository.Criar(pagamento_tipo));
        }

        public bool Deletar(Guid Id)
        {
            return _pagamento_TipoRepository.Deletar(Id);
        }

        public void Dispose()
        {
            _pagamento_TipoRepository.Dispose();
        }

        public Pagamento_TipoViewModel Reativar(Guid Id)
        {
            return Mapper.Map<Pagamento_TipoViewModel>(_pagamento_TipoRepository.Reativar(Id));
        }

        public IEnumerable<Pagamento_TipoViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<Pagamento_TipoViewModel>>(_pagamento_TipoRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<Pagamento_TipoViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<Pagamento_TipoViewModel>>(_pagamento_TipoRepository.TrazerTodosDeletados().ToList());
        }
    }
}