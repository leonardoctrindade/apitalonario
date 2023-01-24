using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class Endereco
    {
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo de Cep não preenchido")]
        public string Cep { get; set; }


        [Required(ErrorMessage = "Campo de Logradouro não preenchido")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo de Numero não preenchido")]
        public int Numero { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo de Cidade não preenchido")]
        public int IdCidade { get; set; }

        [Required(ErrorMessage = "Campo de Estado não preenchido")]
        public int IdEstado { get; set; }

        [Required(ErrorMessage = "Campo de Bairro não preenchido")]
        public int IdBairro { get; set; }
    }
}
