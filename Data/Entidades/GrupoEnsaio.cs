using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class GrupoEnsaio
    {
        [Column("Id")]
        public int Id { get; set; }

        [NotMapped]
        [MaxLength(50)]
        public string Descricao { get; set; }

        [Column("GrupoId")]
        [Required(ErrorMessage = "Campo de GrupoId não preenchido")]
        public int GrupoId { get; set; }

        public Grupo Grupo { get; set; }

        [Column("EnsaioId")]
        [Required(ErrorMessage = "Campo de EnsaioId não preenchido")]
        public int EnsaioId { get; set; }

        public Ensaio Ensaio { get; set; }
    }
}
