using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class TipoCapsula
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo de descrição não preenchido")]
        public string Descricao { get; set; }

        [Column("Numero")]
        [MaxLength(10)]
        public string Numero { get; set; }

        [Column("VolumeInterno")]
        public double? VolumeInterno { get; set; }

        [Column("VolumeTotal")]
        public double? VolumeTotal { get; set; }

        [Column("Peso")]
        public double? Peso { get; set; }

        [Column("CapsulaPadraoId")]
        public int? CapsulaPadraoId { get; set; }

        public Produto CapsulaPadrao { get; set; }

        [Column("Inativo")]
        public bool Inativo { get; set; }

        [Column("GrupoCapsulasId")]
        public int? GrupoCapsulasId { get; set; }

        public Produto GrupoCapsulas { get; set; }
    }
}
