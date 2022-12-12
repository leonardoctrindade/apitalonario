using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class NaturezaOperacao
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Codigo")]
        [Required(ErrorMessage = "Campo de código não preenchido")]
        public decimal Codigo { get; set; }

        [Column("Descricao")]
        [MaxLength(250)]
        [Required(ErrorMessage = "Campo de descrição não preenchido")]
        public string Descricao { get; set; }

        [Column("Tipo")]
        [Required(ErrorMessage = "Campo de tipo não preenchido")]
        public int Tipo { get; set; }

        [Column("ExportarSintegra")]
        public bool ExportarSintegra { get; set; } = false;

        [Column("Observacao")]
        [MaxLength(50)]
        public string Observacao { get; set; }

        [Column("ExibeDocumentoReferenciado")]
        public bool ExibeDocumentoReferenciado { get; set; } = false;

        [Column("ConsiderarCfopCreditoIcms")]
        public bool ConsiderarCfopCreditoIcms { get; set; } = false;

        [Column("NaoInsidePis")]
        public bool NaoInsidePis { get; set; } = false;

        [Column("NaoInsideCofins")]
        public bool NaoInsideCofins { get; set; } = false;

        [Column("NaoInsideIcms")]
        public bool NaoInsideIcms { get; set; } = false;

        [Column("CfopDevolucao")]
        public bool CfopDevolucao { get; set; } = false;

        [Column("CfopSubstituicaoTributaria")]
        public bool CfopSubstituicaoTributaria { get; set; } = false;

        [Column("IdConta")]
        public int IdConta { get; set; }

        [Column("IdCst")]
        public int IdCst { get; set; }

        [Column("IdCsosn")]
        public int IdCsosn { get; set; }

    }
}
