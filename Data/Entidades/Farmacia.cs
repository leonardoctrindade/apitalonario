using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class Farmacia
    {
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo de razão social não preenchido")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Campo de razão social não preenchido")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Campo de CNPJ não preenchido")]
        public int Cnpj { get; set; }
        public int InscricaoEstadual { get; set; }
        public int InscricaoMunicipal { get; set; }
        public int RegimeTributarioId { get; set; }

        [Required(ErrorMessage = "Campo de Contato não preenchido")]
        public Contato Contato { get; set; }

        [Required(ErrorMessage = "Campo de Endereço não preenchido")]
        public Endereco Endereco { get; set; }

        [Required(ErrorMessage = "Campo de Farmacecutico não preenchido")]
        public Farmaceutico Farmaceutico { get; set; }

        public int EnderecoId {get;set;}
        public int FarmaceuticoId { get; set; }
        public int ContatoId { get; set; }

        public int Ativo { get; set; }
        public DateTime? Data { get; set; }
        public DateTime? Hora { get; set; }

        [Required(ErrorMessage = "Campo Licenca Func não preenchido")]
        public string LicencaFunc { get; set; }


        [Required(ErrorMessage = "Campo Autoridade Sanitária não preenchido")]
        public string AutoridadeSanitaria { get; set; }


        [Required(ErrorMessage = "Campo Licenca Mapa não preenchido")]
        public string LicencaMapa { get; set; }

        [Required(ErrorMessage = "Campo Fornecedor Interno não preenchido")]
        public int FornecedorInternoId { get; set; }
    }
}
