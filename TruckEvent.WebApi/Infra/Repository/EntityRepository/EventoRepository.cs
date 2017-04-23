using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading;
using System.Web;
using TruckEvent.WebApi.Infra.Repository.EntityRepository.Interfaces;
using TruckEvent.WebApi.Models;

namespace TruckEvent.WebApi.Infra.Repository.EntityRepository
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {

        public override Evento BuscarPorId(Guid? Id)
        {
            return TrazerTodos().SingleOrDefault(t => t.Id == Id);
        }

        public override IEnumerable<Evento> TrazerTodos()
        {
            var usuario = Db.Set<Usuario>().SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);
            var usuarioPrincipal = Db.Set<Usuario>().SingleOrDefault(u => u.Id == usuario.Id_Usuario_Principal);

            if (usuario.UserPrincipal == true)
            {
                return
                from entidades in dbSet
                join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                where eventoUsuario.Usuario.Id == usuario.Id
                select entidades;

            }
            else if (usuario.Organizador == true)
            {
                return dbSet.Where(t => t.CriadoPor == usuario.UserName);
            }
            else if (usuario.UserPrincipal == false)
            {
               return
               from entidades in dbSet
               join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
               join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
               where eventoUsuario.Usuario.Id == usuario.Usuario_Principal.Id
               select entidades;

            }
            else if (usuario.CaixaEvento == true)
            {
               return
               from entidades in dbSet
               join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
               join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
               where usuarios.Usuario_Organizador.Id == usuario.Usuario_Organizador.Id
               select entidades;
            }
            else
            {
                return dbSet;
            }

        }

        public override IEnumerable<Evento> TrazerTodosAtivos()
        {
            var usuario = Db.Set<Usuario>().SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);
            var usuarioPrincipal = Db.Set<Usuario>().SingleOrDefault(u => u.Id == usuario.Id_Usuario_Principal);

            if (usuario.UserPrincipal == true)
            {
                return
                from entidades in dbSet
                join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                where eventoUsuario.Usuario.Id == usuario.Id
                && entidades.Deletado == false
                select entidades;

            }
            else if (usuario.Organizador == true)
            {
                return dbSet.Where(t => t.CriadoPor == usuario.UserName && t.Deletado == false);
            }
            else if (usuario.UserPrincipal == false)
            {
                return
                from entidades in dbSet
                join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                where eventoUsuario.Usuario.Id == usuario.Usuario_Principal.Id
                && entidades.Deletado == false
                select entidades;

            }
            else if (usuario.CaixaEvento == true)
            {
                return
                from entidades in dbSet
                join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                where usuarios.Usuario_Organizador.Id == usuario.Usuario_Organizador.Id
                && entidades.Deletado == false
                select entidades;
            }
            else
            {
                return dbSet.Where(t => t.Deletado ==false);
            }

        }

        public override IEnumerable<Evento> TrazerTodosDeletados()
        {
            var usuario = Db.Set<Usuario>().SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);
            var usuarioPrincipal = Db.Set<Usuario>().SingleOrDefault(u => u.Id == usuario.Id_Usuario_Principal);

            if (usuario.UserPrincipal == true)
            {
                return
                from entidades in dbSet
                join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                where eventoUsuario.Usuario.Id == usuario.Id
                && entidades.Deletado == true
                select entidades;

            }
            else if (usuario.Organizador == true)
            {
                return dbSet.Where(t => t.CriadoPor == usuario.UserName && t.Deletado == true);
            }
            else if (usuario.UserPrincipal == false)
            {
                return
                from entidades in dbSet
                join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                where eventoUsuario.Usuario.Id == usuario.Usuario_Principal.Id
                && entidades.Deletado == true
                select entidades;

            }
            else if (usuario.CaixaEvento == true)
            {
                return
                from entidades in dbSet
                join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                where usuarios.Usuario_Organizador.Id == usuario.Usuario_Organizador.Id
                && entidades.Deletado == true
                select entidades;
            }
            else
            {
                return dbSet.Where(t => t.Deletado == true);
            }
        }

        public override IEnumerable<Evento> Pesquisar(Expression<Func<Evento, bool>> Expressao)
        {
            var usuario = Db.Set<Usuario>().SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);
            var usuarioPrincipal = Db.Set<Usuario>().SingleOrDefault(u => u.Id == usuario.Id_Usuario_Principal);

            if (usuario.UserPrincipal == true)
            {
                return
                (from entidades in dbSet
                join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                where eventoUsuario.Usuario.Id == usuario.Id
          
                select entidades).Where(Expressao);

            }
            else if (usuario.Organizador == true)
            {
                return dbSet.Where(t => t.CriadoPor == usuario.UserName ).Where(Expressao);
            }
            else if (usuario.UserPrincipal == false)
            {
                return
                (from entidades in dbSet
                join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                where eventoUsuario.Usuario.Id == usuario.Usuario_Principal.Id
                
                select entidades).Where(Expressao);

            }
            else if (usuario.CaixaEvento == true)
            {
                return
                (from entidades in dbSet
                join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                where usuarios.Usuario_Organizador.Id == usuario.Usuario_Organizador.Id
                select entidades).Where(Expressao);
            }
            else
            {
                return dbSet.Where(Expressao);
            }
        }

        public override IEnumerable<Evento> PesquisarAtivos(Expression<Func<Evento, bool>> Expressao)
        {
            var usuario = Db.Set<Usuario>().SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);
            var usuarioPrincipal = Db.Set<Usuario>().SingleOrDefault(u => u.Id == usuario.Id_Usuario_Principal);

            if (usuario.UserPrincipal == true)
            {
                return
                (from entidades in dbSet
                join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                where eventoUsuario.Usuario.Id == usuario.Id
                && entidades.Deletado == false
                select entidades).Where(Expressao);

            }
            else if (usuario.Organizador == true)
            {
                return dbSet.Where(t => t.CriadoPor == usuario.UserName && t.Deletado == false).Where(Expressao);
            }
            else if (usuario.UserPrincipal == false)
            {
                return
                (from entidades in dbSet
                join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                where eventoUsuario.Usuario.Id == usuario.Usuario_Principal.Id
                && entidades.Deletado == false
                select entidades).Where(Expressao);

            }
            else if (usuario.CaixaEvento == true)
            {
                return
                (from entidades in dbSet
                join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                where usuarios.Usuario_Organizador.Id == usuario.Usuario_Organizador.Id
                && entidades.Deletado == false
                select entidades).Where(Expressao);
            }
            else
            {
                return dbSet.Where(t => t.Deletado == false).Where(Expressao);
            }

        }

        public override IEnumerable<Evento> PesquisarDeletados(Expression<Func<Evento, bool>> Expressao)
        {
            var usuario = Db.Set<Usuario>().SingleOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);
            var usuarioPrincipal = Db.Set<Usuario>().SingleOrDefault(u => u.Id == usuario.Id_Usuario_Principal);

            if (usuario.UserPrincipal == true)
            {
                return
                (from entidades in dbSet
                 join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                 join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                 where eventoUsuario.Usuario.Id == usuario.Id
                 && entidades.Deletado == true
                 select entidades).Where(Expressao);

            }
            else if (usuario.Organizador == true)
            {
                return dbSet.Where(t => t.CriadoPor == usuario.UserName && t.Deletado == false).Where(Expressao);
            }
            else if (usuario.UserPrincipal == false)
            {
                return
                (from entidades in dbSet
                 join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                 join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                 where eventoUsuario.Usuario.Id == usuario.Usuario_Principal.Id
                 && entidades.Deletado == true
                 select entidades).Where(Expressao);

            }
            else if (usuario.CaixaEvento == true)
            {
                return
                (from entidades in dbSet
                 join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                 join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                 where usuarios.Usuario_Organizador.Id == usuario.Usuario_Organizador.Id
                 && entidades.Deletado == true
                 select entidades).Where(Expressao);
            }
            else
            {
                return dbSet.Where(t => t.Deletado == true).Where(Expressao);
            }
        }

    }
}