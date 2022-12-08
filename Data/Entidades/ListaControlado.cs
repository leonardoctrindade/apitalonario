using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class ListaControlado
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Codigo")]
        [MaxLength(10)]
        [Required(ErrorMessage = "Campo código não preenchido")]
        public string Codigo { get; set; }

        [Column("Descricao")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo descrição não preenchido")]
        public string Descricao { get; set; }

        [Column("Tipo")]
        [Required(ErrorMessage = "Campo tipo não preenchido")]
        public int Tipo { get; set; }

        [Column("ReceitaObrigatorio")]
        public bool ReceitaObrigatorio { get; set; }
    }
}
