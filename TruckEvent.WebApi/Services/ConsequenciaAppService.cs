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
    public class ConsequenciaAppService : IConsequenciaAppService
    {
        private readonly IConsequenciaRepository _consequenciaRepository;

        public ConsequenciaAppService()
        {
            _consequenciaRepository = new ConsequenciaRepository();
        }

        public ConsequenciaViewModel Atualizar(ConsequenciaViewModel consequenciaViewModel)
        {
            var consequencia = Mapper.Map<Consequencia>(consequenciaViewModel);
            return Mapper.Map<ConsequenciaViewModel>(_consequenciaRepository.Atualizar(consequencia));
        }

        public ConsequenciaViewModel BuscarPorId(Guid Id)
        {
            return Mapper.Map<ConsequenciaViewModel>(_consequenciaRepository.BuscarPorId(Id));
        }

        public ConsequenciaViewModel Criar(ConsequenciaViewModel consequenciaViewModel)
        {
            var consequencia = Mapper.Map<Consequencia>(consequenciaViewModel);
            return Mapper.Map<ConsequenciaViewModel>(_consequenciaRepository.Criar(consequencia));
        }

        public bool Deletar(Guid Id)
        {
            return _consequenciaRepository.Deletar(Id);
        }

        public void Dispose()
        {
            _consequenciaRepository.Dispose();
        }

        public ConsequenciaViewModel Reativar(Guid Id)
        {
            return Mapper.Map<ConsequenciaViewModel>(_consequenciaRepository.Reativar(Id));
        }

        public IEnumerable<ConsequenciaViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<ConsequenciaViewModel>>(_consequenciaRepository.TrazerTodosAtivos());
        }

        public IEnumerable<ConsequenciaViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<ConsequenciaViewModel>>(_consequenciaRepository.TrazerTodosDeletados());
        }
    }
}