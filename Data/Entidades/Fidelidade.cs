using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Fidelidade
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        [Required(ErrorMessage = "Campo de descricao não preenchido")]
        [MaxLength(50)]
        public string Descricao { get; set; }

        [Column("PontosIniciais")]
        public int PontosIniciais { get; set; }

        [Column("ValidadePontos")]
        public int ValidadePontos { get; set; }

        [Column("PontosPrimeiraCompra")]
        public int PontosPrimeiraCompra { get; set; }

        [Column("AvisoCliente")]
        public int AvisoCliente { get; set; }
    }
}
