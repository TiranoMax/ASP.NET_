using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_DisKWeb.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório")]
        [MaxLength(7, ErrorMessage = "O Campo CEP deve ter no minimo e no máximo 7 caracteres"), 
            MinLength(7, ErrorMessage = "O Campo CEP deve ter no minimo e no máximo 7 caracteres")]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O campo endereço é obrigatório")]
        [MaxLength(100, ErrorMessage = "O Campo endereço deve ter no máximo 100 caracteres"),]
        [MinLength(3, ErrorMessage = "O Campo endereço deve ter no minimo 3 caracteres ")]
        [Display(Name = "Endereço")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório")]
        [MaxLength(80, ErrorMessage = "O Campo Bairro deve ter no máximo 80 caracteres")]
        [MinLength(3, ErrorMessage = "O Campo Bairro deve ter no minimo 3 caracteres ")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório")]
        [MaxLength(80, ErrorMessage = "O Campo Cidade deve ter no máximo 80 caracteres")]
        [MinLength(3, ErrorMessage = "O Campo Cidade deve ter no minimo 3 caracteres ")]
        [Display(Name = "Cidade")]
        public string Localidade { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório")]
        [MaxLength(2, ErrorMessage = "O Campo Cidade deve ter no máximo 2 caracteres")]
        [MinLength(2, ErrorMessage = "O Campo Cidade deve ter no minimo 2 caracteres ")]
        [Display(Name = "Estado")]
        public string UF { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório")]
        [Display(Name = "Número da residência")]
        public int Numero { get; set; }

        [MaxLength(30, ErrorMessage = "O Campo Bairro deve ter no máximo 30 caracteres")]
        [MinLength(1, ErrorMessage = "O Campo Bairro deve ter no minimo 1 caracter ")]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        public int UsaurioId { get; set; }

        public virtual Usuario Usuario { get; set; }

    }
}