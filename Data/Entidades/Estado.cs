using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Estado
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Required]
        public string Nome { get; set; }

        [Column("Sigla")]
        [MaxLength(2, ErrorMessage = "A sigla não pode ter mais que 2 dígitos")]
        [MinLength(2, ErrorMessage = "A sigla não pode ter menos que 2 dígitos")]
        public string Sigla { get; set; }

        [Column("AliquotaIcmsEstado")]
        public decimal AliquotaIcmsEstado { get; set; }

        [Column("AliquotaFcpEstado")]
        public decimal AliquotaFcpEstado { get; set; }

        [Column("DifalComCalculoPorDentro")]
        public bool DifalComCalculoPorDentro { get; set; }

        [Column("DifalComCalculoDeIsento")]
        public bool DifalComCalculoDeIsento { get; set; }

        [Column("ChecagemContribuinteIsento")]
        public bool ChecagemContribuinteIsento { get; set; }

        [Column("IdPais")]
        [Required]
        public int IdPais { get; set; }

        [NotMapped]
        public List<Pais> Pais { get; set; }
    }
}
