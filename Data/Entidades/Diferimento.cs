using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Diferimento
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Icms")]
        public double Icms { get; set; }

        [Column("AliquotaDiferimento")]
        [Required(ErrorMessage = "Campo de aliquota diferimnto não preenchido")]
        public double AliquotaDiferimento { get; set; }

        [Column("Cst")]
        [MaxLength(10)]
        [Required(ErrorMessage = "Campo de Cst não preenchido")]
        public string Cst { get; set; }

        [Column("SiglaEstado")]
        [MaxLength(2)]
        [Required(ErrorMessage = "Campo de estado não preenchido")]
        public string SiglaEstado { get; set; }

        [Column("IdFilial")]
        public int IdFilial { get; set; }
    }
}
