using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using TruckEvent.WebApi.Models;
using System.Threading;

namespace TruckEvent.WebApi.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public Usuario Usuario { get; set; }

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            Usuario user = await userManager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "Nome de usuário ou senha incorreto.");
                return;
            }
            this.Usuario = user;

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
               OAuthDefaults.AuthenticationType);
            ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
                CookieAuthenticationDefaults.AuthenticationType);

            cookiesIdentity.AddClaim(new Claim("id_usuario", user.Id));
            cookiesIdentity.AddClaim(new Claim("admin", user.UserAdmin.ToString()));
            cookiesIdentity.AddClaim(new Claim("organizador", user.Organizador.ToString()));
            cookiesIdentity.AddClaim(new Claim("caixaEvento", user.CaixaEvento.ToString()));
            cookiesIdentity.AddClaim(new Claim("usuarioPrincipal", user.UserPrincipal.ToString()));

            oAuthIdentity.AddClaim(new Claim("id_usuario", user.Id));
            oAuthIdentity.AddClaim(new Claim("admin", user.UserAdmin.ToString()));
            oAuthIdentity.AddClaim(new Claim("organizador", user.Organizador.ToString()));
            oAuthIdentity.AddClaim(new Claim("caixaEvento", user.CaixaEvento.ToString()));
            oAuthIdentity.AddClaim(new Claim("usuarioprincipal", user.UserPrincipal.ToString()));


            if (user.Id_Usuario_Principal != null)
            {
                cookiesIdentity.AddClaim(new Claim("id_usuario_principal", user.Id_Usuario_Principal));
            }


            AuthenticationProperties properties = CreateProperties(user.UserName);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
            
            var principal = new ClaimsPrincipal(oAuthIdentity);
            Thread.CurrentPrincipal = principal;
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            context.AdditionalResponseParameters.Add("Admin", Usuario.UserAdmin);
            context.AdditionalResponseParameters.Add("Organizador", Usuario.Organizador);
            context.AdditionalResponseParameters.Add("CaixaEvento", Usuario.CaixaEvento);
            context.AdditionalResponseParameters.Add("UsuarioPrincipal", Usuario.UserPrincipal);
            context.AdditionalResponseParameters.Add("id_usuario_principal", Usuario.Id_Usuario_Principal);

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // As credenciais de senha do proprietário do recurso não fornecem um ID de cliente.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}