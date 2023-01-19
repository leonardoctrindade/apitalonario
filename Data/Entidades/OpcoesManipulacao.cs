using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class OpcoesManipulacao
    {
        [Column("Id")]
        public int Id { get; set; }
        public string BloqueiosVendaBloquearVendaDeFormulasLote { get; set; }
        public string BloqueiosVendaBloquearExcipientesSemLote { get; set; }
        public bool BloqueiosVendaBloquearEmbalagensCapsulasSemLote { get; set; }
        public bool HomeopatiaBloquearVendaDeFormulasSemLote { get; set; }
        public bool HomeopatiaBloquearVeiculoSemLote { get; set; }
        public bool HomeopatiaBloquearEmbalagensSemLote { get; set; }
        public bool HomeopatiaObrigarReceitaParaUsoUtopico { get; set; }
        public int ProcedenciaCalculo { get; set; }
        public int ProcedenciaCalculoDesconto { get; set; }
        public int CustoReferenciaNotaFiscal { get; set; }
        public int EstoqueNegativo { get; set; }
        public int DoseMaxima { get; set; }
        public string FiltrosEmDiaOp1 { get; set; }
        public string FiltrosEmDiaOp2 { get; set; }
        public int RepeticaoVendaSugestaoCapsula { get; set; }
        public int RepeticaoVendaQuantidadeCapsula { get; set; }
    }
}
