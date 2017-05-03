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
    public class Venda_Produto_VariacaoAppService : IVenda_Produto_VariacaoAppService
    {
        private readonly IVenda_Produto_VariacaoRepository _venda_Produto_VariacaoRepository;

        public Venda_Produto_VariacaoAppService()
        {
            _venda_Produto_VariacaoRepository = new Venda_Produto_VariacaoRepository();
        }

        public Venda_Produto_VariacaoViewModel Atualizar(Venda_Produto_VariacaoViewModel venda_Produto_VariacaoViewModel)
        {
            var venda_Produto_VariacaoDTO = _venda_Produto_VariacaoRepository.BuscarPorId(venda_Produto_VariacaoViewModel.Id);
            var venda_produto_variacao = Mapper.Map(venda_Produto_VariacaoViewModel, venda_Produto_VariacaoDTO);
            return Mapper.Map<Venda_Produto_VariacaoViewModel>(_venda_Produto_VariacaoRepository.Atualizar (venda_produto_variacao));
        }

        public Venda_Produto_VariacaoViewModel BuscarPorId(Guid Id)
        {
            return Mapper.Map<Venda_Produto_VariacaoViewModel>(_venda_Produto_VariacaoRepository.BuscarPorId(Id));
        }

        public Venda_Produto_VariacaoViewModel Criar(Venda_Produto_VariacaoViewModel venda_Produto_VariacaoViewModel)
        {
            var venda_produto_variacao = Mapper.Map<Venda_Produto_Variacao>(venda_Produto_VariacaoViewModel);
            return Mapper.Map<Venda_Produto_VariacaoViewModel>(_venda_Produto_VariacaoRepository.Criar (venda_produto_variacao));
        }

        public bool Deletar(Guid Id)
        {
            return _venda_Produto_VariacaoRepository.Deletar(Id);
        }

        public void Dispose()
        {
            _venda_Produto_VariacaoRepository.Dispose();
        }

        public Venda_Produto_VariacaoViewModel Reativar(Guid Id)
        {
            return Mapper.Map<Venda_Produto_VariacaoViewModel>(_venda_Produto_VariacaoRepository.Reativar(Id));
        }

        public IEnumerable<Venda_Produto_VariacaoViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<Venda_Produto_VariacaoViewModel>>(_venda_Produto_VariacaoRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<Venda_Produto_VariacaoViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<Venda_Produto_VariacaoViewModel>>(_venda_Produto_VariacaoRepository.TrazerTodosDeletados().ToList());
        }
    }
}