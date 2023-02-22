using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    

    public class ManutencaoCompras
    {
        [Column("Id")]
        public int id { get; set; }

        public double? codigogrupo { get; set; }

        public double? estoque { get; set; }

        public string descricaoproduto { get; set; }

        public string nomelaboratorio { get; set; }

        public string curvaabcproduto { get; set; }

        public double? estoqueminimoproduto { get; set; }

        public double? estoquemaximoproduto { get; set; }



    }
}

