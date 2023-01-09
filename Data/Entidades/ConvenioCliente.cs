using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class ConvenioCliente
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("ConvenioId")]
        [Required(ErrorMessage = "Campo de ConvenioId não preenchido")]
        public int ConvenioId { get; set; }

        [Column("Numero")]
        public string Numero { get; set; }

        [Column("EmUso")]
        public bool EmUso { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Column("ClienteId")]
        [Required(ErrorMessage = "Campo de ClienteId não preenchido")]
        public int ClienteId { get; set; }  
    }
}
