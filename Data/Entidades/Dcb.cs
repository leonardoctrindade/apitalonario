using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entidades
{
    public class Dcb
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("CodigoDcb")]
        [Required(ErrorMessage = "Campo de Código Dcb não preenchido")]
        [MaxLength(10)]
        public string CodigoDcb { get; set; }

        [Column("Descricao")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo de descrição não preenchido")]
        public string Descricao { get; set; }
    }
}
