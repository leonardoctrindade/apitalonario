using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class LimiteDeCompraCliente
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("LimiteDeCompra")]
        public double LimiteDeCompra { get; set; }

        [Column("BloqueioLimiteExcedido")]
        public bool BloqueioLimiteExcedido { get; set; }

        [Column("FormaPagamento")]
        public int FormaPagamento { get; set; }

        [Column("DiaPagamento")]
        public int DiaPagamento { get; set; }

        [Column("PrazoDias")]
        public int PrazoDias { get; set; }

        [Column("ClienteId")]
        [Required(ErrorMessage = "Campo de ClienteId não preenchido")]
        public int ClienteId { get; set; }
    }
}
