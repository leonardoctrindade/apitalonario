using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class ConsultaChassi
    {
        public class InformacaoChassi
        {
            public List<DadosChassi> data { get; set; }
            public bool isSucess { get; set; }
            public string message { get; set; }
            public object parameter { get; set; }
            public object token { get; set; }
            public DateTime created { get; set; }
            public bool messageCript { get; set; }
            public object errors { get; set; }
        }

        public class DadosChassi
        {
            public string placa { get; set; }
            public string situacao { get; set; }
            public string marcaModelo { get; set; }
            public string chassi { get; set; }
            public string chassiRemarcado { get; set; }
            public string motor { get; set; }
            public string renavam { get; set; }
            public string cor { get; set; }
            public string ano { get; set; }
            public string municipioUf { get; set; }
            public string docProprietario { get; set; }
            public string proprietario { get; set; }
            public string combustivel { get; set; }
            public string procedencia { get; set; }
            public string qtdePassageiros { get; set; }
            public object capacidadeDeCarga { get; set; }
            public string especie { get; set; }
            public string carroceria { get; set; }
            public object eixos { get; set; }
            public string cilindradas { get; set; }
            public string categoria { get; set; }
            public string tipoAutomovel { get; set; }
            public object cmt { get; set; }
            public object pbt { get; set; }
            public string potencia { get; set; }
            public string numeroCarroceria { get; set; }
            public string dataUltimaAtualizacao { get; set; }
            public object eixoTraseiro { get; set; }
            public object eixoAuxiliar { get; set; }
            public string restricao1 { get; set; }
            public string restricao2 { get; set; }
            public string restricao3 { get; set; }
            public string restricao4 { get; set; }
            public string cambio { get; set; }
            public object tipoMontagem { get; set; }
            public object codSRF { get; set; }
            public object numDI { get; set; }
            public object dataRegistroDI { get; set; }
            public object numIdentImportador { get; set; }
            public object tipoDocImportador { get; set; }
            public object identFaturado { get; set; }
            public object tipoDocFaturado { get; set; }
            public object ufFaturado { get; set; }
            public string dataEmplacamento { get; set; }
            public object dataLimiteRestTrib { get; set; }
            public string ocorrencia { get; set; }
            public string restricaoJudicial { get; set; }
            public string dataEmissaoCrv { get; set; }
            public object comunicacao_venda { get; set; }
            public object indicadorAlarme { get; set; }
            public object indicadorOstentaPIV { get; set; }
            public string IndicadorPendenciaEmissao { get; set; }
            public string IndicadorRecall1 { get; set; }
            public string IndicadorRecall2 { get; set; }
            public string IndicadorRecall3 { get; set; }
            public string IndicadorRecallMontadora { get; set; }
            public string NomeArrendatario { get; set; }
            public string NumeroIdentificacaoArrendatario { get; set; }
            public string OrgaoRfb { get; set; }
            public string RestricaoRfb { get; set; }
            public string PaisTransferencia { get; set; }
            public string IndicadorComunicacaoVenda { get; set; }
            public string DataRegistroVenda { get; set; }
            public string DataVenda { get; set; }
            public string NomeComprador { get; set; }
            public string NumeroIdentificacaoComprador { get; set; }
            public string PossuidorNome { get; set; }
            public string PossuidorDocumento { get; set; }
            public DateTime RequestCreated { get; set; }
        }
    }
}
