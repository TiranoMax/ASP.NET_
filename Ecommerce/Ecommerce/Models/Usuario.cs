using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Nome do Usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "E-mail do usuário")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Senha do usuário")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Os campos não coincidem!")]
        [Display(Name = "Confirmação da senha")]
        [NotMapped]
        public string ConfirmeSenha { get; set; }

        [Display(Name = "Cep")]
        public string Cep { get; set; }

        [Display(Name = "Endereço")]
        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        public string Localidade { get; set; }

        [Display(Name = "Estado")]
        public string UF { get; set; }
    }
}