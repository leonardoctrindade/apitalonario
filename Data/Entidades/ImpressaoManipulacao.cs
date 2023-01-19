]using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class ImpressaoManipulacao
    {
            [Column("Id")]
            public int Id { get; set; }
            public int Impressora { get; set; }
            public bool ModeloA5 { get; set; }
            public bool ImprimirOMNaVenda { get; set; }
            public bool ImprimirFamaceuticaNaOM { get; set; }
            public bool ImprimirCamposDeAnaliseProduto { get; set; }
            public bool ImprimirEnsaiosFormaFarmac { get; set; }
            public bool ImprimirAlinharEnsaios { get; set; }
            public int ImpressoraImprimir { get; set; }
            public string ImpressoraImprimirNumeroVias { get; set; }
            public bool DuplaPesagem { get; set; }
            public bool IgnorarSinOnimoNaOM { get; set; }
            public bool ExibirValorFormula { get; set; }
            public bool ExibirSublinhado { get; set; }
            public bool DestacaNumeroDeVenda { get; set; }
            public string NumeroVendas { get; set; }
            public int CodigoDeBarraPCP { get; set; }
    }
}
