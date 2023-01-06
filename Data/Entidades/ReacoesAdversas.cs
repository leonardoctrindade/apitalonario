using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class ReacoesAdversas
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Data")]
        [Required(ErrorMessage = "Campo de data não preenchido")]
        public DateTime? Data { get; set; }

        [Column("Medicamento")]
        [Required(ErrorMessage = "Campo de mecicamento não preenchido")]
        [MaxLength(50)]
        public string Medicamento { get; set; }

        [Column("Dose")]
        [Required(ErrorMessage = "Campo de dose não preenchido")]
        [MaxLength(30)]
        public string Dose { get; set; }

        [Column("Reacao")]
        [MaxLength(50)]
        public string Reacao { get; set; }

        [Column("ClienteId")]
        [Required(ErrorMessage = "Campo de clienteId não preenchido")]
        public int ClienteId { get; set; }
    }
}
