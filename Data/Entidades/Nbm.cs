using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entidades
{
    public class Nbm
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("CodigoNbm")]
        [Required]
        [MaxLength(10)]
        public string CodigoNbm { get; set; }
        [Column("Descricao")]
        [Required]
        [MaxLength(50)]
        public string Descricao { get; set; }
        [Column("VlrAgregadoEst")]
        public double VlrAgregadoEst { get; set; }
        [Column("VlrAgregadoInt")]
        public double VlrAgregadoInt { get; set; }
        [Column("VlrComplementarEst")]
        public double VlrComplementarEst { get; set; }
        [Column("VlrComplementarInt")]
        public double VlrComplementarInt { get; set; }
    }
}
