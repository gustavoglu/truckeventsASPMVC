using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TruckEvent.WebApi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class Usuario : IdentityUser
    {

        public string Nome { get; set; } = null;
        public string Sobrenome { get; set; } = null;
        public string RazaoSocial { get; set; } = null;
        public string Telefone1 { get; set; } = null;
        public string Telefone2 { get; set; } = null;
        public string Documento { get; set; } = null;
        public DateTime? DataNascimento { get; set; }
        public bool? UserAdmin { get; set; }
        public bool? UserPrincipal { get; set; }
        public bool? Organizador { get; set; }
        public bool? CaixaEvento { get; set; }

        public string id_usuario_organizador { get; set; }
        public virtual Usuario Usuario_Organizador { get; set; }

        public virtual ICollection<Usuario> Caixas { get; set; }
        public virtual ICollection<Usuario> Lojas { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }
        public virtual ICollection<Evento_Usuario> Evento_Usuarios { get; set; }

        public virtual Usuario Usuario_Principal { get; set; }
        public string Id_Usuario_Principal { get; set; } = null;


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario> manager, string authenticationType)
        {
            // authenticationType deve corresponder a um definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Adicione declarações de usuários aqui
            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

}