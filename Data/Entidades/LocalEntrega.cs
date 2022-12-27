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

        [Column("NcmId")]
        public int NcmId { get; set; }

        [Column("AliquotaIss")]
        public double AliquotaIss { get; set; }

        [Column("CfopId")]
        public int CfopId { get; set; }

        [Column("EntregadorId")]
        public int EntregadorId { get; set; }

        [Column("CstId")]
        public int CstId { get; set; }

        [Column("CsosnId")]
        public int CsosnId { get; set; }

        [Column("CodigoBeneficioFiscalId")]
        public int CodigoBeneficioFiscalId { get; set; }

        [Column("CodigoNatureza")]
        public double CodigoNatureza { get; set; }

        public Ncm Ncm { get; set; }
        public NaturezaOperacao Cfop { get; set; }
        public Entregador Entregador { get; set; }
        public Tributo Cst { get; set; }
        public Tributo Csosn { get; set; }
        public Tributo CodigoBeneficioFiscal { get; set; }
    }
}
