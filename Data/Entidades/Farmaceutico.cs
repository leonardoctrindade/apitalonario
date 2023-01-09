using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class Farmaceutico
    {
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo de Farmaceutico não preenchido")]
        public string NomeFarmaceutico { get; set; }

        [Required(ErrorMessage = "Campo de CRF não preenchido")]
        public string CRF { get; set; }

        [Required(ErrorMessage = "Campo Cpf Resp SNGPC CRF não preenchido")]
        public int CpfRespSNGPC { get; set; }


        [Required(ErrorMessage = "Campo Usuário SNGPC não preenchido")]
        public string UsuarioSNGPC { get; set; }

        [Required(ErrorMessage = "Campo Senha SNGPC não preenchido")]
        public string SenhaSNGPC { get; set; }
    }
}
