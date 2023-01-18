using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Entregador
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [MaxLength(255)]
        [Required(ErrorMessage = "Campo de nome não preenchido")]
        public string Nome { get; set; }

        [Column("Cpf")]
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Column("Cnpj")]
        [MaxLength(14)]
        public string Cnpj { get; set; }

        [Column("IeEntregador")]
        [MaxLength(20)]
        public string IeEntregador { get; set; }

        [Column("Ddd")]
        [MaxLength(4)]
        [Required(ErrorMessage = "Campo de ddd não preenchido")]
        public string Ddd { get; set; }

        [Column("Telefone")]
        [Required(ErrorMessage = "Campo de telefone não preenchido")]
        [MaxLength(20)]
        public string Telefone { get; set; }

        [Column("Fax")]
        [MaxLength(20)]
        public string Fax { get; set; }

        [Column("Contato")]
        [MaxLength(50)]
        public string Contato { get; set; }

        [Column("TelefoneContato")]
        [MaxLength(20)]
        public string TelefoneContato { get; set; }

        [Column("Email")]
        [MaxLength(255)]
        public string Email { get; set; }

        [Column("EntregadorInativo")]
        public bool EntregadorInativo { get; set; }

        [Column("NomeUsuario")]
        [MaxLength(20)]
        public string NomeUsuario { get; set; }

        [Column("NomeUsuarioRec")]
        [MaxLength(20)]
        public string NomeUsuarioRec { get; set; }

        [Column("DataAtualizacao")]
        public DateTime? DataAtualizacao { get; set; }

        [Column("DataAtualizacaoRec")]
        public DateTime? DataAtualizacaoRec { get; set; }

        public List<EntregadorRegiao> EntregadorRegiao { get; set; }
    }
}
