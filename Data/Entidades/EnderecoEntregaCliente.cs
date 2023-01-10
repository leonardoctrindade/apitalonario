using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class EnderecoEntregaCliente
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Titulo")]
        [Required(ErrorMessage = "Campo de titulo não preenchido")]
        [MaxLength(50)]
        public string Titulo { get; set; }

        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("Cep")]
        [MaxLength(8)]
        public string Cep { get; set; }

        [Column("Endereco")]
        [Required(ErrorMessage = "Campo de endereco não preenchido")]
        [MaxLength(100)]
        public string Endereco { get; set; }

        [Column("Numero")]
        [MaxLength(7)]
        public string Numero { get; set; }

        [Column("Complemento")]
        [MaxLength(255)]
        public string Complemento { get; set; }

        [Column("Proximidade")]
        [MaxLength(255)]
        public string Proximidade { get; set; }

        [Column("BairroId")]
        public int? BairroId { get; set; }

        [Column("RegiaoId")]
        public int? RegiaoId { get; set; }

        [Column("CidadeId")]
        public int? CidadeId { get; set; }

        [Column("EstadoId")]
        public int? EstadoId { get; set; }

        [Column("DddTelefone")]
        [MaxLength(4)]
        public string DddTelefone { get; set; }

        [Column("Telefone")]
        [MaxLength(20)]
        public string Telefone { get; set; }

        [Column("ContatoTelefone")]
        [MaxLength(50)]
        public string ContatoTelefone { get; set; }

        [Column("DddCelular")]
        [MaxLength(4)]
        public string DddCelular { get; set; }

        [Column("Celular")]
        [MaxLength(20)]
        public string Celular { get; set; }

        [Column("ContatoCelular")]
        [MaxLength(50)]
        public string ContatoCelular { get; set; }

        [Column("Email")]
        [MaxLength(255)]
        public string Email { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Column("ClienteId")]
        public int ClienteId { get; set; }

        [Column("Observacao")]
        [MaxLength(50)]
        public string Observacao { get; set; }
    }
}