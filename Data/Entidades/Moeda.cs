using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entidades
{
    public class Moeda
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome")]
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
    }
}
