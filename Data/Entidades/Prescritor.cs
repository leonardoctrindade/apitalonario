using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class Prescritor
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("IdBairro")]
        public int IdBairro { get; set; }
        [Column("IdCidade")]
        public int IdCidade { get; set; }
        [Column("IdEstado")]
        public int IdEstado { get; set; }
        [Column("Nome")]
        [Required]
        public string Nome { get; set; }
        [Column("Cep")]
        public string Cep { get; set; }
        [Column("Data_Nascimento")]
        public DateTime Data_Nascimento { get; set; }
        [Column("Endereco")]
        public string Endereco { get; set; }
        [Column("Numero")]
        public string Numero { get; set; }
        [Column("Complemento")]
        public string Complemento { get; set; }
        [Column("CpfCnpj")]
        public string CpfCnpj { get; set; }
        [Column("DDD")]
        public string DDD { get; set; }
        [Column("Telefone")]
        public string Telefone { get; set; }
        [Column("Celular")]
        public string Celular { get; set; }
        [Column("Secretaria")]
        public string Secretaria { get; set; }
        [Column("NomeRotulo")]
        public string NomeRotulo { get; set; }
        [Column("Ativo")]
        public bool Ativo { get; set; }
        [Column("Genero")]
        public Genero Genero { get; set; }
        [Column("TipoCr")]
        public TipoCr TipoCr { get; set; }
        [Column("CrmNumero")]
        [Required]
        public string CrmNumero { get; set; }
        [Column("CrmEstado")]
        [Required]
        public string CrmEstado { get; set; }
        [Column("CrmTipo")]
        public string CrmTipo { get; set; }
        [Column("IdEspecialidade")]
        public int IdEspecialidade { get; set; }
    }
    public enum Genero
    {
        Masculino,
        Feminino
    }
    public enum TipoCr
    {
        CRM,
        CRMV,
        CRO,
        OUTRO
    }
}
