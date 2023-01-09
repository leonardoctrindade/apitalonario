using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Paciente
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Required(ErrorMessage = "Campo de Nome não preenchido")]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Column("DataNascimento")]
        public DateTime? DataNascimento { get; set; }

        [Column("Genero")]
        public int Genero { get; set; }

        [Column("CpfCnpj")]
        [MaxLength(18)]
        public string CpfCnpj { get; set; }

        [Column("Rg")]
        [MaxLength(20)]
        public string Rg { get; set; }

        [Column("OrgaoExpedidor")]
        [MaxLength(20)]
        public string OrgaoExpedidor { get; set; }

        [Column("EstadoExpedidorId")]
        public int EstadoExpedidorId { get; set; }

        [Column("DataExpedicao")]
        public DateTime DataExpedicao { get; set; }

        [Column("NomeRotulo")]
        [MaxLength(30)]
        public string NomeRotulo { get; set; }

        [Column("NaoAvisarUsoContinuo")]
        public bool NaoAvisarUsoContinuo { get; set; }

        [Column("Observacoes")]
        [MaxLength(100)]
        public string Observacoes { get; set; }

        [Column("PesoPaciente")]
        public double PesoPaciente { get; set; }

        [Column("EspecieId")]
        public int EspecieId { get; set; }

        [Column("ClienteId")]
        [Required(ErrorMessage = "Campo de ClienteId não preenchido")]
        public int ClienteId { get; set; }

        [Column("NumeroDocumento")]
        [MaxLength(20)]
        public string NumeroDocumento { get; set; }

        [Column("Acao")]
        public int Acao { get; set; }
    }
}
