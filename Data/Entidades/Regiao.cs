using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Regiao
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        [MaxLength(255)]
        [Required(ErrorMessage = "Campo de descricao não preenchido")]
        public string Descricao { get; set; }

        [Column("Taxa")]
        public double? Taxa { get; set; }

        [Column("IeSegunda")]
        public bool IeSegunda { get; set; }

        [Column("IeTerca")]
        public bool IeTerca { get; set; }

        [Column("IeQuarta")]
        public bool IeQuarta { get; set; }

        [Column("IeQuinta")]
        public bool IeQuinta { get; set; }

        [Column("IeSexta")]
        public bool IeSexta { get; set; }

        [Column("IeSabado")]
        public bool IeSabado { get; set; }

        [Column("IeDomingo")]
        public bool IeDomingo { get; set; }

        [Column("HoraInicialSegunda")]
        public DateTime HoraInicialSegunda { get; set; }

        [Column("HoraInicialTerca")]
        public DateTime? HoraInicialTerca { get; set; }

        [Column("HoraInicialQuarta")]
        public DateTime? HoraInicialQuarta { get; set; }

        [Column("HoraInicialQuinta")]
        public DateTime? HoraInicialQuinta { get; set; }

        [Column("HoraInicialSexta")]
        public DateTime? HoraInicialSexta { get; set; }

        [Column("HoraInicialSabado")]
        public DateTime? HoraInicialSabado { get; set; }

        [Column("HoraInicialDomingo")]
        public DateTime? HoraIncialDomingo { get; set; }

        [Column("HoraFinalSegunda")]
        public DateTime? HoraFinalSegunda { get; set; }

        [Column("HoraFinalTerca")]
        public DateTime HoraFinalTerca { get; set; }

        [Column("HoraFinalQuarta")]
        public DateTime HoraFinalQuarta { get; set; }

        [Column("HoraFinalQuinta")]
        public DateTime HoraFinalQuinta { get; set; }

        [Column("HoraFinalSexta")]
        public DateTime HoraFinalSexta { get; set; }

        [Column("HoraFinalSabado")]
        public DateTime HoraFinalSabado { get; set; }

        [Column("HoraFinalDomingo")]
        public DateTime HoraFinalDomingo { get; set; }

        [Column("NomeUsuario")]
        [MaxLength(20)]
        public string NomeUsuario { get; set; }

        [Column("NomeUsuarioRec")]
        [MaxLength(20)]
        public string NomeUsuarioRec { get; set; }

        [Column("DataAtualizacao")]
        public DateTime? DataAtualizacao { get; set; }

        [Column("DataAtualizacaoRec")]
        public DateTime? DataAtualizacaoRec { get; set; }
    }
}
