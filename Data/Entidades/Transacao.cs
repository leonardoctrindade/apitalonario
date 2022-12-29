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

        [Column("FornecedorId")]
        public int? FornecedorId { get; set; }

        public Fornecedor Fornecedor { get; set; }

        [Column("ClienteId")]
        public int? ClienteId { get; set; }

        [Column("ContaId")]
        public int? PlanoDeContaId { get; set; }

        public PlanoDeContas PlanoDeConta { get; set; }
    }
}
