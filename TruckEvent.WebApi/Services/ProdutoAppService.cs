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
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoAppService()
        {
            _produtoRepository = new ProdutoRepository();
        }

        public ProdutoViewModel Atualizar(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<Produto>(produtoViewModel);
            return Mapper.Map<ProdutoViewModel>(_produtoRepository.Atualizar(produto));
        }

        public ProdutoViewModel BuscarPorId(Guid Id)
        {
            var produto = _produtoRepository.BuscarPorId(Id);
            var viewmodel = Mapper.Map<ProdutoViewModel>(produto);
            return viewmodel;
        }

        public ProdutoViewModel Criar(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<Produto>(produtoViewModel);
            return Mapper.Map<ProdutoViewModel>(_produtoRepository.Criar(produto));
        }

        public bool Deletar(Guid Id)
        {
            return _produtoRepository.Deletar(Id);
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }

        public ProdutoViewModel Reativar(Guid Id)
        {
            return Mapper.Map<ProdutoViewModel>(_produtoRepository.Reativar(Id));
        }

        public IEnumerable<ProdutoViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<ProdutoViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.TrazerTodosDeletados().ToList());
        }
    }
}