﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TruckEvent.WebApi.Infra.Repository.Interfaces;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly SQLContext Db;
        DbSet<T> dbSet;


        public Repository()
        {
            Db = new SQLContext();
            dbSet = Db.Set<T>();

        }

        public T Atualizar(T obj)
        {

            var entry = Db.Entry(obj);

            dbSet.Attach(obj);

            entry.State = EntityState.Modified;

            this.Salvar();

            return BuscarPorId(obj.Id);
        }

        public T BuscarPorId(Guid? Id)
        {
            var usuario = Db.Set<Usuario>().SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);
            var usuarioPrincipal = Db.Set<Usuario>().SingleOrDefault(u => u.Id == usuario.Id_Usuario_Principal);

            if (usuario.Organizador == false && usuario.UserAdmin == false && usuario.UserPrincipal == true)
            {
                return dbSet.SingleOrDefault(t => t.CriadoPor == usuarioPrincipal.UserName && t.Id == Id);
            }
            else if (usuario.Organizador == true || usuario.UserPrincipal == true )
            {
                return dbSet.SingleOrDefault(t => t.CriadoPor == usuario.UserName && t.Id == Id);
            }
            else
            {
                return dbSet.SingleOrDefault(obj => obj.Id == Id);
            }

         
        }

        public T Criar(T obj)
        {
            dbSet.Add(obj);

            Salvar();

            return BuscarPorId(obj.Id);
        }

        public bool Deletar(Guid? Id)
        {
            var obj = BuscarPorId(Id);

            if (obj != null)
            {

                obj.Deletado = true;
                obj.DeletadoPor = HttpContext.Current.User.Identity.Name;
                obj.DeletadoEm = DateTime.Now;
                obj.Deletado = true;

                var atualizado = this.Atualizar(obj);
                if (atualizado != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void Dispose()
        {
            this.Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<T> Pesquisar(Expression<Func<T, bool>> Expressao)
        {
            return dbSet.Where(Expressao);
        }

        public IEnumerable<T> PesquisarAtivos(Expression<Func<T, bool>> Expressao)
        {
            return dbSet.Where(obj => obj.Deletado == false).Where(Expressao);
        }

        public IEnumerable<T> PesquisarDeletados(Expression<Func<T, bool>> Expressao)
        {
            return dbSet.Where(obj => obj.Deletado == true).Where(Expressao);
        }

        public T Reativar(Guid? Id)
        {
            var obj = BuscarPorId(Id);

            if (obj != null)
            {

                obj.Deletado = false;
                obj.DeletadoPor = null;
                obj.DeletadoEm = null;

                var atualizado = this.Atualizar(obj);
                if (atualizado != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public int Salvar()
        {
            return this.Db.SaveChanges();
        }

        public IEnumerable<T> TrazerTodos()
        {
            var usuario = Db.Set<Usuario>().SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);
            var usuarioPrincipal = Db.Set<Usuario>().SingleOrDefault(u => u.Id == usuario.Id_Usuario_Principal);

            if (usuario.Organizador == false && usuario.UserAdmin == false && usuario.UserPrincipal == true)
            {
                return dbSet.Where(t => t.CriadoPor == usuarioPrincipal.UserName);
            }
            else if (usuario.Organizador == true || usuario.UserPrincipal == true)
            {
                return dbSet.Where(t => t.CriadoPor == usuario.UserName);
            }
            else
            {
                return dbSet;
            }

        }

        public IEnumerable<T> TrazerTodosAtivos()
        {
            var usuario = Db.Set<Usuario>().SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);
            var usuarioPrincipal = Db.Set<Usuario>().SingleOrDefault(u => u.Id == usuario.Id_Usuario_Principal);

            if (usuario.Organizador == false && usuario.UserAdmin == false && usuario.UserPrincipal == true)
            {
                return dbSet.Where(t => t.CriadoPor == usuarioPrincipal.UserName && t.Deletado == false);
            }
            else if (usuario.Organizador == true || usuario.UserPrincipal == true)
            {
                return dbSet.Where(t => t.CriadoPor == usuario.UserName && t.Deletado == false);
            }
            else
            {

                return dbSet.Where(obj => obj.Deletado == false);
            }
        }

        public IEnumerable<T> TrazerTodosDeletados()
        {

            var usuario = Db.Set<Usuario>().SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);
            var usuarioPrincipal = Db.Set<Usuario>().SingleOrDefault(u => u.Id == usuario.Id_Usuario_Principal);

            if (usuario.Organizador == false && usuario.UserAdmin == false && usuario.UserPrincipal == true)
            {
                return dbSet.Where(t => t.CriadoPor == usuarioPrincipal.UserName && t.Deletado == true);
            }
            else if (usuario.Organizador == true || usuario.UserPrincipal == true)
            {
                return dbSet.Where(t => t.CriadoPor == usuario.UserName && t.Deletado == true);
            }
            else
            {

                return dbSet.Where(obj => obj.Deletado == true);
            }
        }
    }
    
}