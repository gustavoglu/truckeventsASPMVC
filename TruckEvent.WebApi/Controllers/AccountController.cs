﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using TruckEvent.WebApi.Models;
using TruckEvent.WebApi.Providers;
using TruckEvent.WebApi.Results;
using TruckEvent.WebApi.Infra;
using System.Threading;
using System.Linq;
using TruckEvent.WebApi.Services;
using TruckEvent.WebApi.Services.Interfaces;
using TruckEvent.WebApi.ViewModels;

namespace TruckEvent.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private readonly SQLContext Db;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
            Db = new SQLContext();
        }

        public AccountController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        // GET api/Account/UserInfo
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("UserInfo")]
        public UserInfoViewModel GetUserInfo()
        {
            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            return new UserInfoViewModel
            {
                Email = User.Identity.GetUserName(),
                HasRegistered = externalLogin == null,
                LoginProvider = externalLogin != null ? externalLogin.LoginProvider : null
            };
        }

        // POST api/Account/Logout
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }

        // GET api/Account/ManageInfo?returnUrl=%2F&generateState=true
        [Route("ManageInfo")]
        public async Task<ManageInfoViewModel> GetManageInfo(string returnUrl, bool generateState = false)
        {
            IdentityUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (user == null)
            {
                return null;
            }

            List<UserLoginInfoViewModel> logins = new List<UserLoginInfoViewModel>();

            foreach (IdentityUserLogin linkedAccount in user.Logins)
            {
                logins.Add(new UserLoginInfoViewModel
                {
                    LoginProvider = linkedAccount.LoginProvider,
                    ProviderKey = linkedAccount.ProviderKey
                });
            }

            if (user.PasswordHash != null)
            {
                logins.Add(new UserLoginInfoViewModel
                {
                    LoginProvider = LocalLoginProvider,
                    ProviderKey = user.UserName,
                });
            }

            return new ManageInfoViewModel
            {
                LocalLoginProvider = LocalLoginProvider,
                Email = user.UserName,
                Logins = logins,
                ExternalLoginProviders = GetExternalLogins(returnUrl, generateState)
            };
        }

        // POST api/Account/ChangePassword
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword,
                model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/SetPassword
        [Route("SetPassword")]
        public async Task<IHttpActionResult> SetPassword(SetPasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/AddExternalLogin
        [Route("AddExternalLogin")]
        public async Task<IHttpActionResult> AddExternalLogin(AddExternalLoginBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            AuthenticationTicket ticket = AccessTokenFormat.Unprotect(model.ExternalAccessToken);

            if (ticket == null || ticket.Identity == null || (ticket.Properties != null
                && ticket.Properties.ExpiresUtc.HasValue
                && ticket.Properties.ExpiresUtc.Value < DateTimeOffset.UtcNow))
            {
                return BadRequest("Falha no login externo.");
            }

            ExternalLoginData externalData = ExternalLoginData.FromIdentity(ticket.Identity);

            if (externalData == null)
            {
                return BadRequest("O login externo já está associado a uma conta.");
            }

            IdentityResult result = await UserManager.AddLoginAsync(User.Identity.GetUserId(),
                new UserLoginInfo(externalData.LoginProvider, externalData.ProviderKey));

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/RemoveLogin
        [Route("RemoveLogin")]
        public async Task<IHttpActionResult> RemoveLogin(RemoveLoginBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result;

            if (model.LoginProvider == LocalLoginProvider)
            {
                result = await UserManager.RemovePasswordAsync(User.Identity.GetUserId());
            }
            else
            {
                result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(),
                    new UserLoginInfo(model.LoginProvider, model.ProviderKey));
            }

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // GET api/Account/ExternalLogin
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
        [AllowAnonymous]
        [Route("ExternalLogin", Name = "ExternalLogin")]
        public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
        {
            if (error != null)
            {
                return Redirect(Url.Content("~/") + "#error=" + Uri.EscapeDataString(error));
            }

            if (!User.Identity.IsAuthenticated)
            {
                return new ChallengeResult(provider, this);
            }

            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            if (externalLogin == null)
            {
                return InternalServerError();
            }

            if (externalLogin.LoginProvider != provider)
            {
                Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                return new ChallengeResult(provider, this);
            }

            Usuario user = await UserManager.FindAsync(new UserLoginInfo(externalLogin.LoginProvider,
                externalLogin.ProviderKey));

            bool hasRegistered = user != null;

            if (hasRegistered)
            {
                Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

                ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(UserManager,
                   OAuthDefaults.AuthenticationType);
                ClaimsIdentity cookieIdentity = await user.GenerateUserIdentityAsync(UserManager,
                    CookieAuthenticationDefaults.AuthenticationType);

                AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user.UserName);
                Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);
            }
            else
            {
                IEnumerable<Claim> claims = externalLogin.GetClaims();
                ClaimsIdentity identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
                Authentication.SignIn(identity);
            }

            return Ok();
        }

        // GET api/Account/ExternalLogins?returnUrl=%2F&generateState=true
        [AllowAnonymous]
        [Route("ExternalLogins")]
        public IEnumerable<ExternalLoginViewModel> GetExternalLogins(string returnUrl, bool generateState = false)
        {
            IEnumerable<AuthenticationDescription> descriptions = Authentication.GetExternalAuthenticationTypes();
            List<ExternalLoginViewModel> logins = new List<ExternalLoginViewModel>();

            string state;

            if (generateState)
            {
                const int strengthInBits = 256;
                state = RandomOAuthStateGenerator.Generate(strengthInBits);
            }
            else
            {
                state = null;
            }

            foreach (AuthenticationDescription description in descriptions)
            {
                ExternalLoginViewModel login = new ExternalLoginViewModel
                {
                    Name = description.Caption,
                    Url = Url.Route("ExternalLogin", new
                    {
                        provider = description.AuthenticationType,
                        response_type = "token",
                        client_id = Startup.PublicClientId,
                        redirect_uri = new Uri(Request.RequestUri, returnUrl).AbsoluteUri,
                        state = state
                    }),
                    State = state
                };
                logins.Add(login);
            }

            return logins;
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int countVariaveisRequest = 0;

            var propertys = model.GetType().GetProperties().Where(p => p.PropertyType == typeof(bool));
            var count = propertys.Count();
            foreach (var property in propertys)
            {
                var value = property.GetValue(model, null);

                if ((bool)value)
                {
                    countVariaveisRequest++;
                }
            }

            string variaveis = "Váriaveis : Admin, CaixaEvento, PrincipalLoja e Organizador";


            if (countVariaveisRequest > 1)
            {
                return BadRequest("Não é possivel cadastrar usuario com mais de um tipo de Usuario, se cadastre apenas com um tipo das váriaveis: " + variaveis);
            }

            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;

            string id_usuario;

            if (identity.Claims.ToList().Exists(c => c.Type == "id_usuario"))
            {
                id_usuario = identity.Claims.SingleOrDefault(c => c.Type == "id_usuario").Value;
            }
            else
            {
                id_usuario = string.Empty;
            }


            if (model.Organizador == false && model.Admin == false && model.PrincipalLoja == false && id_usuario == string.Empty && model.CaixaEvento == true ||
                model.Organizador == false && model.Admin == false && model.PrincipalLoja == false && id_usuario == string.Empty && model.CaixaEvento == false)
            {
                return BadRequest("Não é possivel criar Usuario de loja ou Usuario Caixa de Evento sem estar logado, só é possivel criar usuario Admin ou PrincipalLoja, " + variaveis);
            }

            var user = new Usuario()
            {
                UserName = model.Email,
                Email = model.Email,
                Documento = model.Documento,
                Nome = model.Nome,
                Sobrenome = model.Sobrenome,
                Telefone1 = model.Telefone1,
                Telefone2 = model.Telefone2,
                Organizador = model.Organizador,
                UserPrincipal = model.PrincipalLoja,
                UserAdmin = model.Admin,
                CaixaEvento = model.CaixaEvento
            };

            //Funcionario da Loja
            if (model.PrincipalLoja == false && model.Organizador == false && model.Admin == false && id_usuario != string.Empty)
            {
                user.Id_Usuario_Principal = id_usuario;
            }
            // CaixaLoja
            //if (model.CaixaEvento && !model.PrincipalLoja && !model.Organizador && !model.Admin && id_usuario != string.Empty)
            //{
            //    user.id_usuario_organizador = id_usuario;
            //}

            IdentityResult result = await UserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        [AllowAnonymous]
        [Route("Register/Convite")]
        public async Task<IHttpActionResult> RegisterConvite(RegisterConviteBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ITokenEnvioAppService _tokenEnvioAppService = new TokenEnvioAppService();

            var token = _tokenEnvioAppService.TrazerTodosAtivos().SingleOrDefault(t => t.Token == model.Token && t.ExpiraEm >= DateTime.Now && t.Ativo == true);

            if (token == null)
            {
                return BadRequest("Este token já Expirou ou não existe, por favor solicitar outro convite");
            }

            Usuario usuarioCadastrado = new Usuario()
            {
                UserName = model.Email,
                Email = model.Email,
                Documento = model.Documento,
                Nome = model.Nome,
                Sobrenome = model.Sobrenome,
                Telefone1 = model.Telefone1,
                Telefone2 = model.Telefone2,
            };

            var eventoExist = Db.Eventos.ToList().Exists(e => e.Id == Guid.Parse(model.Id_parametro) && e.Deletado == false);
            var usuarioRemetente = Db.Users.ToList().SingleOrDefault(u => u.Id == model.Id_parametro);

            if (!eventoExist && usuarioRemetente == null)
            {
                return BadRequest("Evento ou Usuario não existe");
            }

            if (usuarioRemetente != null)
            {
                if (usuarioRemetente.Organizador == true)
                {
                    usuarioCadastrado.CaixaEvento = true;
                }

                if (usuarioRemetente.UserPrincipal == true)
                {
                    usuarioCadastrado.Id_Usuario_Principal = usuarioRemetente.Id;
                }
            }

            if (eventoExist)
            {
                usuarioCadastrado.UserPrincipal = true;
                IdentityResult rs = await UserManager.CreateAsync(usuarioCadastrado, model.Password);

                if (!rs.Succeeded)
                {
                    return GetErrorResult(rs);
                }
                else
                {

                    IEvento_UsuarioAppService _evento_UsuarioAppService = new Evento_UsuarioAppService();
                    IEventoAppService _eventoAppService = new EventoAppService();

                    EventoViewModel evento = _eventoAppService.BuscarPorId(Guid.Parse(model.Id_parametro));
                    Evento_UsuarioViewModel evento_usuario = new Evento_UsuarioViewModel()
                    {
                        Id_Evento = evento.Id,
                        Id_Usuario = usuarioCadastrado.Id
                    };

                    var evento_usuarioInserido = _evento_UsuarioAppService.Criar(evento_usuario);

                    if (evento_usuarioInserido != null)
                    {

                        token.Ativo = false;
                        _tokenEnvioAppService.Atualizar(token);

                        return Ok("Usuario Cadastrado e vinculado com Evento " + evento.Descricao);
                    }
                    else
                    {
                        return BadRequest("Evento_usuario não foi inserido corretamente.");
                    }

                }



            }

            IdentityResult result = await UserManager.CreateAsync(usuarioCadastrado, model.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }
            else
            {
                token.Ativo = false;
                _tokenEnvioAppService.Atualizar(token);

                return Ok("Usuario cadastrao e vinculado com sucesso");
            }


        }

        // POST api/Account/RegisterExternal
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("RegisterExternal")]
        public async Task<IHttpActionResult> RegisterExternal(RegisterExternalBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var info = await Authentication.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return InternalServerError();
            }

            var user = new Usuario() { UserName = model.Email, Email = model.Email };

            IdentityResult result = await UserManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            result = await UserManager.AddLoginAsync(user.Id, info.Login);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Auxiliares

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // Nenhum erro ModelState disponível para envio; retorne um BadRequest vazio.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        private class ExternalLoginData
        {
            public string LoginProvider { get; set; }
            public string ProviderKey { get; set; }
            public string UserName { get; set; }

            public IList<Claim> GetClaims()
            {
                IList<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

                if (UserName != null)
                {
                    claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
                }

                return claims;
            }

            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
            {
                if (identity == null)
                {
                    return null;
                }

                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

                if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
                    || String.IsNullOrEmpty(providerKeyClaim.Value))
                {
                    return null;
                }

                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                {
                    return null;
                }

                return new ExternalLoginData
                {
                    LoginProvider = providerKeyClaim.Issuer,
                    ProviderKey = providerKeyClaim.Value,
                    UserName = identity.FindFirstValue(ClaimTypes.Name)
                };
            }
        }

        private static class RandomOAuthStateGenerator
        {
            private static RandomNumberGenerator _random = new RNGCryptoServiceProvider();

            public static string Generate(int strengthInBits)
            {
                const int bitsPerByte = 8;

                if (strengthInBits % bitsPerByte != 0)
                {
                    throw new ArgumentException("strengthInBits deve ser divisível por 8.", "strengthInBits");
                }

                int strengthInBytes = strengthInBits / bitsPerByte;

                byte[] data = new byte[strengthInBytes];
                _random.GetBytes(data);
                return HttpServerUtility.UrlTokenEncode(data);
            }
        }

        #endregion
    }
}
