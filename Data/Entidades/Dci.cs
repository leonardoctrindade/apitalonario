using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entidades
{
    public class Dci
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("CodigoDci")]
        [Required(ErrorMessage = "Campo de código dci não preenchido")]
        [MaxLength(15)]
        public string CodigoDci { get; set; }

        [Column("Descricao")]
        [Required(ErrorMessage = "Campo de descrição não preenchido")]
        [MaxLength(100)]
        public string Descricao { get; set; }
    }
}
