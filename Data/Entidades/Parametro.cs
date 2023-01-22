using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class Parametro
    {
        public Farmacia Farmacia { get; set; }
        public Impressao Impressao { get; set; }
        public CupomFiscal CupomFiscal { get; set; }
        public ConvenioParametro ConvenioParametro { get; set; }
        public CartoesTEF CartoesTEF { get; set; }
        public NfeSped NfeSped { get; set; }
        public Nfe Nfe { get; set; }
        public GeralFarmacia GeralFarmacia { get; set; }
        public PrismaSync PrismaSync { get; set; }
        public Sipro Sipro { get; set; }
        public GestaoEntrega GestaoEntrega { get; set; }
        public GeralManipulacao GeralManipulacao { get; set; }
        public OpcoesManipulacao OpcoesManipulacao { get; set; }
        public ImpressaoManipulacao ImpressaoManipulacao { get; set; }
        public DrogariaAcabado DrogariaAcabado { get; set; }
    }
}
