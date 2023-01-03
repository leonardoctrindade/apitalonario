using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Buffers.Text;

namespace Data.Entidades
{
    public class FormaFarmaceutica
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Descrição")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo de descricao não preenchido")]
        public string Descricao { get; set; }

        [Column("Inativo")]
        public bool Inativo { get; set; }

        [Column("Tipo")]
        [Required(ErrorMessage = "Campo de tipo não preenchido")]
        public TipoFormaFarmaceutica Tipo { get; set; }

        [Column("SelecionaQuantidadeSugerida")]
        public bool SelecionaQuantidadeSugerida { get; set; }

        [Column("MultiplicaComposicao")]
        public bool MultiplicaComposicao { get; set; }

        [Column("HomeopatiaLiquida")]
        public bool HomeopatiaLiquida { get; set; }

        [Column("DeduzirQuantidadeVeiculo")]
        public bool DeduzirQuantidadeVeiculo { get; set; }

        [Column("CalculoEmbalagemForma")]
        public int CalculoEmbalagemForma { get; set; }

        [Column("ConverteVolumeEmbalagem")]
        public bool ConverteVolumeEmbalagem { get; set; }

        [Column("Uso")]
        [MaxLength(20)]
        public string Uso { get; set; }

        [Column("TipoUso")]
        public int TipoUso { get; set; }

        [Column("POPForma")]
        [MaxLength(15)]
        public string POPForma { get; set; }

        [Column("ImprimirCamposAnalise")]
        public bool ImprimirCamposAnalise { get; set; }

        [Column("SelecionarVolumeAutomático")]
        public bool SelecionarVolumeAutomático { get; set; }

        [Column("Validade")]
        public int Validade { get; set; }

        [Column("MlGotas")]
        public double MlGotas { get; set; }

        [Column("ImprimirUnidadeMedidaNoRotulo")]
        public bool ImprimirUnidadeMedidaNoRotulo { get; set; }

        [Column("FatorPerdaProduto")]
        public double FatorPerdaProduto { get; set; }

        [Column("AtivaFatorPerdaQsp")]
        public bool AtivaFatorPerdaQsp { get; set; }

        [Column("ManipuladorId")]
        public int? ManipuladorId { get; set; }

        public FuncionarioLaboratorio Manipulador { get; set; }

        [Column("QuantidadeFormulasHora")]
        public int QuantidadeFormulasHora { get; set; }

        [Column("DescricaoRotulo")]
        [MaxLength(50)]
        public string DescricaoRotulo { get; set; }

        [Column("QuantidadeQspMinimo")]
        public double QuantidadeQspMinimo { get; set; }

        [Column("ProdutoVeiculoId")]
        public int? ProdutoVeiculoId { get; set; }

        public Produto ProdutoVeiculo { get; set; }

        [Column("GrupoVeiculoId")]
        public int? GrupoVeiculoId { get; set; }

        public Produto GrupoVeiculo { get; set; }

        [Column("AtivaPesagemMonitorada")]
        public bool AtivaPesagemMonitorada { get; set; }

        [Column("CalcularDensidade")]
        public bool CalcularDensidade { get; set; }

        [Column("ValorMinimo")]
        public double ValorMinimo { get; set; }

        [Column("CustoAdicional")]
        public double CustoAdicional { get; set; }

        [Column("NcmId")]
        public int? NcmId { get; set; }

        public Ncm Ncm { get; set; }

        [Column("CodigoLaboratorioLp")]
        [MaxLength(2)]
        public string CodigoLaboratorioLp { get; set; }

        [Column("CodigoFuncionarioManipulacao")]
        public int? CodigoFuncionarioManipulacao { get; set; }

        [Column("CodigoFormaReceituario")]
        public int? CodigoFormaReceituario { get; set; }

        [Column("CodigoFilialProducao")]
        public int? CodigoFilialProducao { get; set; }

        [Column("AliquotaIva")]
        public double AliquotaIva { get; set; }

        public string Imagem { get; set; }

        [Column("ImagemByte")]
        public byte[] ImagemByte { get; set; }
        public List<FormaFarmaceuticaMargem> FormaFarmaceuticaMargens { get; set; }
        public List<FormaFarmaceuticaEnsaio> FormaFarmaceuticaEnsaios { get; set; }
    }

    public enum TipoFormaFarmaceutica
    {
        Cápsula,
        Volume,
        Homeopatia,
        Floral,
        Unitário,
        VolumeXQtdePorcentagem,
        VolumeXQtdeMg,
        Papel,
        Implante,
        Comprimidos
    }
}
