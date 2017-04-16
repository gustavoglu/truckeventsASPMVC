﻿using AutoMapper;
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
    public class FichaAppService : IFichaAppService
    {
        private readonly IFicha_Repository _fichaRepository;

        public FichaAppService()
        {
            _fichaRepository = new Ficha_Repository();
        }

        public FichaViewModel Atualizar(FichaViewModel fichaViewModel)
        {
            var ficha = Mapper.Map<Ficha>(fichaViewModel);
            return Mapper.Map<FichaViewModel>(_fichaRepository.Atualizar(ficha));
        }

        public FichaViewModel BuscarPorId(Guid Id)
        {
            return Mapper.Map<FichaViewModel>(_fichaRepository.BuscarPorId(Id));
        }

        public FichaViewModel Criar(FichaViewModel fichaViewModel)
        {
            var ficha = Mapper.Map<Ficha>(fichaViewModel);
            return Mapper.Map<FichaViewModel>(_fichaRepository.Criar(ficha));
        }

        public bool Deletar(Guid Id)
        {
            return _fichaRepository.Deletar(Id);
        }

        public void Dispose()
        {
            _fichaRepository.Dispose();
        }

        public FichaViewModel Reativar(Guid Id)
        {
            return Mapper.Map<FichaViewModel>(_fichaRepository.Reativar(Id));
        }

        public IEnumerable<FichaViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<FichaViewModel>>(_fichaRepository.TrazerTodosAtivos());
        }

        public IEnumerable<FichaViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<FichaViewModel>>(_fichaRepository.TrazerTodosDeletados());
        }
    }
}