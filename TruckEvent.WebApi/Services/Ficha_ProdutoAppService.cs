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
    public class Ficha_ProdutoAppService : IFIcha_ProdutoAppService
    {
        protected readonly IFicha_ProdutoRepository _ficha_ProdutoRepository;


        public Ficha_ProdutoAppService()
        {
            _ficha_ProdutoRepository = new Ficha_ProdutoRepository();
        }
        public Ficha_ProdutoViewModel Atualizar(Ficha_ProdutoViewModel ficha_ProdutoViewModel)
        {
            var ficha_produto = Mapper.Map<Ficha_Produto>(ficha_ProdutoViewModel);
            return Mapper.Map<Ficha_ProdutoViewModel>(_ficha_ProdutoRepository.Atualizar(ficha_produto));
        }

        public Ficha_ProdutoViewModel BuscarPorId(Guid Id)
        {
            return Mapper.Map<Ficha_ProdutoViewModel>(_ficha_ProdutoRepository.BuscarPorId(Id));
        }

        public Ficha_ProdutoViewModel Criar(Ficha_ProdutoViewModel ficha_ProdutoViewModel)
        {
            var ficha_produto = Mapper.Map<Ficha_Produto>(ficha_ProdutoViewModel);
            return Mapper.Map<Ficha_ProdutoViewModel>(_ficha_ProdutoRepository.Criar(ficha_produto));
        }

        public bool Deletar(Guid Id)
        {
            return _ficha_ProdutoRepository.Deletar(Id);
        }

        public void Dispose()
        {
            _ficha_ProdutoRepository.Dispose();
        }

        public Ficha_ProdutoViewModel Reativar(Guid Id)
        {
            return Mapper.Map<Ficha_ProdutoViewModel>(_ficha_ProdutoRepository.Reativar(Id));
        }

        public IEnumerable<Ficha_ProdutoViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<Ficha_ProdutoViewModel>>(_ficha_ProdutoRepository.TrazerTodosAtivos());
        }

        public IEnumerable<Ficha_ProdutoViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<Ficha_ProdutoViewModel>>(_ficha_ProdutoRepository.TrazerTodosDeletados());
        }
    }
}