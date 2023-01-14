using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class GeralFarmacia
    {
        [Column("Id")]
        public int Id { get; set; }


        public int Arredondamento { get; set; }
        public string ArredondamentoCasasDecimais { get; set; }
        public string DuplicatasTaxaJurosPercentualMes { get; set; }
        public int AlterarValorVendaRecebida { get; set; }
        public int MensagemClienteDebito { get; set; }
        public int IntegracaoMatrizFilial { get; set; }
        public int BaixarFaltaEnc { get; set; }
        public bool ExportacaoCustosAtivarExportacaoCustos { get; set; }
        public DateTime ExportacaoCustosPastaDosArquivosDeEnvioResposta { get; set; }
        public int ExportacaoCustosOrigemDeVendaPadrao { get; set; }
        public DateTime ExportacaoCustosDataInicialUltimaCompra { get; set; }
        public int ConsideraConflitoDeDesconto { get; set; }
        public int LocalEntregaObrigatorio { get; set; }
        public string CurvaABCUltimaCurva { get; set; }
        public DateTime CurvaABCDataInicial { get; set; }
        public DateTime CurvaABCDataFinal { get; set; }
        public string CurvaABCAPorcentagem { get; set; }
        public string CurvaABCBPorcentagem { get; set; }
        public string CurvaABCCPorcentagem { get; set; }
        public string RecolhimentoICMSPositiva { get; set; }
        public string RecolhimentoICMSNegativa { get; set; }
        public string RecolhimentoICMSNeutra { get; set; }
        public string RecolhimentoICMSHigienePessoal { get; set; }
        public string FiltrosDiasVenda1 { get; set; }
        public string FiltrosDiasVenda2 { get; set; }
        public string FiltrosDiasCaixa1 { get; set; }
        public string FiltrosDiasCaixa2 { get; set; }
        public string FinanceiroMultaAtrasoPorcentagem { get; set; }
        public string FinanceiroToleranciaDias { get; set; }
        public string FinanceiroLimiteDescCaixa { get; set; }
        public int OrcamentoRejeitado { get; set; }
        public bool MarkupPadraoCodigoDeBarras { get; set; }
        public string FinanceiroJurosAtrasoAoDiaPorcentagem { get; set; }
        public bool MarkupPadraoNaoPermitirEntradaComValorIgualAoTotalDaVenda { get; set; }
        public bool MarkupPadraoAtivarEstoque { get; set; }
        public bool MarkupPadraoCaixaAposVenda { get; set; }
        public bool MarkupOperadorCaixaObrig { get; set; }
        public bool MarkupPlanosDeContasObrigatorio { get; set; }
        public bool MarkupPermitirOutraFilial { get; set; }
    }
}
