using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        
        [Required(ErrorMessage = "Campo Obrigatótio")]
        [MaxLength(50, ErrorMessage = "O campo deve conter no máximo 50 caractres")]
        [Display(Name = "Nome da Categoria")]
        public string NomeCategoria { get; set; }

        [Display(Name = "Descrição da Categoria")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }


    }
}