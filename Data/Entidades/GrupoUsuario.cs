using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class GrupoUsuario
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        [Required(ErrorMessage = "Campo de descrição não preenchido")]
        [MaxLength(50)]
        public string Descricao { get; set; }

        [Column("NivelGrupo")]
        public int NivelGrupo { get; set; } = 0;
    }
}
