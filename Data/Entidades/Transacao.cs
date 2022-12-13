using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Transacao
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Codigo")]
        public int Codigo { get; set; }

        [Column("Descricao")]
        [Required(ErrorMessage = "Campo de descrição não preenchido")]
        [MaxLength(250)]
        public string Descricao { get; set; }

        [Column("Tipo")]
        [Required(ErrorMessage = "Campo de tipo não preenchido")]
        public int Tipo { get; set; }

        [Column("Conciliar")]
        public bool Conciliar { get; set; }

        [Column("IdFornecedor")]
        public int IdFornecedor { get; set; }

        [Column("IdCliente")]
        public int IdCliente { get; set; }

        [Column("IdConta")]
        public int IdConta { get; set; }
    }
}
