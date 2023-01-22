using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entidades
{
    public class Parametro
    {
        [Column("Id")]
        public int Id { get; set; }
        public int idFarmacia { get; set; }
        public int idImpressao { get; set; }
        public int idCupomFiscal { get; set; }
        public int idConvenio { get; set; }
        public int idCartoesTEF { get; set; }
        public int idNfeSped { get; set; }
        public int idNfe { get; set; }
        public int idGeralFarmacia { get; set; }
        public int idPrismaSync { get; set; }
        public int idGestaoEntrega { get; set; }
        public int idGeralManipulacao { get; set; }
        public int idOpcoesManipulacao { get; set; }
        public int idImpressaoManipulacao { get; set; }
        public int idDrogariaAcabado { get; set; }
        public int idSipro { get; set; }
    }
}
