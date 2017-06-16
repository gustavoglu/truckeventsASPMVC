using AutoMapper;
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
        private readonly IVenda_PagamentoRepository _venda_PagamentoRepository;
        private readonly IVenda_PagamentoAppService _venda_PagamentoAppService;
        private readonly IVenda_Pagamento_FichaAppService _venda_Pagamento_FichaAppService;
        private readonly IVenda_ProdutoAppService _venda_ProdutoAppService;
        private readonly SQLContext Db;

        public VendaAppService()
        {
            _vendaRepository = new VendaRepository();
            _ficha_Repository = new Ficha_Repository();
            _movimentacaoRepository = new MovimentacaoRepository();
            _venda_PagamentoRepository = new Venda_PagamentoRepository();
            _venda_PagamentoAppService = new Venda_PagamentoAppService();
            _venda_Pagamento_FichaAppService = new Venda_Pagamento_FichaAppService();
            _venda_ProdutoAppService = new Venda_ProdutoAppService();

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

            if (vendaViewModel.Venda_Produtos.Count > 0)
            {
                AdicionaVenda_Produtos(vendaCriadaDTO.Id.Value, vendaViewModel.Venda_Produtos);
            }

            if (vendaViewModel.Venda_Pagamentos.Count > 0)
            {
                AdicionaVenda_Pagamentos(vendaCriadaDTO.Id.Value, vendaViewModel.Venda_Pagamentos);
            }

            AtualizaFichas(vendaCriadaDTO.Id.Value);

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


        private void AdicionaVenda_Pagamentos(Guid Id_Venda,ICollection<Venda_PagamentoViewModel> Venda_Pagamentos)
        {
            // Cria Venda_Pagamentos
            foreach (var venda_Pagamento in Venda_Pagamentos)
            {
                venda_Pagamento.Id_venda = Id_Venda;

                var venda_PagamentoCriado = _venda_PagamentoAppService.Criar(venda_Pagamento);

                if (venda_Pagamento.Venda_Pagamento_Fichas.Count > 0)
                {
                    //Cria Venda_Pagamento_Fichas
                    foreach (var venda_Pagamento_Ficha in venda_Pagamento.Venda_Pagamento_Fichas)
                    {
                        venda_Pagamento_Ficha.Id_Ficha = venda_Pagamento_Ficha.Ficha.Id.Value;

                        venda_Pagamento_Ficha.Id_Venda_Pagamento = venda_PagamentoCriado.Id;

                        _venda_Pagamento_FichaAppService.Criar(venda_Pagamento_Ficha);
                    }
                }
            }



        }

        private void AdicionaVenda_Produtos(Guid Id_Venda,ICollection<Venda_ProdutoViewModel> Venda_Produtos)
        {
            if (Venda_Produtos.Count > 0)
            {
                foreach (var venda_Produto in Venda_Produtos)
                {
                    venda_Produto.Id_Venda = Id_Venda;

                    venda_Produto.Id_produto = venda_Produto.Produto.Id.Value;

                    _venda_ProdutoAppService.Criar(venda_Produto);
                }
            }
        }

        public void AtualizaFichas(Guid Id_Venda)
        {
    
            var vendaPagamentos = _venda_PagamentoRepository.TrazerTodosAtivos().ToList().Where(vp => vp.Id_venda == Id_Venda);

            var venda = vendaPagamentos.FirstOrDefault().Venda;

            var pagamentos = from vendaPagamento in vendaPagamentos
                             from pagamentoFicha in vendaPagamento.Venda_Pagamento_Fichas
                             select pagamentoFicha;

            double countPagamentosInformados = pagamentos.Sum(p => p.ValorInformado);

            //Se existir pagamentos com valor já informados
            if (countPagamentosInformados > 0)
            {

                var vendaTotal = venda.TotalVenda.Value;

                var pagamentosComValorInformado = from pagamentoInf in pagamentos
                                                  where pagamentoInf.ValorInformado > 0 && pagamentoInf.Ficha.Saldo.Value > 0
                                                  select new { Ficha = pagamentoInf.Ficha, ValorDescontado = pagamentoInf.ValorInformado };

                //Atualiza fichas com valor já informado
                foreach (var item in pagamentosComValorInformado)
                {
                    var fichaDTO = _ficha_Repository.BuscarPorId(item.Ficha.Id);

                    double? saldoAntigo = 0;

                    if (vendaTotal > 0)
                    {

                        if (item.ValorDescontado >= vendaTotal)
                        {
                            saldoAntigo = fichaDTO.Saldo;

                            fichaDTO.Saldo = fichaDTO.Saldo - vendaTotal;

                            vendaTotal = 0;

                        }
                        else if (item.ValorDescontado < vendaTotal)
                        {
                            saldoAntigo = item.Ficha.Saldo;

                            fichaDTO.Saldo = fichaDTO.Saldo - item.ValorDescontado;

                            vendaTotal = vendaTotal - item.ValorDescontado;

                        }

                        _ficha_Repository.Atualizar(fichaDTO, saldoAntigo.Value);
                    }
                }

                // Se ainda existir valor no total da venda, desconta das outras fichas sem valor informado
                if (vendaTotal > 0)
                {
                    var fichasSemValorInformado = from pagamento in vendaPagamentos
                                                  from pagamentoFicha in pagamento.Venda_Pagamento_Fichas
                                                  where pagamentoFicha.ValorInformado == 0 && pagamentoFicha.Ficha.Saldo.Value > 0
                                                  select pagamentoFicha.Ficha;


                    foreach (var ficha in fichasSemValorInformado)
                    {
                        var fichaDTO = _ficha_Repository.BuscarPorId(ficha.Id);

                        if (fichaDTO.Saldo >= vendaTotal)
                        {
                            var descontado = fichaDTO.Saldo - vendaTotal;
                            double saldoAntigo = fichaDTO.Saldo.Value;
                            fichaDTO.Saldo = descontado;
                            _ficha_Repository.Atualizar(fichaDTO, saldoAntigo);
                            vendaTotal = 0;
                        }
                        else
                        {
                            var descontado = vendaTotal - fichaDTO.Saldo;
                            double saldoAntigo = fichaDTO.Saldo.Value;
                            fichaDTO.Saldo = 0;
                            _ficha_Repository.Atualizar(fichaDTO, saldoAntigo);
                            vendaTotal = descontado.Value;
                        }
                    }

                }
            }
            else if (countPagamentosInformados == 0)
            {

                var fichasAtualizadas = from pagamentosInf in vendaPagamentos
                                        from pagamentosFicha in pagamentosInf.Venda_Pagamento_Fichas
                                        where pagamentosFicha.Ficha.Saldo.Value > 0
                                        select pagamentosFicha.Ficha;

                //Atualiza Saldo das Fichas
                double? pagamento = venda.TotalVenda.Value;

                foreach (var ficha in fichasAtualizadas)
                {
                    var fichaDTO = _ficha_Repository.BuscarPorId(ficha.Id);

                    if (fichaDTO.Saldo >= pagamento)
                    {
                        var descontado = fichaDTO.Saldo - pagamento;
                        double saldoAntigo = fichaDTO.Saldo.Value;
                        fichaDTO.Saldo = descontado;
                        _ficha_Repository.Atualizar(fichaDTO, saldoAntigo);
                        pagamento = 0;
                    }
                    else
                    {
                        var descontado = pagamento - fichaDTO.Saldo;
                        double saldoAntigo = fichaDTO.Saldo.Value;
                        fichaDTO.Saldo = 0;
                        _ficha_Repository.Atualizar(fichaDTO, saldoAntigo);
                        pagamento = descontado;
                    }
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