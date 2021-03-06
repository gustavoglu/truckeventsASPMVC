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
        private readonly IMovimentacaoAppService _movimentacaoAppService;

        public FichaAppService()
        {
            _fichaRepository = new Ficha_Repository();
            _movimentacaoAppService = new MovimentacaoAppService();
        }

        public FichaViewModel Atualizar(FichaViewModel fichaViewModel)
        {
            var fichaDTO = _fichaRepository.BuscarPorId(fichaViewModel.Id);
            var ficha = Mapper.Map(fichaViewModel, fichaDTO);
            return Mapper.Map<FichaViewModel>(_fichaRepository.Atualizar(ficha));
        }

        public FichaViewModel Atualizar(FichaViewModel fichaViewModel,double saldoAnterior)
        {
            var fichaDTO = _fichaRepository.BuscarPorId(fichaViewModel.Id);
            var ficha = Mapper.Map(fichaViewModel, fichaDTO);
            return Mapper.Map<FichaViewModel>(_fichaRepository.Atualizar(ficha,saldoAnterior));
        }


        public FichaViewModel BuscarAtivoPorCodigo(string codigo)
        {
            return Mapper.Map<FichaViewModel>(_fichaRepository.Pesquisar(f => f.Codigo == codigo && f.Deletado == false).FirstOrDefault());
        }

        public FichaViewModel BuscarPorCodigo(string codigo)
        {
            return Mapper.Map<FichaViewModel>(_fichaRepository.Pesquisar(f => f.Codigo == codigo).FirstOrDefault());
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

        public FichaViewModel Estornar(FichaViewModel fichaViewModel)
        {
            var fichaDTO = _fichaRepository.BuscarPorId(fichaViewModel.Id);
            var valorAnterior = fichaDTO.Saldo;
            var ficha = Mapper.Map(fichaViewModel, fichaDTO);

            return Mapper.Map<FichaViewModel>(_fichaRepository.Estornar(ficha, valorAnterior));
        }

        public FichaViewModel Reativar(Guid Id)
        {
            return Mapper.Map<FichaViewModel>(_fichaRepository.Reativar(Id));
        }

        public IEnumerable<FichaViewModel> TrazerTodosAtivos(Guid id_evento)
        {
            return Mapper.Map<IEnumerable<FichaViewModel>>(_fichaRepository.TrazerTodosAtivos().Where(f => f.Id_Evento == id_evento).ToList());
        }

        public IEnumerable<FichaViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<FichaViewModel>>(_fichaRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<FichaViewModel> TrazerTodosDeletados(Guid id_evento)
        {
            return Mapper.Map<IEnumerable<FichaViewModel>>(_fichaRepository.TrazerTodosDeletados().Where(f => f.Id_Evento == id_evento).ToList());
        }

        public IEnumerable<FichaViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<FichaViewModel>>(_fichaRepository.TrazerTodosDeletados().ToList());
        }
    }
}