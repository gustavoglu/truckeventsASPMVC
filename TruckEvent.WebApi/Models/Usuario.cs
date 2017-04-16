﻿using System.Security.Claims;
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
        public string Email { get; set; } = null;
        public DateTime? DataNascimento { get; set; }

        public Guid Id_usuario_tipo { get; set; }
        public virtual Usuario_Tipo Usuario_Tipo { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
        public string Id_Usuario_Principal { get; set; } = null;


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario> manager, string authenticationType)
        {
            // authenticationType deve corresponder a um definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Adicione declarações de usuários aqui
            return userIdentity;
        }
    }

}