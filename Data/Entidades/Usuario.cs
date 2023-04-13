using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Login")]
        [Required]
        public string Login { get; set; }

        [Column("Nome")]
        [Required]
        public string Nome { get; set; }

        [Column("Matricula")]
        [Required]
        public int Matricula { get; set; }

        [Column("Senha")]
        [Required]
        public string Senha { get; set; }

        [Column("Perfil")]
        [Required]
        public string Perfil { get; set; }

        [Column("DataInclusao")]
        [Required]
        public DateTime DataInclusao { get; set; }
    }
}
