using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entidades
{
    [Table("Pbm")]
    public class Pbm
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Required]
        public string Nome { get; set; }

        [Column("Observacao")]
        public string Observacao { get; set; }
    }
}
