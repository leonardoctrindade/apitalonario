using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class LocalEntrega
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Codigo")]
        [Required(ErrorMessage = "Campo de codigo não preenchido")]
        public double Codigo { get; set; }

        [Column("Descricao")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo de descricao não preenchido")]
        public string Descricao { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Column("TaxaEntrega")]
        [Required(ErrorMessage = "Campo de taxa de entrega não preenchido")]
        public double TaxaEntrega { get; set; }

        [Column("IdNcm")]
        public int IdNcm { get; set; }

        [Column("AliquotaIss")]
        public double AliquotaIss { get; set; }

        [Column("IdCfop")]
        public int IdCfop { get; set; }

        [Column("IdEntregador")]
        public int IdEntregador { get; set; }

        [Column("IdCst")]
        public int IdCst { get; set; }

        [Column("IdCsosn")]
        public int IdCsosn { get; set; }

        [Column("IdCodigoBeneficioFiscal")]
        public int IdCodigoBeneficioFiscal { get; set; }

        [Column("CodigoNatureza")]
        public double CodigoNatureza { get; set; }
    }
}
