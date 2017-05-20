using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading;
using System.Web;
using TruckEvent.WebApi.Infra.Repository.EntityRepository;
using TruckEvent.WebApi.Infra.Repository.Interfaces;
using TruckEvent.WebApi.Models;
using TruckEvent.WebApi.Services;

namespace TruckEvent.WebApi.Infra.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly SQLContext Db;
        protected DbSet<T> dbSet;
        protected ClaimsPrincipal claimsPrincipal { get { return (ClaimsPrincipal)Thread.CurrentPrincipal; } }
        protected string usuarioLogado_id { get {return claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "id_usuario").Value; } }
        protected string usuarioLogado_id_usuario_principal { get { return claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "id_usuario_principal").Value; } }
        protected string usuarioLogado_id_usuario_organizador { get { return claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "id_usuario_organizador").Value; } }
        protected bool usuarioLogado_organizador { get { return bool.Parse(claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "organizador").Value); } }
        protected bool usuarioLogado_caixaevento { get { return bool.Parse(claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "caixaevento").Value); } }
        protected bool usuarioLogado_usuarioprincipal { get { return bool.Parse(claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "usuarioprincipal").Value); } }
        protected string usuarioLogado_username { get {return  claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value ?? HttpContext.Current.User.Identity.Name; } }


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

            return dbSet.Find(obj.Id);
        }

        public virtual T BuscarPorId(Guid? Id)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {

                if (usuarioLogado_usuarioprincipal)
                {
                    return
                    (from entidades in dbSet
                     join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                     where usuarios.Id_Usuario_Principal == usuarioLogado_id || usuarios.Id == usuarioLogado_id
                     && entidades.Id == Id
                     select entidades).FirstOrDefault();

                }
                else if (usuarioLogado_organizador)
                {
                    return dbSet.SingleOrDefault(t => t.CriadoPor == usuarioLogado_username && t.Id == Id);
                }
                else if (usuarioLogado_id_usuario_principal.Any())
                {
                    return
                    (from entidades in dbSet
                     join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                     where usuarios.Id_Usuario_Principal == usuarioLogado_id_usuario_principal|| usuarios.Id == usuarioLogado_id_usuario_principal || usuarios.Id == usuarioLogado_id
                     && entidades.Id == Id
                     select entidades).FirstOrDefault();

                }
                else if (usuarioLogado_caixaevento)
                {
                    return
                    (from entidades in dbSet
                    join usuarioEvento in Db.Set<Evento_Usuario>() on entidades.CriadoPor equals usuarioEvento.Usuario.UserName
                    join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                    where usuarioEvento.Evento.Id_organizador == usuarioLogado_id_usuario_organizador
                     || usuarios.id_usuario_organizador == usuarioLogado_id_usuario_organizador
                     || entidades.CriadoPor == usuarioLogado_id
                     && entidades.Deletado == false
                     && entidades.Id == Id
                    select entidades).FirstOrDefault();
                }
                else
                {
                    return dbSet.FirstOrDefault(t => t.Id == Id);
                }
            }
            else
            {
                return dbSet.FirstOrDefault(t => t.Id == Id);
            }

        }

        public virtual T Criar(T obj)
        {

            var entity = dbSet.Add(obj);

            Salvar();

            return dbSet.Find(obj.Id);
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

            if (usuarioLogado_usuarioprincipal)
            {
                return
                (from entidades in dbSet
                 join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                 where usuarios.Id_Usuario_Principal == usuarioLogado_id_usuario_principal || usuarios.Id == usuarioLogado_id_usuario_principal
                 select entidades).Where(Expressao);

            }
            else if (usuarioLogado_organizador)
            {
                return dbSet.Where(t => t.CriadoPor == usuarioLogado_username).Where(Expressao);
            }
            else if (usuarioLogado_id_usuario_principal.Any())
            {
                return
                (from entidades in dbSet
                 join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                 where usuarios.Id_Usuario_Principal == usuarioLogado_id_usuario_principal || usuarios.Id == usuarioLogado_id_usuario_principal || usuarios.Id == usuarioLogado_id
                 select entidades).Where(Expressao);

            }
            //Caixa
            else if (usuarioLogado_caixaevento)
            {
                return
                (from entidades in dbSet
                 join usuarioEvento in Db.Set<Evento_Usuario>() on entidades.CriadoPor equals usuarioEvento.Usuario.UserName
                 join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                 where usuarioEvento.Evento.Id_organizador == usuarioLogado_id_usuario_organizador
                  || usuarios.id_usuario_organizador == usuarioLogado_id_usuario_organizador
                  || entidades.CriadoPor == usuarioLogado_username
                 select entidades).Where(Expressao);
            }
            else
            {
                return dbSet.Where(Expressao);
            }


        }

        public virtual IEnumerable<T> PesquisarAtivos(Expression<Func<T, bool>> Expressao)
        {

            if (usuarioLogado_usuarioprincipal)
            {
                return
                (from entidades in dbSet
                 join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                 where usuarios.Id_Usuario_Principal == usuarioLogado_id|| usuarios.Id == usuarioLogado_id
                 && entidades.Deletado == false
                 select entidades).Where(Expressao);

            }
            else if (usuarioLogado_organizador)
            {
                return dbSet.Where(t => t.CriadoPor == usuarioLogado_username && t.Deletado == false).Where(Expressao);
            }
            else if (usuarioLogado_id_usuario_principal.Any())
            {
                return
                (from entidades in dbSet
                 join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                 where usuarios.Id_Usuario_Principal == usuarioLogado_id_usuario_principal || usuarios.Id == usuarioLogado_id_usuario_principal  || usuarios.Id == usuarioLogado_id
                     && entidades.Deletado == false
                 select entidades).Where(Expressao);

            }
            //Caixa
            else if (usuarioLogado_caixaevento)
            {
                return
                (from entidades in dbSet
                 join usuarioEvento in Db.Set<Evento_Usuario>() on entidades.CriadoPor equals usuarioEvento.Usuario.UserName
                 join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                 where usuarioEvento.Evento.Id_organizador == usuarioLogado_id_usuario_organizador
                  || usuarios.id_usuario_organizador == usuarioLogado_id_usuario_organizador
                  || entidades.CriadoPor == usuarioLogado_username
                 select entidades).Where(Expressao);
            }
            else
            {
                return dbSet.Where(t => t.Deletado == false).Where(Expressao);
            }
        }

        public virtual IEnumerable<T> PesquisarDeletados(Expression<Func<T, bool>> Expressao)
        {
         
            if (usuarioLogado_usuarioprincipal)
            {
                return
                (from entidades in dbSet
                 join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                 where usuarios.Id_Usuario_Principal == usuarioLogado_id || usuarios.Id == usuarioLogado_id
                 && entidades.Deletado == true
                 select entidades).Where(Expressao);

            }
            else if (usuarioLogado_organizador)
            {
                return dbSet.Where(t => t.CriadoPor == usuarioLogado_username && t.Deletado == true).Where(Expressao);
            }
            else if (usuarioLogado_id_usuario_principal.Any())
            {
                return
                (from entidades in dbSet
                 join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                 where usuarios.Id_Usuario_Principal == usuarioLogado_id_usuario_principal || usuarios.Id == usuarioLogado_id_usuario_principal || usuarios.Id == usuarioLogado_id
                     && entidades.Deletado == true
                 select entidades).Where(Expressao);

            }
            //Caixa
            else if (usuarioLogado_caixaevento)
            {
                return
                (from entidades in dbSet
                 join usuarioEvento in Db.Set<Evento_Usuario>() on entidades.CriadoPor equals usuarioEvento.Usuario.UserName
                 join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                 where usuarioEvento.Evento.Id_organizador == usuarioLogado_id_usuario_organizador
                  || usuarios.id_usuario_organizador == usuarioLogado_id_usuario_organizador
                  || entidades.CriadoPor == usuarioLogado_username
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

            if (usuarioLogado_usuarioprincipal)
            {
                return
                from entidades in dbSet
                join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                where usuarios.Id_Usuario_Principal == usuarioLogado_id || usuarios.Id == usuarioLogado_id
                select entidades;

            }
            else if (usuarioLogado_organizador)
            {
                return dbSet.Where(t => t.CriadoPor == usuarioLogado_username);
            }
            else if (usuarioLogado_id_usuario_principal.Any())
            {
                return
                from entidades in dbSet
                join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                where usuarios.Id_Usuario_Principal == usuarioLogado_id_usuario_principal || usuarios.Id == usuarioLogado_id_usuario_principal || usuarios.Id == usuarioLogado_id
                select entidades;

            }
            //Caixa
            else if (usuarioLogado_caixaevento)
            {
                return
                from entidades in dbSet
                join usuarioEvento in Db.Set<Evento_Usuario>() on entidades.CriadoPor equals usuarioEvento.Usuario.UserName
                join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                where usuarioEvento.Evento.Id_organizador == usuarioLogado_id_usuario_organizador || usuarios.id_usuario_organizador == usuarioLogado_id_usuario_organizador
                 || entidades.CriadoPor == usuarioLogado_username
                select entidades;
            }
            else
            {
                return dbSet;
            }

        }

        public virtual IEnumerable<T> TrazerTodosAtivos()
        {
         
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {

                if (usuarioLogado_usuarioprincipal) // Dono da Loja
                {
                    var lista = (from entidades in dbSet
                                 join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName //usuarioLogado_username
                                 where usuarios.Id_Usuario_Principal == usuarioLogado_id || usuarios.Id == usuarioLogado_id
                                 && entidades.Deletado == false
                                 select entidades);

                    return lista;
                    

                }
                else if (usuarioLogado_organizador) // Orgazanidor
                {
                    return dbSet.Where(t => t.CriadoPor == usuarioLogado_username && t.Deletado == false);
                }
                else if (usuarioLogado_id_usuario_principal.Any()) // Funcionario
                {
                    var lista = from entidades in dbSet
                                join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                                where usuarios.Id_Usuario_Principal == usuarioLogado_id_usuario_principal || usuarios.Id == usuarioLogado_id_usuario_principal || usuarios.Id == usuarioLogado_id
                                && entidades.Deletado == false
                                select entidades;


                    return lista;
                                    } //Caixa
                else if (usuarioLogado_caixaevento)
                {
                    return
                    from entidades in dbSet
                    join usuarioEvento in Db.Set<Evento_Usuario>() on entidades.CriadoPor equals usuarioEvento.Usuario.UserName
                    join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                    where usuarioEvento.Evento.Id_organizador == usuarioLogado_id_usuario_organizador
                     || usuarios.id_usuario_organizador == usuarioLogado_id_usuario_organizador
                     || entidades.CriadoPor == usuarioLogado_id
                     && entidades.Deletado == false
                    select entidades;
                }
                else
                {

                    return dbSet.Where(obj => obj.Deletado == false);
                }
            }
            else
            {
                return dbSet.Where(obj => obj.Deletado == false);
            }
        }

        public virtual IEnumerable<T> TrazerTodosDeletados()
        {

            if (!usuarioLogado_id_usuario_principal.Any())
            {
                return
                from entidades in dbSet
                join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                where usuarios.Id_Usuario_Principal == usuarioLogado_id|| usuarios.Id == usuarioLogado_id
                && entidades.Deletado == true
                select entidades;
            }
            else if (usuarioLogado_organizador)
            {
                return dbSet.Where(t => t.CriadoPor == usuarioLogado_username && t.Deletado == true);
            }
            else if (usuarioLogado_id_usuario_principal.Any()) // Funcionario)
            {
                return
                from entidades in dbSet
                join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                where usuarios.Id_Usuario_Principal == usuarioLogado_id_usuario_principal || usuarios.Id == usuarioLogado_id_usuario_principal || usuarios.Id == usuarioLogado_id
                && entidades.Deletado == true
                select entidades;
            }
            //Caixa
            else if (usuarioLogado_id_usuario_organizador.Any())
            {
                return
                from entidades in dbSet
                join usuarioEvento in Db.Set<Evento_Usuario>() on entidades.CriadoPor equals usuarioEvento.Usuario.UserName
                join usuarios in Db.Set<Usuario>() on entidades.CriadoPor equals usuarios.UserName
                where usuarioEvento.Evento.Id_organizador == usuarioLogado_id_usuario_organizador
                 || usuarios.id_usuario_organizador == usuarioLogado_id_usuario_organizador
                 || entidades.CriadoPor == usuarioLogado_username
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