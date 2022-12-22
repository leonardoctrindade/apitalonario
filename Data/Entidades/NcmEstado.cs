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

        [Column("IdEstadoOrigem")]
        [Required(ErrorMessage = "Campo de estado origem não preenchido")]
        public int IdEstadoOrigem { get; set; }

        [Column("IdEstadoDestino")]
        [Required(ErrorMessage = "Campo de estado destino não preenchido")]
        public int IdEstadoDestino { get; set; }

        [Column("IdTributoCst")]
        public int IdTributoCst { get; set; }

        [Column("IdTributoCsosn")]
        public int IdTributoCsosn { get; set; }

        [Column("AliquotaIcms")]
        public double AliquotaIcms { get; set; }

        [Column("AliquotaIcmsInterna")]
        public double AliquotaIcmsInterna { get; set; }

        [Column("PercentualMva")]
        public double PercentualMva { get; set; }

        [Column("PercentualFcp")]
        public double PercentualFcp { get; set; }

        [Column("IdNcm")]
        [Required(ErrorMessage = "Campo de IdNcm não preenchido")]
        public int IdNcm { get; set; }
    }
}
