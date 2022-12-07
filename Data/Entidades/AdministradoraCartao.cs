﻿using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class AdministradoraCartao
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo de nome não preenchido")]
        public string Nome { get; set; }

        [Column("PrazoRecebimento")]
        public int PrazoRecebimento { get; set; }

        [Column("Desconto")]
        public decimal Desconto { get; set; }

        [Column("Gerenciador")]
        [Required(ErrorMessage = "Campo de gerenciador não preenchido")]
        public int Gerenciador { get; set; }

        [Column("CieloPremia")]
        public int CieloPremia { get; set; } = 0;

        [Column("Modalidade")]
        [Required]
        public int Modalidade { get; set; } = 0;

        [Column("Ativo")]
        public bool Ativo { get; set; } = true;

        [Column("IdFornecedor")]
        public int IdFornecedor { get; set; }

        [Column("IdConta")]
        public int IdConta { get; set; }
    }
}