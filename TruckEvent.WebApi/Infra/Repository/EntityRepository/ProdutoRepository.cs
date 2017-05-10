using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TruckEvent.WebApi.Infra.Repository.EntityRepository.Interfaces;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.Repository.EntityRepository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public override Produto BuscarPorId(Guid? Id)
        {
            return base.BuscarPorId(Id);
        }

        public override IEnumerable<Produto> Pesquisar(Expression<Func<Produto, bool>> Expressao)
        {
            return base.Pesquisar(Expressao);
        }

        public override IEnumerable<Produto> PesquisarAtivos(Expression<Func<Produto, bool>> Expressao)
        {
            return base.PesquisarAtivos(Expressao);
        }

        public override IEnumerable<Produto> PesquisarDeletados(Expression<Func<Produto, bool>> Expressao)
        {
            return base.PesquisarDeletados(Expressao);
        }

        public override Produto Atualizar(Produto obj)
        {
            return base.Atualizar(obj);
        }
    }
}