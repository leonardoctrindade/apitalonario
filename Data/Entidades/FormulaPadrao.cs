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

        [Column("FormaFarmaceuticaId")]
        [Required(ErrorMessage = "Campo FormaFarmaceuticaId não preenchido")]
        public int? FormaFarmaceuticaId { get; set; }

        [Column("Validade")]
        public int? Validade { get; set; }

        [Column("Volume")]
        public double? Volume { get; set; }

        [Column("UnidadeId")]
        public int? UnidadeId { get; set; }

        public Unidade Unidade { get; set; }

        [Column("QuantidadeFormulaPadrao")]
        public int? QuantidadeFormulaPadrao { get; set; }

        [Column("QuantidadeEmbalagens")]
        public int? QuantidadeEmbalagens { get; set; }

        [Column("DosePadrao")]
        public double? DosePadrao { get; set; }

        [Column("UnidadeDosePadraoId")]
        public int? UnidadeDosePadraoId { get; set; }

        public Unidade UnidadeDosePadrao { get; set; }

        [Column("ProdutoId")]
        public int? ProdutoId { get; set; }

        public Produto Produto { get; set; }

        [Column("DesmembrarFormula")]
        public bool DesmembrarFormula { get; set; }

        [Column("ValorFormula")]
        public double ValorFormula { get; set; }

        [Column("EmbalagemId")]
        public int? EmbalagemId { get; set; }

        [Column("CapsulaId")]
        public int? CapsulaId { get; set; }

        [Column("DoseCapsula")]
        public double? DoseCapsula { get; set; }

        [Column("PosologiaId")]
        public int? PosologiaId { get; set; }

        public Posologia Posologia { get; set; }

        [Column("ProdutoVeiculoId")]
        public int? ProdutoVeiculoId { get; set; }

        [Column("ExibirRotuloCompleto")]
        public bool ExibirRotuloCompleto { get; set; }

        [Column("InativarFormula")]
        public bool InativarFormula { get; set; }

        [Column("EtiquetaId")]
        public int? EtiquetaId { get; set; }

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

        [Column("UnidadeDoseId")]
        public int? UnidadeDoseId { get; set; }

        public Unidade UnidadeDose { get; set; }

        [Column("DoseFormula")]
        public double DoseFormula { get; set; }

        [Column("GrupoProdutoVeiculoId")]
        public int? GrupoProdutoVeiculoId { get; set; }

        [Column("GrupoEmbalagemId")]
        public int? GrupoEmbalagemId { get; set; }

        [Column("GrupoCapsulaId")]
        public int? GrupoCapsulaId { get; set; }

        [Column("GrupoId")]
        public int? GrupoId { get; set; }

        public Grupo Grupo { get; set; }

        [Column("QuantidadeCapsulas")]
        public int? QuantidadeCapsulas { get; set; }
    }

    public enum TipoFormulaPadrao
    {
        BaseExcipienteSemiAcabado,
        Acabado,
        PreVenda,
        AcabadoPreVenda
    }
}
