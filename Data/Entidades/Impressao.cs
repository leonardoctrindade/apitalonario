using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class Impressao
    {
        [Column("Id")]
        public int Id { get; set; }

        public int VendaTipo { get; set; }
        public int ReciboFidelidade { get; set; }
        public int Impressora { get; set; }
        public bool LadoALado { get; set; }

        public bool DestacaNumeroVenda { get; set; }

        public bool DestacaNomeCliente { get; set; }

        public bool CodigoDeBarras { get; set; }

        public int ImpressaoDeItensDeVenda { get; set; }

        public int ConfissaoDeDivida { get; set; }

        public string MensagemComprovanteLinha1 { get; set; }

        public string MensagemComprovanteLinha2 { get; set; }

        public bool ImprimirQuantidadeNoItem { get; set; }

        public bool ImprimirEtiquetaNaVenda { get; set; }

        public bool ImprimirFarmaceuticoNaEtiqueta { get; set; }

        public bool BloquearReimpressaoVendaOrdem { get; set; }

        public bool ImprimirCabecalho { get; set; }


        public string CabecalhoLinhaCupons { get; set; }

        public string CabecalhoNumeroVias { get; set; }


        public bool EtiquetaDeDebitoImprimirCabecalho { get; set; }


        public string EtiquetaDeDebitoNumeroVias { get; set; }
    }
}
