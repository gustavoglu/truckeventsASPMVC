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
    public class VariacaoAppService : IVariacaoAppService
    {
        private readonly IVariacaoRepository _variacaoRepository;

        public VariacaoAppService()
        {
            _variacaoRepository = new VariacaoRepository();
        }

        public VariacaoViewModel Atualizar(VariacaoViewModel variacaoViewModel)
        {
            var variacao = Mapper.Map<Variacao>(variacaoViewModel);
            return Mapper.Map<VariacaoViewModel>(_variacaoRepository.Atualizar(variacao));
        }

        public VariacaoViewModel BuscarPorId(Guid Id)
        {
            return Mapper.Map<VariacaoViewModel>(_variacaoRepository.BuscarPorId(Id));
        }

        public VariacaoViewModel Criar(VariacaoViewModel variacaoViewModel)
        {
            var variacao = Mapper.Map<Variacao>(variacaoViewModel);
            return Mapper.Map<VariacaoViewModel>(_variacaoRepository.Criar(variacao));
        }

        public bool Deletar(Guid Id)
        {
            return _variacaoRepository.Deletar(Id);
        }

        public void Dispose()
        {
            _variacaoRepository.Dispose();
        }

        public VariacaoViewModel Reativar(Guid Id)
        {
            return Mapper.Map<VariacaoViewModel>(_variacaoRepository.Reativar(Id));
        }

        public IEnumerable<VariacaoViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<VariacaoViewModel>>(_variacaoRepository.TrazerTodosAtivos());
        }

        public IEnumerable<VariacaoViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<VariacaoViewModel>>(_variacaoRepository.TrazerTodosDeletados());
        }
    }
}