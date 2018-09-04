using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ecommerce.Models
{
    [Table("Compra")]
    public class Compra
    {
        [Key]
        public int CompraId { get; set; }

        public string NomeCliente { get; set; }

        public string EnderecoCliente { get; set; }

        public int TelCliente { get; set; }

        public List<ItemVenda> ItemVendas { get; set; }

        
    }
}