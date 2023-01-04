using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class NcmEstado
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("EstadoOrigemId")]
        [Required(ErrorMessage = "Campo de estado origem não preenchido")]
        public int? EstadoOrigemId { get; set; }

        [Column("EstadoDestinoId")]
        [Required(ErrorMessage = "Campo de estado destino não preenchido")]
        public int? EstadoDestinoId { get; set; }

        [Column("TributoCstId")]
        public int? TributoCstId { get; set; }

        [Column("TributoCsosnId")]
        public int? TributoCsosnId { get; set; }

        [Column("AliquotaIcms")]
        public double? AliquotaIcms { get; set; }

        [Column("AliquotaIcmsInterna")]
        public double? AliquotaIcmsInterna { get; set; }

        [Column("PercentualMva")]
        public double? PercentualMva { get; set; }

        [Column("PercentualFcp")]
        public double? PercentualFcp { get; set; }

        [Column("NcmId")]
        [Required(ErrorMessage = "Campo de NcmId não preenchido")]
        public int? NcmId { get; set; }
        
    }
}
