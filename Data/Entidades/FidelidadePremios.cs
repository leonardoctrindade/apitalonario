using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class FidelidadePremios
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("IdGrupo")]
        [Required(ErrorMessage = "Campo de grupo não preenchido")]
        public int IdGrupo { get; set; }

        [Column("IdProduto")]
        [Required(ErrorMessage = "Campo de produto não preenchido")]
        public int IdProduto { get; set; }

        [Column("Pontos")]
        [Required(ErrorMessage = "Campo de pontos não preenchido")]
        public int Pontos { get; set; }

        [Column("IdFidelidade")]
        [Required(ErrorMessage = "Campo de fidelidade não preenchido")]
        public int IdFidelidade { get; set; }
    }
}
