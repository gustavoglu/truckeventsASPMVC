using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TruckEvent.WebApi.Infra.Repository;
using TruckEvent.WebApi.Models;
using TruckEvent.WebApi.Services.Interfaces;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services
{
    public class AppService<T, J> : IAppService<T, J> where T : BaseEntity where J : BaseEntityViewModel
    {

        protected Repository<T> _repository;

        public AppService()
        {
            this._repository =  new Repository<T>() ;
        }

        public virtual J Atualizar(J viewModel)
        {   
            var entityDTO = _repository.BuscarPorId(viewModel.Id);
            var entity = Mapper.Map(viewModel, entityDTO);
            return Mapper.Map<J>(_repository.Atualizar(entity));
        }

        public virtual J BuscarPorId(Guid Id)
        {
            return Mapper.Map<J>(_repository.BuscarPorId(Id));
        }

        public virtual J Criar(J viewModel)
        {
            var evento = Mapper.Map<T>(viewModel);
            return Mapper.Map<J>(_repository.Criar(evento));
        }

        public virtual bool Deletar(Guid Id)
        {
            return _repository.Deletar(Id);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }

        public virtual J Reativar(Guid Id)
        {
            return Mapper.Map<J>(_repository.Reativar(Id));
        }

        public virtual IEnumerable<J> TrazerTodos()
        {
            return Mapper.Map<List<J>>(_repository.TrazerTodos().ToList());
        }

        public virtual IEnumerable<J> TrazerTodosAtivos()
        {
            return Mapper.Map<List<J>>(_repository.TrazerTodosAtivos().ToList()); 
        }

        public virtual IEnumerable<J> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<J>>(_repository.TrazerTodosDeletados().ToList());
        }
    }
}