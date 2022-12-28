using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entidades
{
    public class Categoria
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo de nome não preenchido")]
        public string Nome { get; set; }

        [Column("CategoriaPaiId")]
        public int? CategoriaPaiId { get; set; }

        public Categoria CategoriaPai { get; set; }

        [Column("CategoriaAtiva")]
        public bool CategoriaAtivo { get; set; }

        [Column("CategoriaMagentoId")]
        public int? CategoriaMagentoId { get; set; }

        [Column("Integrados")]
        public bool Integrados { get; set; }

        [Column("Excluidos")]
        public bool Excluidos { get; set; }

        [Column("AlteradoPais")]
        public bool AlteradoPais { get; set; }

        
    }
}
