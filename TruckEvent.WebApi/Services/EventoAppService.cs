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
    public class EventoAppService : IEventoAppService
    {
        protected IEventoRepository _eventoRepository;

        public EventoAppService()
        {
            _eventoRepository = new EventoRepository();
        }

        public EventoViewModel Atualizar(EventoViewModel eventoViewModel)
        {
            var eventoDTO = _eventoRepository.BuscarPorId(eventoViewModel.Id);
            var evento = Mapper.Map(eventoViewModel, eventoDTO);
            return Mapper.Map<EventoViewModel>(evento);
        }

        public EventoViewModel BuscarPorId(Guid Id)
        {
            return Mapper.Map<EventoViewModel>(_eventoRepository.BuscarPorId(Id));
        }

        public EventoViewModel Criar(EventoViewModel eventoViewModel)
        {
            var evento = Mapper.Map<Evento>(eventoViewModel);
            return Mapper.Map<EventoViewModel>(_eventoRepository.Criar(evento));
        }

        public bool Deletar(Guid Id)
        {
            return _eventoRepository.Deletar(Id);
        }

        public void Dispose()
        {
            _eventoRepository.Dispose();
        }

        public EventoViewModel Reativar(Guid Id)
        {
            return Mapper.Map<EventoViewModel>(_eventoRepository.Reativar(Id));
        }

        public IEnumerable<EventoViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<EventoViewModel>>( _eventoRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<EventoViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<EventoViewModel>>(_eventoRepository.TrazerTodosDeletados().ToList());
        }
    }
}