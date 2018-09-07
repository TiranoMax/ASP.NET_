using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_DisKWeb.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        public string Categoria { get; set; }

        public DateTime Ano_Lancamento { get; set; }

        public string Autor { get; set; }

        public string Descricao { get; set; }

        public int QTDE_Estoque { get; set; }

        public double Preco_Venda { get; set; }

        public double Preco_Aluguel { get; set; }

        public string Img { get; set; }
    }
}