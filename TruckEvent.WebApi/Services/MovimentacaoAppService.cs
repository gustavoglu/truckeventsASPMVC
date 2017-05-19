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
    public class MovimentacaoAppService : IMovimentacaoAppService
    {
        IMovimentacaoRepository _movimentacaoRepository;


        public MovimentacaoAppService()
        {
            _movimentacaoRepository = new MovimentacaoRepository();
        }
        public MovimentacaoViewModel Atualizar(MovimentacaoViewModel movimentacaoViewModel)
        {
            var movimentacaoDTO = _movimentacaoRepository.BuscarPorId(movimentacaoViewModel.Id);
            var movimentacao = Mapper.Map(movimentacaoViewModel, movimentacaoDTO);

            return Mapper.Map<MovimentacaoViewModel>(_movimentacaoRepository.Atualizar(movimentacao));
        }

        public MovimentacaoViewModel BuscarPorId(Guid Id)
        {
            return Mapper.Map<MovimentacaoViewModel>(_movimentacaoRepository.BuscarPorId(Id));
        }

        public MovimentacaoViewModel Criar(MovimentacaoViewModel movimentacaoViewModel)
        {
            var movimentacao = Mapper.Map<Movimentacao>(movimentacaoViewModel);
            return Mapper.Map<MovimentacaoViewModel>(movimentacao);
        }

        public bool Deletar(Guid Id)
        {
            return _movimentacaoRepository.Deletar(Id);
        }

        public void Dispose()
        {
            _movimentacaoRepository.Dispose();
        }

        public MovimentacaoViewModel Reativar(Guid Id)
        {
            return Mapper.Map<MovimentacaoViewModel>(_movimentacaoRepository.Reativar(Id));
        }

        public IEnumerable<MovimentacaoViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<MovimentacaoViewModel>>(_movimentacaoRepository.TrazerTodosAtivos());
        }

        public IEnumerable<MovimentacaoViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<MovimentacaoViewModel>>(_movimentacaoRepository.TrazerTodosDeletados());
        }

        public static MovimentacaoViewModel CriaMovimentacao(FichaViewModel Ficha, double valorAntigo, double valorNovo, bool estorno)
        {
            MovimentacaoViewModel movimentacao = new MovimentacaoViewModel() { Id_Ficha = Ficha.Id.Value };

            if (valorAntigo > valorNovo)
            {
                movimentacao.Valor = valorAntigo - valorNovo;
                movimentacao.Tipo_Mov = ViewModels.Tipo_Mov.Saida;
            }
            else if (valorAntigo < valorNovo)
            {

                if (estorno == true)
                {
                    movimentacao.Valor = valorNovo - valorAntigo;
                    movimentacao.Tipo_Mov = ViewModels.Tipo_Mov.Estorno;
                }

                else
                {
                    movimentacao.Valor = valorNovo - valorAntigo;
                    movimentacao.Tipo_Mov = ViewModels.Tipo_Mov.Entrada;
                }
            }

            return movimentacao;
        }

    }
}