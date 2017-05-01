using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TruckEvent.WebApi.Models
{
    // Modelos usados como parâmetros para as ações AccountController.

    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "Token de acesso externo")]
        public string ExternalAccessToken { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha atual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nova senha")]
        [Compare("NewPassword", ErrorMessage = "A nova senha e a senha de confirmação não coincidem.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterBindingModel
    {
        [Required(ErrorMessage ="Obrigatório informar o E-mail")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "A senha e a senha de confirmação não coincidem.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Display(Name = "Documento")]
        public string Documento { get; set; }

        [DataType(DataType.PhoneNumber,ErrorMessage = "Por favor inserir número de telefone válido")]
        [Display(Name = "Telefone Principal")]
        public string Telefone1 { get; set; }

        [DataType(DataType.PhoneNumber,ErrorMessage = "Por favor inserir número de telefone válido")]
        [Display(Name = "Telefone Adicional")]
        public string Telefone2 { get; set; }

        [Display(Name = "Admin")]
        public bool Admin { get; set; }

        [Display(Name = "Organizador")]
        public bool Organizador { get; set; }

        [Display(Name = "Principal Usuario da Loja")]
        public bool PrincipalLoja { get; set; }

        [Display(Name = "Caixa de Evento")]
        public bool CaixaEvento { get; set; }


    }

    public class RegisterConviteBindingModel
    {
        [Required(ErrorMessage = "Obrigatório informar o E-mail")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "A senha e a senha de confirmação não coincidem.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Display(Name = "Documento")]
        public string Documento { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Por favor inserir número de telefone válido")]
        [Display(Name = "Telefone Principal")]
        public string Telefone1 { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Por favor inserir número de telefone válido")]
        [Display(Name = "Telefone Adicional")]
        public string Telefone2 { get; set; }
        
        [Required(ErrorMessage ="Necessário informar o token")]
        [Display(Name ="token")]
        public string Token { get; set; }

        [Required(ErrorMessage = "Necessário informar o Id passado como parâmetro")]
        [Display(Name ="id_Parametro")]
        public string Id_parametro { get; set; }

    }

    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class RemoveLoginBindingModel
    {
        [Required]
        [Display(Name = "Provedor de logon")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Chave do Provedor")]
        public string ProviderKey { get; set; }
    }

    public class SetPasswordBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nova senha")]
        [Compare("NewPassword", ErrorMessage = "A nova senha e a senha de confirmação não coincidem.")]
        public string ConfirmPassword { get; set; }
    }
}
