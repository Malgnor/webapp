using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lista.Models
{
    public class Jogo
    {
        public int Id { get; set; }

        [Required]
        public String Nome{ get; set; }

        [DataType(DataType.Currency)]
        public Decimal Preço { get; set; }

        public bool IdadeMinima { get; set; }
    }
}