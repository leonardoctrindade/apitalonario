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
        [MaxLength(100)]
        [Required(ErrorMessage = "Campo de descricao não preenchido")]
        public string Descricao { get; set; }

        [Column("Link")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Campo de link não preenchido")]
        public string Link { get; set; }

        [Column("AcaoLink")]
        [Required(ErrorMessage = "Campo de AcaoLink não preenchido")]
        public int AcaoLink { get; set; }

        [Column("Posicao")]
        [Required(ErrorMessage = "Campo de posicao não preenchido")]
        public int Posicao { get; set; }

        [Column("DataInicio")]
        [Required(ErrorMessage = "Campo de DataInicio não preenchido")]
        public DateTime? DataInicio { get; set; }

        [Column("DataFim")]
        [Required(ErrorMessage = "Campo de DataFim não preenchido")]
        public DateTime? DataFim { get; set; }

        [Column("ImagemBanner")]
        [Required(ErrorMessage = "Campo de ImagemBanner não preenchido")]
        public byte[] ImagemBanner { get; set; }

        [NotMapped]
        public string Imagem { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Column("TipoDadoImagem")]
        [MaxLength(5)]
        public string TipoDadoImagem { get; set; }

        [Column("Integrados")]
        [MaxLength(1)]
        public string Integrados { get; set; }

        [Column("BannerMagentoId")]
        public int? BannerMagentoId { get; set; }
    }
}
