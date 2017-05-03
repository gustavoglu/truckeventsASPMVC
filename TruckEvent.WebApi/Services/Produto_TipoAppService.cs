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
    public class Produto_TipoAppService : IProduto_TipoAppService
    {
        private readonly IProduto_TipoRepository _produto_TipoRepository;

        public Produto_TipoAppService()
        {
            _produto_TipoRepository = new Produto_TipoRepository();
        }

        public Produto_TipoViewModel Atualizar(Produto_TipoViewModel produto_TipoViewModel)
        {
            var produto_TipoDTO = _produto_TipoRepository.BuscarPorId(produto_TipoViewModel.Id);
            var produto_tipo = Mapper.Map(produto_TipoViewModel, produto_TipoDTO);
            return Mapper.Map<Produto_TipoViewModel>(_produto_TipoRepository.Atualizar(produto_tipo));
        }

        public Produto_TipoViewModel BuscarPorId(Guid Id)
        {
            return Mapper.Map<Produto_TipoViewModel>(_produto_TipoRepository.BuscarPorId(Id));

        }

        public Produto_TipoViewModel Criar(Produto_TipoViewModel produto_TipoViewModel)
        {
            var produto_tipo = Mapper.Map<Produto_Tipo>(produto_TipoViewModel);
            return Mapper.Map<Produto_TipoViewModel>(_produto_TipoRepository.Criar(produto_tipo));
        }

        public bool Deletar(Guid Id)
        {
            return _produto_TipoRepository.Deletar(Id);
        }

        public void Dispose()
        {
            _produto_TipoRepository.Dispose();
        }

        public Produto_TipoViewModel Reativar(Guid Id)
        {
            return Mapper.Map<Produto_TipoViewModel>(_produto_TipoRepository.Reativar(Id));
        }

        public IEnumerable<Produto_TipoViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<Produto_TipoViewModel>>(_produto_TipoRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<Produto_TipoViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<Produto_TipoViewModel>>(_produto_TipoRepository.TrazerTodosDeletados().ToList());
        }
    }
}