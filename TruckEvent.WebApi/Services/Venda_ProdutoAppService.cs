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
    public class Venda_ProdutoAppService : IVenda_ProdutoAppService
    {
        private readonly IVenda_ProdutoRepository _venda_ProdutoRepository;
        public Venda_ProdutoAppService()
        {
            _venda_ProdutoRepository = new Venda_ProdutoRepository();
        }

        public Venda_ProdutoViewModel Atualizar(Venda_ProdutoViewModel venda_ProdutoViewModel)
        {
            var venda_ProdutoDTO = _venda_ProdutoRepository.BuscarPorId(venda_ProdutoViewModel.Id); 
            var venda_produto = Mapper.Map(venda_ProdutoViewModel, venda_ProdutoDTO) ;
            return Mapper.Map<Venda_ProdutoViewModel>(_venda_ProdutoRepository.Atualizar(venda_produto));
        }

        public Venda_ProdutoViewModel BuscarPorId(Guid Id)
        {
            return Mapper.Map<Venda_ProdutoViewModel> (_venda_ProdutoRepository.BuscarPorId(Id));
        }

        public Venda_ProdutoViewModel Criar(Venda_ProdutoViewModel venda_ProdutoViewModel)
        {
            var venda_produto = Mapper.Map<Venda_Produto>(venda_ProdutoViewModel);
            return Mapper.Map<Venda_ProdutoViewModel>(_venda_ProdutoRepository.Criar(venda_produto));
        }

        public bool Deletar(Guid Id)
        {
            return _venda_ProdutoRepository.Deletar(Id);
        }

        public void Dispose()
        {
            _venda_ProdutoRepository.Dispose();
        }

        public Venda_ProdutoViewModel Reativar(Guid Id)
        {
            return Mapper.Map<Venda_ProdutoViewModel> (_venda_ProdutoRepository.Reativar(Id));
        }

        public IEnumerable<Venda_ProdutoViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<Venda_ProdutoViewModel>>(_venda_ProdutoRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<Venda_ProdutoViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<Venda_ProdutoViewModel>>(_venda_ProdutoRepository.TrazerTodosDeletados().ToList());
        }
    }
}