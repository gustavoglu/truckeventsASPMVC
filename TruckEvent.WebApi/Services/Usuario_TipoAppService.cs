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
    public class Usuario_TipoAppService : IUsuario_TipoAppService
    {
        private readonly IUsuario_TipoRepository _usuario_TipoRepository;

        public Usuario_TipoAppService()
        {
            _usuario_TipoRepository = new Usuario_TipoRepository();
        }

        public Usuario_TipoViewModel Atualizar(Usuario_TipoViewModel usuario_TipoViewModel)
        {
            var usuario_tipo = Mapper.Map<Usuario_Tipo>(usuario_TipoViewModel);
            return Mapper.Map<Usuario_TipoViewModel>(_usuario_TipoRepository.Atualizar(usuario_tipo));

        }

        public Usuario_TipoViewModel BuscarPorId(Guid Id)
        {
            return Mapper.Map<Usuario_TipoViewModel>(_usuario_TipoRepository.BuscarPorId(Id));
        }

        public Usuario_TipoViewModel Criar(Usuario_TipoViewModel usuario_TipoViewModel)
        {
            var usuario_tipo = Mapper.Map<Usuario_Tipo>(usuario_TipoViewModel);
            return Mapper.Map<Usuario_TipoViewModel>(_usuario_TipoRepository.Criar(usuario_tipo));
        }

        public bool Deletar(Guid Id)
        {
            return _usuario_TipoRepository.Deletar(Id);
        }

        public void Dispose()
        {
            _usuario_TipoRepository.Dispose();
        }

        public Usuario_TipoViewModel Reativar(Guid Id)
        {
            return Mapper.Map<Usuario_TipoViewModel>(_usuario_TipoRepository.Reativar(Id));
        }

        public IEnumerable<Usuario_TipoViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<Usuario_TipoViewModel>>(_usuario_TipoRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<Usuario_TipoViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<Usuario_TipoViewModel>>(_usuario_TipoRepository.TrazerTodosDeletados().ToList());
        }
    }
}