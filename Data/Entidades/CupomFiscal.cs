using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class CupomFiscal
    {
        [Column("Id")]
        public int Id { get; set; }

        public bool ImprimeConfissaoDeDivida { get; set; }

        public bool HabilitaCAT52 { get; set; }

        public bool ImprimeComprovanteDeRecebimento { get; set; }

        public string MensagemCupomLinha1 { get; set; }

        public string MensagemCupomLinha2 { get; set; }

        public string MensagemCupoWbFisico { get; set; }

        public bool NFCeHabilitarNFCe { get; set; }

        public bool NFCeImprimeConfissaoDeDivida { get; set; }

        public bool NFCeImprimeComprovanteDeRecebimento { get; set; }

        public bool NFCeOpcaoPrisma5DLLNFCe { get; set; }

        public bool NFCeProtocoloTLSv12 { get; set; }

        public bool NFCeExibeDescontoItemNFCe { get; set; }

        public string NFCeAliquotaDeISS { get; set; }

        public bool NFCeEmitirNFCeEmContingencia { get; set; }

        public bool NFCeEmitirNFCeEmContingenciaOffLine { get; set; }

        public bool NFCeEmitirNFCeEmContingenciaAutomatica { get; set; }

        public string NFCeIdToken1 { get; set; }
        public string NFCeIdToken2 { get; set; }
        public string NFCeCSCQrCode { get; set; }

        public bool NFCeEnviarDescricaoCompletaNFCe { get; set; }
        public string NFCeObservacaoNFCe { get; set; }

        public bool SATMFEHabilitarSAT { get; set; }

        public bool SATMFEHabilitarMFE { get; set; }

        public bool SATMFEAmbienteHomologacao { get; set; }

        public bool SATMFEAmbienteProducao { get; set; }


        public string SATMFEChaveAtivacao { get; set; }

        public string SATMFEAssinaturaSoft { get; set; }

        public string SATMFEVersaoSAT { get; set; }

        public int SATMFEFuncoesSAT { get; set; }

        public string SATMFEEntrada { get; set; }

        public string SATMFESaida { get; set; }

        public int OutrosImpressaoNFCeSAT { get; set; }

        public string OutrosMFEChaveAcessoValidador { get; set; }

        public string OutrosMFEChaveAcessoRequisicao { get; set; }
    }
}
