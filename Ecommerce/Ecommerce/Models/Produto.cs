using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage ="Campo Obrigatótio")]
        [MaxLength(50, ErrorMessage="O campo deve conter no máximo 50 caractres")]
        [Display(Name ="Nome do Produto")]
        public string Nome { get; set; }

        [Display(Name = "Descrição do Produto")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatótio")]
        [Display(Name = "Preço do Produto")]
        //[Range]responsavel por limitar o tamanho de números
        public double Preco { get; set; }

        [Display(Name = "Categoria do Produto")]
        public string Categoria { get; set; }

        public string Imagem { get; set; }

    }
}