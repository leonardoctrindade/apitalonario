using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class FiltroComprasManutencao
    {


        //    tipo: string,
        //tipoDemanda: number | null,
        //vendaDe: string,
        //vendaDeHora: string,
        //vendaAte: string,
        //vendaAteHora: string,
        //curvaAbc: string,
        //consideraEncomendaFaltas: boolean,
        //tempoDeRep: number,
        //quantidadeDias: number,
        //tipoValor: number,
        //aPartirDe: string,
        //saldoQuantidadeComprometida: boolean,
        //laboratorioId: number,
        //fornecedoresIds: number[],
        //gruposIds: number[],
        //produtosIds: number[],


        #region Filtros - Tela de Manutenção

        public string tipo { get; set; }
        public int? tipoDemanda { get; set; }
        public int tipoValor { get; set; }
        public string curvaAbc { get; set; }
        public List<int> gruposIds { get; set; }
        public int laboratorioId { get; set; }
        public string vendaDe { get; set; }
        public string vendaDeHora { get; set; }
        public string vendaAte { get; set; }
        public string vendaAteHora { get; set; }
        public string aPartirDe { get; set; }
        public bool consideraEncomendaFaltas { get; set; }
        public int tempoDeRep { get; set; }
        public List<int> fornecedoresIds { get; set; }
        public List<int> produtosIds { get; set; }
        public int filialId { get; set; }
        public bool saldoQuantidadeComprometida { get; set; }
        public bool considerarApenasFilialSelecionada { get; set; }

        //public string tipo { get; set; }
        //public int? tipoDemanda { get; set; }
        //public int tipoValor { get; set; }
        //public string curvaAbc { get; set; }
        //public List<int> gruposIds { get; set; }
        //public int laboratorioId { get; set; }
        //public string vendaDe { get; set; }
        //public string vendaDeHora { get; set; }
        //public string vendaAte { get; set; }
        //public string vendaAteHora { get; set; }
        //public string aPartirDe { get; set; }
        //public bool consideraEncomendaFaltas { get; set; }
        //public int tempoDeRep { get; set; }
        //public List<int> fornecedoresIds { get; set; }
        //public List<int> produtosIds { get; set; }
        //public int filialId { get; set; }
        //public bool saldoQuantidadeComprometida { get; set; }
        //public bool considerarApenasFilialSelecionada { get; set; }
        #endregion
    }

    public class FiltroComprasManutencaoTeste
    {

        #region Filtros - Tela de Manutenção

        public string tipo { get; set; }
        public int? tipoDemanda { get; set; }
        public int tipoValor { get; set; }
        public string curvaAbc { get; set; }
        public List<int> gruposIds { get; set; }
        public int laboratorioId { get; set; }
        public string vendaDe { get; set; }
        public string vendaDeHora { get; set; }
        public string vendaAte { get; set; }
        public string vendaAteHora { get; set; }
        public string aPartirDe { get; set; }
        public bool consideraEncomendaFaltas { get; set; }
        public int tempoDeRep { get; set; }
        public List<int> fornecedoresIds { get; set; }
        public List<int> produtosIds { get; set; }
        public int filialId { get; set; }
        public bool saldoQuantidadeComprometida { get; set; }
        public bool considerarApenasFilialSelecionada { get; set; }


        #endregion


    }
}
