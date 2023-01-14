using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class ConvenioParametro
    {
            [Column("Id")]
            public int Id { get; set; }

            public string FuncionalCardConvenio { get; set; }
            public string FuncionalCardHost { get; set; }
            public string FuncionalCardLogin { get; set; }
            public string FuncionalCardSenha { get; set; }
            public string FuncionalCardNumeroVias { get; set; }
            public string IntegracaoBig { get; set; }
            public string IntegracaoBigEndereco { get; set; }
            public string IntegracaoBigCodAcesso { get; set; }
            public string IntegracaoBigSenha { get; set; }
            public string IntegracaoBigViasCupom { get; set; }
            public string VidaLinkEndereco { get; set; }
            public string VidaLinkBarras { get; set; }
            public string Agmed { get; set; }
            public string IntegracaoCgm { get; set; }
            public string AbcFarmaWebService { get; set; }
            public string AbcFarmaSenha { get; set; }
            public string PharmaLinkAutenticacao { get; set; }
            public string PharmaLinkLogin { get; set; }
            public string PharmaLinkSenha { get; set; }
            public string InfoMercAutenticacao { get; set; }
            public string InfoMercLogin { get; set; }
            public string InfoMercSenha { get; set; }
            public string ConvenioAfdar { get; set; }

    }
}
