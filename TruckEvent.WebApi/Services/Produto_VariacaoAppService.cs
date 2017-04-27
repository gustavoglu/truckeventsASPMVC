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
    public class Produto_VariacaoAppService : IProduto_VariacaoAppService
    {
        private readonly IProduto_VariacaoRepository _produto_VariacaoRepository;

        public Produto_VariacaoAppService()
        {
            _produto_VariacaoRepository = new Produto_VariacaoRepository();
        }

        public Produto_VariacaoViewModel Atualizar(Produto_VariacaoViewModel produto_VariacaoViewModel)
        {
            var produto_variacao = Mapper.Map<Produto_Variacao>(produto_VariacaoViewModel);
            return Mapper.Map<Produto_VariacaoViewModel>(_produto_VariacaoRepository.Atualizar(produto_variacao));
        }

        public Produto_VariacaoViewModel BuscarPorId(Guid Id)
        {
            return Mapper.Map<Produto_VariacaoViewModel>(_produto_VariacaoRepository.BuscarPorId(Id));
        }

        public Produto_VariacaoViewModel Criar(Produto_VariacaoViewModel produto_VariacaoViewModel)
        {
            var produto_variacao = Mapper.Map<Produto_Variacao>(produto_VariacaoViewModel);
            return Mapper.Map<Produto_VariacaoViewModel>(_produto_VariacaoRepository.Criar(produto_variacao));
        }

        public bool Deletar(Guid Id)
        {
            return _produto_VariacaoRepository.Deletar(Id);
        }

        public void Dispose()
        {
            _produto_VariacaoRepository.Dispose();
        }

        public Produto_VariacaoViewModel Reativar(Guid Id)
        {
            return Mapper.Map<Produto_VariacaoViewModel>(_produto_VariacaoRepository.Reativar(Id));
        }

        public IEnumerable<Produto_VariacaoViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<Produto_VariacaoViewModel>>(_produto_VariacaoRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<Produto_VariacaoViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<Produto_VariacaoViewModel>>(_produto_VariacaoRepository.TrazerTodosDeletados().ToList());
        }
    }
}