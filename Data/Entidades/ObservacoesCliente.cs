using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class ObservacoesCliente
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("MensagemVenda")]
        [MaxLength(100)]
        public string MensagemVenda { get; set; }

        [Column("ObservacaoOp")]
        [MaxLength(100)]
        public string ObservacaoOp { get; set; }

        [Column("ObservacaoGeral")]
        public string ObservacaoGeral { get; set; }

        [Column("ClienteId")]
        [Required(ErrorMessage = "Campo de ClienteId não preenchido")]
        public int ClienteId { get; set; }
    }
}
