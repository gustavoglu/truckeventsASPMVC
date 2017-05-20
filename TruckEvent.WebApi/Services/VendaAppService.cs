﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TruckEvent.WebApi.Infra;
using TruckEvent.WebApi.Infra.Repository.EntityRepository;
using TruckEvent.WebApi.Infra.Repository.EntityRepository.Interfaces;
using TruckEvent.WebApi.Models;
using TruckEvent.WebApi.Services.Interfaces;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Services
{
    public class VendaAppService : IVendaAppService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IFicha_Repository _ficha_Repository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private readonly SQLContext Db;

        public VendaAppService()
        {
            _vendaRepository = new VendaRepository();
            _ficha_Repository = new Ficha_Repository();
            _movimentacaoRepository = new MovimentacaoRepository();
            Db = new SQLContext();
        }


        public VendaViewModel Atualizar(VendaViewModel vendaViewModel)
        {
            var vendaDTO = _vendaRepository.BuscarPorId(vendaViewModel.Id);
            var venda = Mapper.Map(vendaViewModel, vendaDTO);
            return Mapper.Map<VendaViewModel>(_vendaRepository.Atualizar(venda));
        }

        public VendaViewModel BuscarPorId(Guid Id)
        {
            return Mapper.Map<VendaViewModel>(_vendaRepository.BuscarPorId(Id));
        }

        public VendaViewModel Criar(VendaViewModel vendaViewModel)
        {

            var venda = Mapper.Map<Venda>(vendaViewModel);
            var vendaCriadaDTO = _vendaRepository.Criar(venda);
            var vendaCriadaViewModel = Mapper.Map<VendaViewModel>(vendaCriadaDTO);

            AtualizaFichas(vendaCriadaDTO);

            return vendaCriadaViewModel;
        }

        public bool Deletar(Guid Id)
        {
            return _vendaRepository.Deletar(Id);
        }

        public void Dispose()
        {
            _vendaRepository.Dispose();
        }

        public VendaViewModel Reativar(Guid Id)
        {
            return Mapper.Map<VendaViewModel>(_vendaRepository.Reativar(Id));
        }

        public IEnumerable<VendaViewModel> TrazerTodosAtivos()
        {
            return Mapper.Map<IEnumerable<VendaViewModel>>(_vendaRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<VendaViewModel> TrazerTodosDeletados()
        {
            return Mapper.Map<IEnumerable<VendaViewModel>>(_vendaRepository.TrazerTodosDeletados().ToList());
        }

        public IEnumerable<VendaViewModel> TrazerVendasDeEvento(Guid id_evento)
        {
            var vendas = _vendaRepository.PesquisarAtivos(v => v.Id_evento == id_evento).ToList();
            return Mapper.Map<IEnumerable<VendaViewModel>>(vendas);

        }

        public void AtualizaFichas(Venda venda)
        {
            var fichasAtualizadas = new List<Ficha>();

            //Popula Fichas já atualizadas
            foreach (var item in venda.Venda_Pagamentos)
            {
                foreach (var pagamentoFicha in item.Venda_Pagamento_Fichas)
                {
                    var ficha = _ficha_Repository.BuscarPorId(pagamentoFicha.Id_Ficha.Value);

                    if (ficha != null)
                    {
                        fichasAtualizadas.Add(ficha);
                    }
                }
            }

            //Atualiza Saldo das Fichas
            double? pagamento = venda.TotalVenda.Value;

            foreach (var ficha in fichasAtualizadas)
            {
                if (ficha.Saldo >= pagamento)
                {
                    var descontado = ficha.Saldo - pagamento;
                    double saldoAntigo = ficha.Saldo.Value;
                    ficha.Saldo = descontado;
                    _ficha_Repository.Atualizar(ficha,saldoAntigo);
                    pagamento = 0;
                }
                else
                {
                    var descontado = pagamento - ficha.Saldo;
                    double saldoAntigo = ficha.Saldo.Value;
                    ficha.Saldo = 0;
                    _ficha_Repository.Atualizar(ficha, saldoAntigo);
                    pagamento = descontado;
                }
            }
        }

        public VendaViewModel Calcelar(Guid Id_Venda)
        {
            var pagamento_venda_fichas = Db.Venda_Pagamento_Fichas;
            var venda_pagamentos = Db.Venda_Pagamentos;
            var movimentacoes = Db.Movimentacoes;

            var venda = _vendaRepository.BuscarPorId(Id_Venda);

            if (venda != null)
            {
                //Cancela a venda
                venda.Cancelada = true;

                var vendaAtualizada = _vendaRepository.Atualizar(venda);

                //Estornar as fichas com base na movimentação
                var query = from pagamento_venda_ficha in pagamento_venda_fichas
                            join venda_pagamento in venda_pagamentos on pagamento_venda_ficha.Id_Venda_Pagamento equals venda_pagamento.Id
                            join movimentacao in movimentacoes on pagamento_venda_ficha.Id_Ficha equals movimentacao.Id_Ficha
                            where pagamento_venda_ficha.Deletado == false
                            && venda_pagamento.Deletado == false
                            && movimentacao.Deletado == false
                            && venda_pagamento.Id_venda == Id_Venda
                            select new { Ficha = pagamento_venda_ficha.Ficha, SaldoEstornado = (pagamento_venda_ficha.Ficha.Saldo + movimentacao.Valor) };

                foreach (var estorno in query)
                {
                    var valorAnterior = estorno.Ficha.Saldo;

                    var fichaDTO = _ficha_Repository.BuscarPorId(estorno.Ficha.Id);

                    fichaDTO.Saldo = estorno.SaldoEstornado;

                    _ficha_Repository.Estornar(fichaDTO, valorAnterior);
                }

                return Mapper.Map<VendaViewModel>(vendaAtualizada);

            }

            return null;
        }
    }
}