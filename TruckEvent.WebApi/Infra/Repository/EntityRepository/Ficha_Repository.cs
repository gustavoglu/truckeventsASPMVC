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
    }
}