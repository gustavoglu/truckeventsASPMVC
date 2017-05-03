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
    public class Evento_UsuarioAppService : IEvento_UsuarioAppService
    {
        private readonly IEvento_UsuarioRepository _evento_UsuarioRepository;

        public Evento_UsuarioAppService()
        {
            _evento_UsuarioRepository = new Evento_UsuarioRepository();
        }

        public Evento_UsuarioViewModel Atualizar(Evento_UsuarioViewModel evento_UsuarioViewModel)
        {
            var evento_UsuarioDTO = _evento_UsuarioRepository.BuscarPorId(evento_UsuarioViewModel.Id);
            var evento_usuario = Mapper.Map(evento_UsuarioViewModel, evento_UsuarioDTO);
            return Mapper.Map<Evento_UsuarioViewModel>(_evento_UsuarioRepository.Atualizar(evento_usuario));
        }

        public Evento_UsuarioViewModel BuscarPorId(Guid Id)
        {
            return Mapper.Map<Evento_UsuarioViewModel>(_evento_UsuarioRepository.BuscarPorId(Id));
        }

        public Evento_UsuarioViewModel Criar(Evento_UsuarioViewModel evento_UsuarioViewModel)
        {
            var evento_usuario = Mapper.Map<Evento_Usuario>(evento_UsuarioViewModel);
            return Mapper.Map<Evento_UsuarioViewModel>(_evento_UsuarioRepository.Criar(evento_usuario));
        }

        public bool Deletar(Guid Id)
        {
            return _evento_UsuarioRepository.Deletar(Id);
        }

        public void Dispose()
        {
            _evento_UsuarioRepository.Dispose();
        }

        public Evento_UsuarioViewModel Reativar(Guid Id)
        {
            return Mapper.Map<Evento_UsuarioViewModel>(_evento_UsuarioRepository.Reativar(Id));
        }

        public IEnumerable<Evento_UsuarioViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<Evento_UsuarioViewModel>>(_evento_UsuarioRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<Evento_UsuarioViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<Evento_UsuarioViewModel>>(_evento_UsuarioRepository.TrazerTodosDeletados().ToList());
        }
    }
}