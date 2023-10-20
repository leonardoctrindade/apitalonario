using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class ValoresMultas
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        public int Pontos { get; set; }
  
        public double Valor { get; set; }

        [NotMapped]
        public double ValorLiquido { get; set; }
        [NotMapped]
        public double ValorCincoPorcento { get; set; }

        [NotMapped]
        public string ValorString { get; set; }

        [NotMapped]
        public string Infracao { get; set; }

        [NotMapped]
        public int TotalMultas { get; set; }

        [NotMapped]
        public DateTime Data { get; set; }


        [NotMapped]
        public int TotalGeralMultas { get; set; }

        [NotMapped]
        public string ValorGeral { get; set; }


        [NotMapped]
        public string ValorGeralLiquido { get; set; }

        [NotMapped]
        public string ValorUnitarioString { get; set; }

        [NotMapped]
        public string Endereco { get; set; }
    }
}
