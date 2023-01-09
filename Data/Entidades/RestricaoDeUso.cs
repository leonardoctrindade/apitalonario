using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class RestricaoDeUso
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("GrupoId")]
        [Required(ErrorMessage = "Campo de GrupoId não preenchido")]
        public int GrupoId { get; set; }

        [Column("ProdutoId")]
        [Required(ErrorMessage = "Campo de ProdutoId não preenchido")]
        public int ProdutoId { get; set; }

        [Column("Observacao")]
        [MaxLength(100)]
        public string Observacao { get; set; }

        [Column("ClienteId")]
        [Required(ErrorMessage = "Campo de ClienteId não preenchido")]
        public int ClienteId { get; set; }
    }
}
