using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class ConfiguracoesPrismafive
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Secao")]
        [MaxLength(10)]
        [Required(ErrorMessage = "Campo de Secao não preenchido")]
        public string Secao { get; set; }

        [Column("Chave")]
        [MaxLength(20)]
        [Required(ErrorMessage = "Campo de chave não preenchido")]
        public string Chave { get; set; }

        [Column("UserMac")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo de UserMac não preenchido")]
        public string UserMac { get; set; }

        [Column("ValorIni")]
        [MaxLength(200)]
        public string ValorIni { get; set; }
    }
}
