using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    [Table("Agente")]
    public class Agente
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Matricula")]
        [Required]
        public int Matricula { get; set; }

        [Column("Nome")]
        [Required]
        public string Nome { get; set; }

        [Column("IMEI")]
        [Required]
        public string IMEI { get; set; }

        [Column("Senha")]
        [Required]
        public string Senha { get; set; }

        [Column("Assinatura")]
        public string Assinatura { get; set; }

        [Column("Ativo")]
        public int Ativo { get; set; }

        [Column("PrimeiroAcesso")]
        public int PrimeiroAcesso { get; set; }

        [Column("Cpf")]
        [Required]
        public string Cpf { get; set; }

        [Column("Cargo")]
        [Required]
        public string Cargo { get; set; }
    }
}
