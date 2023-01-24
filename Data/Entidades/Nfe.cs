using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class Nfe
    {
        [Column("Id")]
        public int Id { get; set; }


        public string CaminhoSalvarNFSe { get; set; }
        public string LoginNFSe { get; set; }
        public string SenhaNFSe { get; set; }
        public string Identificacao { get; set; }
        public string Alvara { get; set; }
        public string AEDF { get; set; }

        public string Terminal { get; set; }
        public string IdCnae { get; set; }
        public bool CupomNfse { get; set; }

        public string ObservacaoPadrao { get; set; }
        public string CodigoAtividade { get; set; }
        public string CtIss { get; set; }


        public int Ambiente { get; set; }
        public string HashValidador { get; set; }

        public bool EnviarDescricaoCompletaNFSe { get; set; }
        public string DadosNfseCFOP { get; set; }

        public string DadosNfseSerie { get; set; }
        public string DadosNfseSubSerie { get; set; }

        public string DadosNfseCodigoTributacaoMunicipio { get; set; }
        public bool NfseSeparada { get; set; }
        public int ProvedorDeServico { get; set; }
        public string Aliquota { get; set; }


        public string CasasDecimaisXML { get; set; }

        public string AliquotaPIS { get; set; }
        public string AliquotaCofins { get; set; }
        public string AliquotaIR { get; set; }
        public string AliquotaCSLL { get; set; }

        public int Iss { get; set; }

    }
}
