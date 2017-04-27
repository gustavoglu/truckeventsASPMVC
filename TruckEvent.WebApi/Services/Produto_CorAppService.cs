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
    public class Produto_CorAppService : IProduto_CorAppService
    {
        private readonly IProduto_CorRepository _produto_CorRepository;

        public Produto_CorAppService()
        {
            _produto_CorRepository = new Produto_CorRepository();
        }

        public Produto_CorViewModel Atualizar(Produto_CorViewModel produto_CorViewModel)
        {
            var produto_cor = Mapper.Map<Produto_Cor>(produto_CorViewModel);
            return Mapper.Map<Produto_CorViewModel>(_produto_CorRepository.Atualizar(produto_cor));
        }

        public Produto_CorViewModel BuscarPorId(Guid Id)
        {
            return Mapper.Map<Produto_CorViewModel>(_produto_CorRepository.BuscarPorId(Id));
        }

        public Produto_CorViewModel Criar(Produto_CorViewModel produto_CorViewModel)
        {
            var produto_cor = Mapper.Map<Produto_Cor>(produto_CorViewModel);
            return Mapper.Map<Produto_CorViewModel>(_produto_CorRepository.Criar(produto_cor));
        }

        public bool Deletar(Guid Id)
        {
            return _produto_CorRepository.Deletar(Id);
        }

        public void Dispose()
        {
            _produto_CorRepository.Dispose();
        }

        public Produto_CorViewModel Reativar(Guid Id)
        {
            return Mapper.Map<Produto_CorViewModel>(_produto_CorRepository.Reativar(Id));
        }

        public IEnumerable<Produto_CorViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<Produto_CorViewModel>>(_produto_CorRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<Produto_CorViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<Produto_CorViewModel>>(_produto_CorRepository.TrazerTodosDeletados().ToList());
        }
    }
}