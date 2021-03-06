﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TruckEvent.WebApi.Infra.Repository.EntityRepository.Interfaces;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.Repository.EntityRepository
{
    public class Ficha_Repository : Repository<Ficha>, IFicha_Repository
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public Ficha_Repository() : base()
        {
            _movimentacaoRepository = new MovimentacaoRepository();
        }

        public Ficha Atualizar(Ficha obj, double? valorAntigo)
        {

            var fichaAtualizada = this.Atualizar(obj);

            //Cria Movimentação
            if (valorAntigo != obj.Saldo.Value )
            {
                Movimentacao novaMovimentacao = new Movimentacao(obj.Id.Value,valorAntigo.Value,obj.Saldo.Value,false);
                var movimentacaoCriada = _movimentacaoRepository.Criar(novaMovimentacao);
            }

            return this.BuscarPorId(obj.Id);
            
        }

        public override Ficha BuscarPorId(Guid? Id)
        {
            return dbSet.Find(Id);
        }

        public override IEnumerable<Ficha> TrazerTodos()
        {
            return dbSet;
        }

        public override IEnumerable<Ficha> TrazerTodosAtivos()
        {
            return dbSet.Where(obj => obj.Deletado == false);
        }

        public override IEnumerable<Ficha> TrazerTodosDeletados()
        {
            return dbSet.Where(obj => obj.Deletado == true);
        }

        public override IEnumerable<Ficha> Pesquisar(Expression<Func<Ficha, bool>> Expressao)
        {
            return dbSet.Where(Expressao);
        }

        public override IEnumerable<Ficha> PesquisarAtivos(Expression<Func<Ficha, bool>> Expressao)
        {
            return dbSet.Where(obj => obj.Deletado == false).Where(Expressao);
        }

        public override IEnumerable<Ficha> PesquisarDeletados(Expression<Func<Ficha, bool>> Expressao)
        {
            return dbSet.Where(obj => obj.Deletado == true).Where(Expressao);
        }

        public Ficha Estornar(Ficha obj, double? valorAntigo)
        {
            //Cria Movimentação
            if (valorAntigo != obj.Saldo.Value)
            {
                Movimentacao novaMovimentacao = new Movimentacao(obj.Id.Value,valorAntigo.Value, obj.Saldo.Value, true);
                obj.Movimentacoes.Add(novaMovimentacao);
            }

            return base.Atualizar(obj);
        }

        public Ficha Atualizar(Venda_Pagamento_Ficha venda_Pagamento_Ficha,double pagamento)
        {

            Ficha ficha = this.BuscarPorId(venda_Pagamento_Ficha.Ficha.Id.Value);

            double saldoAnterior = venda_Pagamento_Ficha.Ficha.Saldo.Value;

            double valorInformado = venda_Pagamento_Ficha.ValorInformado;

            if (valorInformado > 0)
            {

                if (valorInformado >= pagamento)
                {

                    ficha.Saldo = ficha.Saldo - pagamento;

                }
                else if (valorInformado < pagamento)
                {

                    ficha.Saldo = ficha.Saldo - valorInformado;

                }
            }
            else
            {
                if (ficha.Saldo >= pagamento)
                {
                    var descontado = ficha.Saldo - pagamento;

                    ficha.Saldo = descontado;
                }
                else
                {
                    var descontado = pagamento - ficha.Saldo;

                    double saldoAntigo = ficha.Saldo.Value;

                    ficha.Saldo = 0;

                }

            }

            return this.Atualizar(ficha, saldoAnterior);

        }
    }
}