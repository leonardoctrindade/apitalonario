using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class GeralManipulacao
    {
        public int Id { get; set; }
        public string PrevisaoEntregaHoras { get; set; }
        public string FormulasHoras { get; set; }
        public string MargemSegurancaPadraoPercentual { get; set; }
        public string TipoCRPadrao { get; set; }
        public string ExcipientePadrao { get; set; }
        public string MLGotas { get; set; }
        public string FarmacopeiaPadrao { get; set; }
        public string ValorPadrao { get; set; }
        public string ValidadeHomeopatia { get; set; }
        public bool PesagemMonitorada { get; set; }
        public bool AvisarEstoqueMinimoDeVenda { get; set; }
        public bool EntregarRegistroReceituarioGeral { get; set; }
        public bool ValidadeFormulaPorLote { get; set; }
        public bool HabilitaPCP { get; set; }
        public bool PesagemAutomatizadaDosItens { get; set; }
        public bool HabilitaQuarentena { get; set; }
        public bool DeduzirQuantidadeLoteAnteriorDaDinamizacao { get; set; }
        public bool BuscaultimoFatorLoteOrcamentoUIUFCUTR { get; set; }
        public bool ManterValorDaPreVenda { get; set; }
        public bool ExibirQSPAutomático { get; set; }
        public int FormatacaoBSPO { get; set; }
        public int MetodoDeAnalise { get; set; }
        public int AlterarPesoDoProduto { get; set; }
        public string AmostragemAmostras { get; set; }
        public string AmostragemPercentual { get; set; }
        public string AmostragemLimiteMenorIgualPercentual { get; set; }
        public string AmostragemLimiteMaiorIgualPercentual { get; set; }
        public string AmostragemQuantidadeG { get; set; }
        public string AmostragemDesPadraoRelat { get; set; }
        public string AmostragemQtdTeoricaMin { get; set; }
        public string AmostragemQtdTeoricaMax { get; set; }
    }
}