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

        public virtual T Atualizar(T obj)
        {

            var entry = Db.Entry(obj);

            dbSet.Attach(obj);

            entry.State = EntityState.Modified;

            this.Salvar();

            return BuscarPorId(obj.Id);
        }

        public virtual T BuscarPorId(Guid? Id)
        {
           
            var usuario = Db.Set<Usuario>().SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);
            var usuarioPrincipal = Db.Set<Usuario>().SingleOrDefault(u => u.Id == usuario.Id_Usuario_Principal);

            if (usuario.Organizador == false && usuario.UserAdmin == false && usuario.UserPrincipal == true)
            {
                return
                (from entidades in dbSet
                join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                where usuarios.Id_Usuario_Principal == usuario.Id || usuarios.Id == usuario.Id
                && entidades.Id == Id
                select entidades).SingleOrDefault();

            }
            else if (usuario.Organizador == true || usuario.UserPrincipal == false)
            {
                return dbSet.SingleOrDefault(t => t.CriadoPor == usuario.UserName && t.Id == Id);
            }
            else if (usuario.Organizador == false && usuario.UserAdmin == false && usuario.UserPrincipal == false)
            {
                return
                (from entidades in dbSet
                join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                where usuarios.Id_Usuario_Principal == usuario.Id_Usuario_Principal || usuarios.Id == usuario.Id_Usuario_Principal || usuarios.Id == usuario.Id
                && entidades.Id == Id
                select entidades).SingleOrDefault();

            }
            else
            {
                return dbSet.SingleOrDefault(t => t.Id == Id);
            }

        }

        public virtual T Criar(T obj)
        {
           
            //var usuario = Db.Users.SingleOrDefault(u => u.Id == "9d011db7-137f-492f-aadf-b7cbbfebdf26");
            //
            //var evento = new Evento() { Descricao = "Teste", DataInicio = new DateTime(2015, 05, 25), DataFim = new DateTime(2015, 05, 25), Usuario_Organizador = usuario };//Id_usuario_organizador = "9d011db7-137f-492f-aadf-b7cbbfebdf26" };
            //
            //var produto= new Produto() { Descricao = "ProdutoTeste", Id_produto_cor = Guid.Parse("FBC4DA29-503E-4928-B000-B39BCC0B4AAA"), Id_produto_tipo = Guid.Parse("44CF4EEF-71A9-480D-B1D4-963F835244BE"), Valor = 5, Numero = 1 };
            //var add = Db.Produtos.Add(produto);


            //usuario.Eventos.Add(evento);

           // var teste = Db.Set<Evento>().Add(evento);

            

            //var teste = dbSet.Add(obj);
             var teste = dbSet.Add(obj);

            Salvar();

            return BuscarPorId(obj.Id);
        }

        public virtual bool Deletar(Guid? Id)
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

        public virtual IEnumerable<T> Pesquisar(Expression<Func<T, bool>> Expressao)
        {
            var usuario = Db.Set<Usuario>().SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);
            var usuarioPrincipal = Db.Set<Usuario>().SingleOrDefault(u => u.Id == usuario.Id_Usuario_Principal);

            if (usuario.Organizador == false && usuario.UserAdmin == false && usuario.UserPrincipal == true)
            {
                return
                (from entidades in dbSet
                join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                where usuarios.Id_Usuario_Principal == usuario.Id || usuarios.Id == usuario.Id
                select entidades).Where(Expressao);

            }
            else if (usuario.Organizador == true || usuario.UserPrincipal == false)
            {
                return dbSet.Where(t => t.CriadoPor == usuario.UserName).Where(Expressao);
            }
            else if (usuario.Organizador == false && usuario.UserAdmin == false && usuario.UserPrincipal == false)
            {
                return
                (from entidades in dbSet
                join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                where usuarios.Id_Usuario_Principal == usuario.Id_Usuario_Principal || usuarios.Id == usuario.Id_Usuario_Principal || usuarios.Id == usuario.Id
                select entidades).Where(Expressao);

            }
            else
            {
                return dbSet.Where(Expressao);
            }


        }

        public virtual IEnumerable<T> PesquisarAtivos(Expression<Func<T, bool>> Expressao)
        {
            var usuario = Db.Set<Usuario>().SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);
            var usuarioPrincipal = Db.Set<Usuario>().SingleOrDefault(u => u.Id == usuario.Id_Usuario_Principal);

            if (usuario.Organizador == false && usuario.UserAdmin == false && usuario.UserPrincipal == true)
            {
                return
                (from entidades in dbSet
                 join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                 where usuarios.Id_Usuario_Principal == usuario.Id || usuarios.Id == usuario.Id
                 && entidades.Deletado == false
                 select entidades).Where(Expressao);

            }
            else if (usuario.Organizador == true || usuario.UserPrincipal == false)
            {
                return dbSet.Where(t => t.CriadoPor == usuario.UserName && t.Deletado == false).Where(Expressao);
            }
            else if (usuario.Organizador == false && usuario.UserAdmin == false && usuario.UserPrincipal == false)
            {
                return
                (from entidades in dbSet
                 join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                 where usuarios.Id_Usuario_Principal == usuario.Id_Usuario_Principal || usuarios.Id == usuario.Id_Usuario_Principal || usuarios.Id == usuario.Id
                     && entidades.Deletado == false
                 select entidades).Where(Expressao);

            }
            else
            {
                return dbSet.Where(t => t.Deletado == false).Where(Expressao);
            }
        }

        public virtual IEnumerable<T> PesquisarDeletados(Expression<Func<T, bool>> Expressao)
        {
            var usuario = Db.Set<Usuario>().SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);
            var usuarioPrincipal = Db.Set<Usuario>().SingleOrDefault(u => u.Id == usuario.Id_Usuario_Principal);

            if (usuario.Organizador == false && usuario.UserAdmin == false && usuario.UserPrincipal == true)
            {
                return
                (from entidades in dbSet
                 join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                 where usuarios.Id_Usuario_Principal == usuario.Id || usuarios.Id == usuario.Id
                 && entidades.Deletado == true
                 select entidades).Where(Expressao);

            }
            else if (usuario.Organizador == true || usuario.UserPrincipal == false)
            {
                return dbSet.Where(t => t.CriadoPor == usuario.UserName && t.Deletado == true).Where(Expressao);
            }
            else if (usuario.Organizador == false && usuario.UserAdmin == false && usuario.UserPrincipal == false)
            {
                return
                (from entidades in dbSet
                 join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                 where usuarios.Id_Usuario_Principal == usuario.Id_Usuario_Principal || usuarios.Id == usuario.Id_Usuario_Principal || usuarios.Id == usuario.Id
                     && entidades.Deletado == true
                 select entidades).Where(Expressao);

            }
            else
            {
                return dbSet.Where(t => t.Deletado == true).Where(Expressao);
            }
        }

        public virtual T Reativar(Guid? Id)
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

        public virtual IEnumerable<T> TrazerTodos()
        {
            var usuario = Db.Set<Usuario>().SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);
            var usuarioPrincipal = Db.Set<Usuario>().SingleOrDefault(u => u.Id == usuario.Id_Usuario_Principal);

            if (usuario.Organizador == false && usuario.UserAdmin == false && usuario.UserPrincipal == true)
            {
                return
                from entidades in dbSet
                join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                where usuarios.Id_Usuario_Principal == usuario.Id || usuarios.Id == usuario.Id
                select entidades;

            }
            else if (usuario.Organizador == true || usuario.UserPrincipal == false)
            {
                return dbSet.Where(t => t.CriadoPor == usuario.UserName);
            }
            else if (usuario.Organizador == false && usuario.UserAdmin == false && usuario.UserPrincipal == false)
            {
                return
                from entidades in dbSet
                join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                where usuarios.Id_Usuario_Principal == usuario.Id_Usuario_Principal || usuarios.Id == usuario.Id_Usuario_Principal || usuarios.Id == usuario.Id
                select entidades;

            }
            else
            {
                return dbSet;
            }

        }

        public virtual IEnumerable<T> TrazerTodosAtivos()
        {
            var usuario = Db.Set<Usuario>().SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);
            var usuarioPrincipal = Db.Set<Usuario>().SingleOrDefault(u => u.Id == usuario.Id_Usuario_Principal);
            
            if (usuario.Organizador == false && usuario.UserAdmin == false && usuario.UserPrincipal == true) // Dono da Loja
            {
                return
                from entidades in dbSet
                join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                where usuarios.Id_Usuario_Principal == usuario.Id || usuarios.Id == usuario.Id
                && entidades.Deletado == false
                select entidades;

            }
            else if (usuario.Organizador == true || usuario.UserPrincipal == false) // Orgazanidor
            {
                return dbSet.Where(t => t.CriadoPor == usuario.UserName && t.Deletado == false);
            }
            else if (usuario.Organizador == false && usuario.UserAdmin == false && usuario.UserPrincipal == false) // Funcionario
            {
               return
               from entidades in dbSet
               join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
               where usuarios.Id_Usuario_Principal == usuario.Id_Usuario_Principal || usuarios.Id == usuario.Id_Usuario_Principal || usuarios.Id == usuario.Id
               && entidades.Deletado == false
               select entidades;
            } 
            else
            {

                return dbSet.Where(obj => obj.Deletado == false);
            }
        }

        public virtual IEnumerable<T> TrazerTodosDeletados()
        {

            var usuario = Db.Set<Usuario>().SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);
            var usuarioPrincipal = Db.Set<Usuario>().SingleOrDefault(u => u.Id == usuario.Id_Usuario_Principal);

            if (usuario.Organizador == false && usuario.UserAdmin == false && usuario.UserPrincipal == true)
            {
                return
                from entidades in dbSet
                join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                where usuarios.Id_Usuario_Principal == usuario.Id || usuarios.Id == usuario.Id
                && entidades.Deletado == true
                select entidades;
            }
            else if (usuario.Organizador == true || usuario.UserPrincipal == true)
            {
                return dbSet.Where(t => t.CriadoPor == usuario.UserName && t.Deletado == true);
            }
            else if (usuario.Organizador == false && usuario.UserAdmin == false && usuario.UserPrincipal == false) // Funcionario)
            {
                return
                from entidades in dbSet
                join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                where usuarios.Id_Usuario_Principal == usuario.Id_Usuario_Principal || usuarios.Id == usuario.Id_Usuario_Principal || usuarios.Id == usuario.Id
                && entidades.Deletado == true
                select entidades;
            }
            else
            {

                return dbSet.Where(obj => obj.Deletado == true);
            }
        }
    }

}