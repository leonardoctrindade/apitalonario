using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class FormulaPadrao
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo de descricao não preenchido")]
        public string Descricao { get; set; }

        [Column("ManterDescricao")]
        public bool ManterDescricao { get; set; }

        [Column("Tipo")]
        [Required(ErrorMessage = "Campo de tipo não preenchido")]
        public TipoFormulaPadrao Tipo { get; set; }

        [Column("IdFormaFarmaceutica")]
        [Required(ErrorMessage = "Campo IdFormaFarmaceutica não preenchido")]
        public int IdFormaFarmaceutica { get; set; }

        [Column("Validade")]
        public int Validade { get; set; }

        [Column("Volume")]
        public double Volume { get; set; }

        [Column("IdUnidade")]
        public int IdUnidade { get; set; }

        [Column("QuantidadeFormulaPadrao")]
        public int QuantidadeFormulaPadrao { get; set; }

        [Column("QuantidadeEmbalagens")]
        public int QuantidadeEmbalagens { get; set; }

        [Column("DosePadrao")]
        public double DosePadrao { get; set; }

        [Column("IdUnidadeDosePadrao")]
        public int IdUnidadeDosePadrao { get; set; }

        [Column("IdProduto")]
        public int IdProduto { get; set; }

        [Column("DesmembrarFormula")]
        public bool DesmembrarFormula { get; set; }

        [Column("ValorFormula")]
        public double ValorFormula { get; set; }

        [Column("IdEmbalagem")]
        public int IdEmbalagem { get; set; }

        [Column("IdCapsula")]
        public int IdCapsula { get; set; }

        [Column("DoseCapsula")]
        public double DoseCapsula { get; set; }

        [Column("IdPosologia")]
        public int IdPosologia { get; set; }

        [Column("IdProdutoVeiculo")]
        public int IdProdutoVeiculo { get; set; }

        [Column("ExibirRotuloCompleto")]
        public bool ExibirRotuloCompleto { get; set; }

        [Column("InativarFormula")]
        public bool InativarFormula { get; set; }

        [Column("IdEtiqueta")]
        public int IdEtiqueta { get; set; }

        [Column("MantemQuantidadeOrdem")]
        public bool MantemQuantidadeOrdem { get; set; }

        [Column("ObservacaoEtiqueta")]
        [MaxLength(500)]
        public string ObservacaoEtiqueta { get; set; }

        [Column("Observacao")]
        [MaxLength(999)]
        public string Observacao { get; set; }

        [Column("VolumePadrao2")]
        [MaxLength(20)]
        public string VolumePadrao2 { get; set; }

        [Column("IdUnidadeDose")]
        public int IdUnidadeDose { get; set; }

        [Column("DoseFormula")]
        public double DoseFormula { get; set; }

        [Column("IdGrupoProdutoVeiculo")]
        public int IdGrupoProdutoVeiculo { get; set; }

        [Column("IdGrupoEmbalagem")]
        public int IdGrupoEmbalagem { get; set; }

        [Column("IdGrupoCapsula")]
        public int IdGrupoCapsula { get; set; }

        [Column("IdGrupo")]
        public int IdGrupo { get; set; }

        [Column("QuantidadeCapsulas")]
        public int QuantidadeCapsulas { get; set; }

    }

    public enum TipoFormulaPadrao
    {
        BaseExcipienteSemiAcabado,
        Acabado,
        PreVenda,
        AcabadoPreVenda
    }
}
