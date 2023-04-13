using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class NovaSenha
    {
        [Column("Matricula")]
        [Required]
        public int Matricula { get; set; }

        [Column("Senha")]
        [Required]
        public string Senha { get; set; }

        [Column("Assinatura")]
        public string Assinatura { get; set; }

      
    }
}
