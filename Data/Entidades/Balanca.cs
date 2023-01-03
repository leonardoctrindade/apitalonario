using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Balanca
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Modelo")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo de modelo não preenchido")]
        public string Modelo { get; set; }

        [Column("PortaCom")]
        [MaxLength(10)]
        [Required(ErrorMessage = "Campo de PortaCom não preenchido")]
        public string PortaCom { get; set; }

        [Column("BitsPorSegundo")]
        [MaxLength(10)]
        public string BitsPorSegundo { get; set; }

        [Column("Dtr")]
        [MaxLength(20)]
        public string Dtr { get; set; }

        [Column("BitsDeDados")]
        [MaxLength(10)]
        public string BitsDeDados { get; set; }

        [Column("Rts")]
        [MaxLength(20)]
        public string Rts { get; set; }

        [Column("Paridade")]
        [MaxLength(10)]
        public string Paridade { get; set; }

        [Column("XonXoff")]
        [MaxLength(20)]
        public string XonXoff { get; set; }

        [Column("Maquina")]
        [MaxLength(50)]
        public string Maquina { get; set; }

        [Column("SeparadorDecimal")]
        [MaxLength(10)]
        public string SeparadorDecimal { get; set; }

        [Column("Opcoes")]
        [MaxLength(150)]
        public string Opcoes { get; set; }

        [Column("DescricaoModelo")]
        [MaxLength(50)]
        public string DescricaoModelo { get; set; }
    }
}
