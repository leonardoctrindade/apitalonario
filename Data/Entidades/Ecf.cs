using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Data.Entidades
{
    public class Ecf
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("NumeroEquipamento")]
        [Required(ErrorMessage = "Campo de NumeroEquipamento não preenchido")]
        public int NumeroEquipamento { get; set; }

        [Column("NumeroSerie")]
        [MaxLength(30)]
        [Required(ErrorMessage = "Campo de NumeroSerie não preenchido")]
        public string NumeroSerie { get; set; }

        [Column("Marca")]
        public MarcaEcf Marca { get; set; }

        [Column("Modelo")]
        [MaxLength(20)]
        public string Modelo { get; set; }

        [Column("CniEcf")]
        [MaxLength(10)]
        public string CniEcf { get; set; }

        [Column("Cro")]
        public int? Cro { get; set; }

        [Column("TipoModelo")]
        public string TipoModelo { get; set; }

        [Column("OrdemUsuario")]
        public int? OrdemUsuario { get; set; }

        [Column("DataCadastroUsuario")]
        public DateTime? DataCadastroUsuario { get; set; }

        [Column("HoraCadastroUsuario")]
        public DateTime? HoraCadastroUsuario { get; set; }

        [Column("MfAdicional")]
        [MaxLength(1)]
        public char MfAdicional { get; set; }

        [Column("VersaoSb")]
        [MaxLength(10)]
        public string VersaoSb { get; set; }

        [Column("DataGravacaoSb")]
        public DateTime? DataGravacaoSb { get; set; }

        [Column("HoraGravacaoSb")]
        public DateTime? HoraGravacaoSb { get; set; }

        [Column("VersaoDll")]
        [MaxLength(10)]
        public string VersaoDll { get; set; }

        [Column("AcentoFormaPagamento")]
        public bool AcentoFormaPagamento { get; set; }

        [Column("MaiusculoFormaPagamento")]
        public bool MaisculoFormaPagamento { get; set; }

        [Column("SaltoFinalCupom")]
        public int? SaltoFinalCupom { get; set; } = 200;

        [Column("PafNumeroFabricacao")]
        [MaxLength(96)]
        public string PafNumeroFabricacao { get; set; } = "0";

        [Column("PafEcf")]
        [MaxLength(96)]
        public string PafEcf { get; set; }

        [Column("NumeroFabricacaoCripto")]
        [MaxLength(30)]
        public string NumeroFabricacaoCripto { get; set; }

        [Column("GrandeTotalCripto")]
        [MaxLength(30)]
        public string GrandeTotalCripto { get; set; }

        [Column("FilialId")]
        public int FilialId { get; set; }
    }

    public enum MarcaEcf
    {
        Bematech,
        Daruma,
        Schalter,
        Sweda,
        Elgin,
        Urano,
        DataRegis,
        Epson
    }
}
