using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Bairro
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Required]
        public string Nome { get; set; }
    }
}
