using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace TruckEvent.WebApi.Infra.Repository.Interfaces
{

    public interface IRepository<T> : IDisposable
    {
        T Criar(T obj);

        T Atualizar(T obj);

        T BuscarPorId(Guid? Id);

        T Reativar(Guid? Id);

        bool Deletar(Guid? Id);

        IEnumerable<T> Pesquisar(Expression<Func<T, bool>> Expressao);

        IEnumerable<T> PesquisarAtivos(Expression<Func<T, bool>> Expressao);

        IEnumerable<T> PesquisarDeletados(Expression<Func<T, bool>> Expressao);

        IEnumerable<T> TrazerTodos();

        IEnumerable<T> TrazerTodosAtivos();

        IEnumerable<T> TrazerTodosDeletados();

        int Salvar();

    }
}