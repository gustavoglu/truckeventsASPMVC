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
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {

                if (usuarioLogado_usuarioprincipal)
                {
                    return
                    (from entidades in dbSet
                    join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                    where eventoUsuario.Usuario.Id == usuarioLogado_id
                    && entidades.Deletado == false
                    select entidades).FirstOrDefault(e => e.Id == Id);

                }
                else if (usuarioLogado_organizador)
                {
                    return dbSet.Where(t => t.CriadoPor == usuarioLogado_username && t.Deletado == false ).FirstOrDefault(e => e.Id == Id);
                }
                else if (usuarioLogado_id_usuario_principal.Any())
                {
                    return
                    (from entidades in dbSet
                    join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                    where eventoUsuario.Usuario.Id == usuarioLogado_id_usuario_principal
                    && entidades.Deletado == false
                    select entidades).FirstOrDefault(e => e.Id == Id);

                }
                else if (usuarioLogado_caixaevento)
                {
                    return
                    (from entidades in dbSet
                    join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                    join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                    where usuarios.Usuario_Organizador.Id == usuarioLogado_id_usuario_organizador
                    && entidades.Deletado == false
                    select entidades).FirstOrDefault(e => e.Id == Id);
                }
                else
                {
                    return dbSet.Where(t => t.Deletado == false).FirstOrDefault(e => e.Id == Id);
                }
            }
            else
            {
                return dbSet.Where(t => t.Deletado == false).FirstOrDefault(e => e.Id == Id);
            }
        }

        public override IEnumerable<Evento> TrazerTodos()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                
                if (usuarioLogado_usuarioprincipal)
                {
                    return
                    from entidades in dbSet
                    join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                    where eventoUsuario.Usuario.Id == usuarioLogado_id
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
                    join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                    where eventoUsuario.Usuario.Id == usuarioLogado_id_usuario_principal
                    select entidades;

                }
                else if (usuarioLogado_caixaevento)
                {
                    return
                    from entidades in dbSet
                    join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                    join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                    where usuarios.Usuario_Organizador.Id == usuarioLogado_id_usuario_organizador
                    select entidades;
                }
                else
                {
                    return dbSet;
                }
            }
            else
            {
                return dbSet;
            }
        }

        public override IEnumerable<Evento> TrazerTodosAtivos()
        {

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {

                if (usuarioLogado_usuarioprincipal)
                {
                    return
                    from entidades in dbSet
                    join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                    where eventoUsuario.Usuario.Id == usuarioLogado_id
                    && entidades.Deletado == false
                    select entidades;

                }
                else if (usuarioLogado_organizador)
                {
                    return dbSet.Where(t => t.CriadoPor == usuarioLogado_username && t.Deletado == false);
                }
                else if (usuarioLogado_id_usuario_principal.Any())
                {
                    return
                    from entidades in dbSet
                    join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                    where eventoUsuario.Usuario.Id == usuarioLogado_id_usuario_principal
                    && entidades.Deletado == false
                    select entidades;

                }
                else if (usuarioLogado_caixaevento)
                {
                    return
                    from entidades in dbSet
                    join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                    join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                    where usuarios.Usuario_Organizador.Id == usuarioLogado_id_usuario_organizador
                    && entidades.Deletado == false
                    select entidades;
                }
                else
                {
                    return dbSet.Where(t => t.Deletado == false);
                }
            }
            else
            {
                return dbSet.Where(t => t.Deletado == false);
            }

        }

        public override IEnumerable<Evento> TrazerTodosDeletados()
        {

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {

                if (usuarioLogado_usuarioprincipal)
                {
                    return
                    from entidades in dbSet
                    join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                    where eventoUsuario.Usuario.Id == usuarioLogado_id
                    && entidades.Deletado == true
                    select entidades;

                }
                else if (usuarioLogado_organizador)
                {
                    return dbSet.Where(t => t.CriadoPor == usuarioLogado_username && t.Deletado == false);
                }
                else if (usuarioLogado_id_usuario_principal.Any())
                {
                    return
                    from entidades in dbSet
                    join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                    where eventoUsuario.Usuario.Id == usuarioLogado_id_usuario_principal
                    && entidades.Deletado == true
                    select entidades;

                }
                else if (usuarioLogado_caixaevento)
                {
                    return
                    from entidades in dbSet
                    join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                    join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                    where usuarios.Usuario_Organizador.Id == usuarioLogado_id_usuario_organizador
                    && entidades.Deletado == true
                    select entidades;
                }
                else
                {
                    return dbSet.Where(t => t.Deletado == true);
                }
            }
            else
            {
                return dbSet.Where(t => t.Deletado == true);
            }
        }

        public override IEnumerable<Evento> Pesquisar(Expression<Func<Evento, bool>> Expressao)
        {

            if (usuarioLogado_usuarioprincipal)
            {
                return
               ( from entidades in dbSet
                join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                where eventoUsuario.Usuario.Id == usuarioLogado_id
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
                join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                where eventoUsuario.Usuario.Id == usuarioLogado_id_usuario_principal
                select entidades).Where(Expressao);

            }
            else if (usuarioLogado_caixaevento)
            {
                return
                (from entidades in dbSet
                 join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                 join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                where usuarios.Usuario_Organizador.Id == usuarioLogado_id_usuario_organizador
                select entidades).Where(Expressao);
            }
            else
            {
                return dbSet.Where(Expressao);
            }
        }

        public override IEnumerable<Evento> PesquisarAtivos(Expression<Func<Evento, bool>> Expressao)
        {

            if (usuarioLogado_usuarioprincipal)
            {
                return
               (from entidades in dbSet
                join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                where eventoUsuario.Usuario.Id == usuarioLogado_id
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
                 join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                 where eventoUsuario.Usuario.Id == usuarioLogado_id_usuario_principal
                 && entidades.Deletado == false
                 select entidades).Where(Expressao);

            }
            else if (usuarioLogado_caixaevento)
            {
                return
                (from entidades in dbSet
                 join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                 join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                 where usuarios.Usuario_Organizador.Id == usuarioLogado_id_usuario_organizador
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
            if (usuarioLogado_usuarioprincipal)
            {
                return
               (from entidades in dbSet
                join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                where eventoUsuario.Usuario.Id == usuarioLogado_id
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
                 join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                 where eventoUsuario.Usuario.Id == usuarioLogado_id_usuario_principal
                 && entidades.Deletado == true
                 select entidades).Where(Expressao);

            }
            else if (usuarioLogado_caixaevento)
            {
                return
                (from entidades in dbSet
                 join usuarios in Db.Users on entidades.CriadoPor equals usuarios.UserName
                 join eventoUsuario in Db.Evento_Usuarios on entidades.Id equals eventoUsuario.Evento.Id
                 where usuarios.Usuario_Organizador.Id == usuarioLogado_id_usuario_organizador
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