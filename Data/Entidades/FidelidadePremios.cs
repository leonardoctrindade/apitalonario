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

        [Column("GrupoId")]
        [Required(ErrorMessage = "Campo de grupo não preenchido")]
        public int? GrupoId { get; set; }

        public Grupo Grupo { get; set; }

        [Column("ProdutoId")]
        [Required(ErrorMessage = "Campo de produto não preenchido")]
        public int? ProdutoId { get; set; }

        public Produto Produto { get; set; }

        [Column("Pontos")]
        [Required(ErrorMessage = "Campo de pontos não preenchido")]
        public int Pontos { get; set; }

        [Column("FidelidadeId")]
        [Required(ErrorMessage = "Campo de fidelidade não preenchido")]
        public int FidelidadeId { get; set; }

        public Fidelidade Fidelidade { get; set; }
    }
}
