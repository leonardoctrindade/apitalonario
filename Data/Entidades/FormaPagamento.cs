using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class FormaPagamento
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        [Required(ErrorMessage = "Campo de descrição não preenchido")]
        [MaxLength(50)]
        public string Descricao { get; set; }

        [Column("TipoFormaPagamento")]
        [Required(ErrorMessage = "Campo de tipo de forma de pagamento não preenchido")]
        public int TipoFormaPagamento { get; set; }

        [Column("AutorizarDescontos")]
        [Required(ErrorMessage = "Campo de autorização de descontos não preenchido")]
        public int AutorizarDescontos { get; set; }

        [Column("Conciliacao")]
        public bool Conciliacao { get; set; }

        [Column("IdConta")]
        public int IdConta { get; set; }
     }
}
