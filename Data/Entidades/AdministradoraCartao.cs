using System;
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
        public Gerenciador Gerenciador { get; set; }

        [Column("CieloPremia")]
        public CieloPremia? CieloPremia { get; set; }

        [Column("Modalidade")]
        [Required]
        public int Modalidade { get; set; } = 0;

        [Column("Ativo")]
        public bool Ativo { get; set; } = true;

        [Column("FornecedorId")]
        public int FornecedorId { get; set; }

        [Column("ContaId")]
        public int ContaId { get; set; }

        public Fornecedor Fornecedor { get; set; }

        public PlanoDeContas Conta { get; set; }
    }

    public enum Gerenciador
    {
        VisaMasterAmex,
        BanriCompras,
        ConvCard,
        EDMCard,
        HiperCard,
        Integracao4S
    }

    public enum CieloPremia
    {
        Troco,
        Desconto,
        ViasDiferenciadas,
        CupomReduzido
    }
}
