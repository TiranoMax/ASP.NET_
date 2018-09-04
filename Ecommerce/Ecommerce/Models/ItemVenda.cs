 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    [Table("ItemVenda")]
    public class ItemVenda
    {
        [Key]
        public int ItemVendaId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatótio")]
        [Display(Name = "Nome do Produto")]
        public Produto Produto { get; set; }

        [Required(ErrorMessage = "Campo Obrigatótio")]
        [Display(Name = "Quantidade ")]
        public int Qtde { get; set; }

        [Required(ErrorMessage = "Campo Obrigatótio")]
        [Display(Name = "Preço")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatótio")]
        [Display(Name = "Data de adicionamento")]
        public DateTime Data { get; set; }

        public string CartId { get; set; }
    }
}