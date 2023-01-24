using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class NfeSped
    {
        [Column("Id")]
        public int Id { get; set; }

        public string CaminhoSalvarNfeCaminhoLongo { get; set; }
        public string NumeroCertificado { get; set; }
        public string CaminhoLongo { get; set; }
        public string ObservacaoPadrao { get; set; }
        public string ProtocoloTLS12 { get; set; }
        public string ImportarValorLiquidoDaVenda { get; set; }
        public string EmailServidorSmtp { get; set; }
        public string EmailPorta { get; set; }
        public string EmailUsuario { get; set; }
        public string EmailSenha { get; set; }
        public string EmailAssunto { get; set; }
        public string EmailEmCopia { get; set; }
        public bool EmailSMTPExigeConexaoSegura { get; set; }
        public int EmailSMTPExigeConexaoSeguraNenhuma { get; set; }
        public string EmailMensagem { get; set; }
        public int AmbienteHomologacao { get; set; }
        public bool ContigenciaEnviarDescricaoCompletaNFeMax120 { get; set; }
        public bool ContigenciaEmitirNfeEmContingencia { get; set; }
        public int TipoNotaFiscal { get; set; }
        public int SpedFiscalPerfil { get; set; }
        public int SpedFiscalTipoAtividade { get; set; }
        public string PercentualPartilhaIcms { get; set; }
        public string DocumentoFiscalPadrao { get; set; }
        public string NotaFiscalEletronica { get; set; }
        public string IdCnae { get; set; }
        public int SpedCofins { get; set; }
        public int CriterioDeEscrituracao { get; set; }
        public int TipoDeContribuicao { get; set; }
        public int MetodoDeApropriacaoDeCreditos { get; set; }
        public int TipoDeAtividade { get; set; }
    }
}
