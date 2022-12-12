using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Tributo
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Tipo")]
        [Required]
        public int TipoTributo { get; set; }

        [Column("Descricao")]
        [Required(ErrorMessage = "Campo de descrição não preenchido")]
        [MaxLength(1000)]
        public string Descricao { get; set; }

        [Column("Codigo")]
        [Required(ErrorMessage = "Campo de código não preenchido")]
        [MaxLength(10)]
        public string Codigo { get; set; }
    }
    /*
        Tipos de Tributo: 
     
        CST = 0,
        CSOSN = 1,
        SituacaoDocumento = 2,
        DocumentosFiscais = 3,
        CstPisCofins = 4,
        CstIss = 5,
        CFPS = 6,
        CEST = 7,
        CodigoBeneficioFiscal = 8,
        CstIpi = 9
    */
}
