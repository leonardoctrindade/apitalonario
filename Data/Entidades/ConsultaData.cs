using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class ConsultaData
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
        public string capacidadeDeCarga { get; set; }
        public string especie { get; set; }
        public string carroceria { get; set; }
        public string eixos { get; set; }
        public string cilindradas { get; set; }
        public string categoria { get; set; }
        public string tipoAutomovel { get; set; }
        public string cmt { get; set; }
        public string pbt { get; set; }
        public string potencia { get; set; }
        public object numeroCarroceria { get; set; }
        public object dataUltimaAtualizacao { get; set; }
        public object eixoTraseiro { get; set; }
        public object eixoAuxiliar { get; set; }
        public string restricao1 { get; set; }
        public string restricao2 { get; set; }
        public string restricao3 { get; set; }
        public string restricao4 { get; set; }
        public object cambio { get; set; }
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
        public string comunicacao_venda { get; set; }
        public string indicadorAlarme { get; set; }
        public string indicadorOstentaPIV { get; set; }
        public string indicadorPendenciaEmissao { get; set; }
        public string indicadorRecall1 { get; set; }
        public string indicadorRecall2 { get; set; }
        public string indicadorRecall3 { get; set; }
        public string indicadorRecallMontadora { get; set; }
        public string nomeArrendatario { get; set; }
        public string numeroIdentificacaoArrendatario { get; set; }
        public object orgaoRfb { get; set; }
        public object restricaoRfb { get; set; }
        public object paisTransferencia { get; set; }
        public string indicadorComunicacaoVenda { get; set; }
        public object dataRegistroVenda { get; set; }
        public object dataVenda { get; set; }
        public object nomeComprador { get; set; }
        public object numeroIdentificacaoComprador { get; set; }
        public string possuidorNome { get; set; }
        public string possuidorDocumento { get; set; }
        public DateTime requestCreated { get; set; }

    }

    public class Token
    {
        public object accessToken { get; set; }
        public object refreshToken { get; set; }
        public string apiToken { get; set; }
        public string userIdEncripted { get; set; }
    }

    public class ConsultaResponse
    {
        public ConsultaData data { get; set; }
        public bool isSucess { get; set; }
        public string message { get; set; }
        public object pdf { get; set; }
        public object parameter { get; set; }
        public Token token { get; set; }
        public object created { get; set; }
        public bool messageCript { get; set; }
        public object errors { get; set; }
    }
}
