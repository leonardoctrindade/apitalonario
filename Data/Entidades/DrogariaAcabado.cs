using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class DrogariaAcabado
    {
        public int Id { get; set; }
        public int CustoReferencia { get; set; }
        public int EstoqueNegativo { get; set; }
        public int AlteracaoValorVenda { get; set; }
        public bool EstoqueMinimoAvisarEstoqueMinimoNaVenda { get; set; }
    }
}
