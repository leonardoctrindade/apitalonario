using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class Visitador
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Cep")]
        public string Cep { get; set; }
        [Column("Endereco")]
        public string Endereco { get; set; }
        [Column("Numero")]
        public string Numero { get; set; }
        [Column("Complemento")]
        public string Complemento { get; set; }
        [Column("IdBairro")]
        public int IdBairro { get; set; }
        [Column("IdCidade")]
        public int IdCidade { get; set; }
        [Column("IdEstado")]
        public int IdEstado { get; set; }
        [Column("DDD")]
        public string DDD { get; set; }
        [Column("Telefone")]
        public string Telefone { get; set; }
        [Column("Celular")]
        public string Celular { get; set; }
        [Column("Comissao")]
        public double Comissao { get; set; }
    }
}
