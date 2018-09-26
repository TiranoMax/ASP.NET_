using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_DisKWeb.Models
{
    [Table("Test")]
    public class Test
    {
        public int Idtest { get; set; }
    }
}