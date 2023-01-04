using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Etiqueta
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo de descrição não preenchido")]
        public string Descricao { get; set; }

        [Column("Tipo")]
        [Required(ErrorMessage = "Campo de tipo não preenchido")]
        public TipoEtiqueta Tipo { get; set; }

        [Column("MargemSuperior")]
        [Required(ErrorMessage = "Campo de margem superior não preenchido")]
        public double MargemSuperior { get; set; }

        [Column("MargemLateral")]
        [Required(ErrorMessage = "Campo de margem lateral não preencido")]
        public double MargemLateral { get; set; }

        [Column("AlturaEtiqueta")]
        [Required(ErrorMessage = "Campo de altura etiqueta não preenchido")]
        public double AlturaEtiqueta { get; set; }

        [Column("LarguraEtiqueta")]
        [Required(ErrorMessage = "Campo de largura etiqueta não preenchido")]
        public double LarguraEtiqueta { get; set; }

        [Column("DistanciaVertical")]
        [Required(ErrorMessage = "Campo de distancia vertical não preenchido")]
        public double DistanciaVertical { get; set; }

        [Column("DistanciaHorizontal")]
        [Required(ErrorMessage = "Campo de distancia horizontal não preenchido")]
        public double DistanciaHorizontal { get; set; }

        [Column("LinhasPorPagina")]
        [Required(ErrorMessage = "Campo de linhas por pagina não preenchido")]
        public int LinhasPorPagina { get; set; }

        [Column("ColunasPorPagina")]
        [Required(ErrorMessage = "Campo de colunas por pagina não preenchido")]
        public int ColunasPorPagina { get; set; }

        [Column("LayoutEtiquetaEntrada")]
        [Required(ErrorMessage = "Campo de layout etiqueta entrada não preenchido")]
        public int LayoutEtiquetaEntrada { get; set; }

        [Column("TextoCabecalho")]
        [MaxLength(160)]
        public string TextoCabecalho { get; set; }

        [Column("TextoRodape")]
        [MaxLength(160)]
        public string TextoRodape { get; set; }

        [Column("Observacao")]
        [MaxLength(50)]
        public string Observacao { get; set; }

        [Column("LinhasPorEtiqueta")]
        [Required(ErrorMessage = "Campo de linhas por etiqueta não preenchido")]
        public int LinhasPorEtiqueta { get; set; }

        [Column("EspacoEntreLinhas")]
        [Required(ErrorMessage = "Campo de espaço entre linhas não preenchido")]
        public double EspacoEntreLinhas { get; set; }

        [Column("DefinirEtiquetaPadrao")]
        public bool DefirnirEtiquetaPadrao { get; set; }

        [Column("CodigoDeBarraVertical")]
        public bool CodigoDeBarraVertical { get; set; }

        [Column("RetirarEspacoEntreUnidEQtd")]
        public bool RetirarEspacoEntreUnidEQtd { get; set; }

        [Column("LayoutWeleda")]
        public int? LayoutWeleda { get; set; }

        [Column("TipoModeloEtiqueta")]
        public int? TipoModeloEtiquta { get; set; }

        [Column("ModeloImagem")]
        public byte[] ModeloImagem { get; set; }

        [NotMapped]
        public string Imagem { get; set; }

        [Column("FilialId")]
        public int? FilialId { get; set; }

        [Column("TipoLayoutEtiquetaPersonalizado")]
        public bool TipoLayoutEtiquetaPersonalizado { get; set; }
    }

    public enum TipoEtiqueta
    {
        RotulagemVenda,
        RotulagemEstoque,
        MalaDireta,
        PrecoAcabado,
        FormulaPadrao,
        Receita,
    }
}
