﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class Transportador
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("IdBairro")]
        public int IdBairro { get; set; }
        [Column("IdCidade")]
        public int IdCidade { get; set; }
        [Column("IdEstado")]
        public int IdEstado { get; set; }
        [Column("IdEstadoPlaca")]
        public int IdEstadoPlaca { get; set; }
        [Column("Nome")]
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Column("CpfCnpj")]
        [Required]
        public string CpfCnpj { get; set; }
        [Column("Ie")]
        public string Ie { get; set; }
        [Column("Cep")]
        public string Cep { get; set; }
        [Column("Endereco")]
        public string Endereco { get; set; }
        [Column("Numero")]
        public string Numero { get; set; }
        [Column("DDD")]
        public string DDD { get; set; }
        [Column("Telefone")]
        public string Telefone { get; set; }
        [Column("CodigoAntt")]
        public string CodigoAntt { get; set; }
        [Column("Placa")]
        public string Placa { get; set; }
    }
}
