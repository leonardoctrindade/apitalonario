using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class Etapa
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Descricao")]
        [Required]
        [MaxLength(50)]
        public string Descricao { get; set; }
        [Column("Sequencia")]
        [Required]
        public int Sequencia { get; set; }
        [Column("Tipo")]
        [Required]
        public string Tipo { get; set; }
        [Column("Processo")]
        public string Processo { get; set; }
        [Column("Obrigatoria")]
        public string Obrigatoria { get; set; }
        [Column("TempoMaximo")]
        public TimeSpan TempoMaximo { get; set; }
    }
}
