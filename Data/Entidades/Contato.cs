using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class Contato
    {
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo de DDD não preenchido")]
        public int DDD { get; set; }

        [Required(ErrorMessage = "Campo de Telefone não preenchido")]
        public int Telefone { get; set; }

        public int Fax { get; set; }



        [Required(ErrorMessage = "Campo de Email não preenchido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo de WhatsApp não preenchido")]
        public int WhatsApp { get; set; }
    }
}
