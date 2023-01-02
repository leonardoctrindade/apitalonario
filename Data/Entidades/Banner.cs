using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Banner
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("Link")]
        public string Link { get; set; }

        [Column("AcaoLink")]
        public int AcaoLink { get; set; }

        [Column("Posicao")]
        [Required(ErrorMessage = "Campo de descricao não preenchido")]
        public int Posicao { get; set; }

        [Column("DataInicio")]
        public DateTime? DataInicio { get; set; }

        [Column("DataFim")]
        public DateTime? DataFim { get; set; }

        [Column("ImagemBanner")]
        public byte ImagemBanner { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Column("TipoDadoImagem")]
        public string TipoDadoImagem { get; set; }

        [Column("Integrados")]
        public string Integrados { get; set; }

        [Column("BannerMagentoId")]
        public int BannerMagentoId { get; set; }
    }
}
