using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockEtiqueta
    {
        public static Etiqueta MontaObjetoUnico()
        {
            return new Etiqueta
            {
                Id = 1,
                Descricao = "Teste Mock 1",
                Tipo = TipoEtiqueta.MalaDireta,
                MargemSuperior = 123,
                MargemLateral = 123,
                AlturaEtiqueta = 123,
                LarguraEtiqueta = 123,
                DistanciaVertical = 123,
                DistanciaHorizontal = 123,
                LinhasPorPagina = 123,
                ColunasPorPagina = 123,
                LayoutEtiquetaEntrada = 123,
                TextoCabecalho = "Teste Mock 1",
                TextoRodape = "Teste Mock 1",
                Observacao = "Teste Mock 1",
                LinhasPorEtiqueta = 123,
                EspacoEntreLinhas = 123,
                DefirnirEtiquetaPadrao = true,
                CodigoDeBarraVertical = true,
                RetirarEspacoEntreUnidEQtd = true,
                LayoutWeleda = 1,
                TipoModeloEtiquta = 1,
                FilialId = 1,
                TipoLayoutEtiquetaPersonalizado = true
            };
        }

        public static Etiqueta MontaObjetoDescricaoVazia()
        {
            return new Etiqueta
            {
                Id = 1,
                Descricao = null,
                Tipo = TipoEtiqueta.MalaDireta,
                MargemSuperior = 123,
                MargemLateral = 123,
                AlturaEtiqueta = 123,
                LarguraEtiqueta = 123,
                DistanciaVertical = 123,
                DistanciaHorizontal = 123,
                LinhasPorPagina = 123,
                ColunasPorPagina = 123,
                LayoutEtiquetaEntrada = 123,
                TextoCabecalho = "Teste Mock 1",
                TextoRodape = "Teste Mock 1",
                Observacao = "Teste Mock 1",
                LinhasPorEtiqueta = 123,
                EspacoEntreLinhas = 123,
                DefirnirEtiquetaPadrao = true,
                CodigoDeBarraVertical = true,
                RetirarEspacoEntreUnidEQtd = true,
                LayoutWeleda = 1,
                TipoModeloEtiquta = 1,
                FilialId = 1,
                TipoLayoutEtiquetaPersonalizado = true
            };
        }

        public static Etiqueta MontaObjetoMargemSuperiorInvalida()
        {
            return new Etiqueta
            {
                Id = 1,
                Descricao = "Teste Mock 1",
                Tipo = TipoEtiqueta.MalaDireta,
                MargemSuperior = -123,
                MargemLateral = 123,
                AlturaEtiqueta = 123,
                LarguraEtiqueta = 123,
                DistanciaVertical = 123,
                DistanciaHorizontal = 123,
                LinhasPorPagina = 123,
                ColunasPorPagina = 123,
                LayoutEtiquetaEntrada = 123,
                TextoCabecalho = "Teste Mock 1",
                TextoRodape = "Teste Mock 1",
                Observacao = "Teste Mock 1",
                LinhasPorEtiqueta = 123,
                EspacoEntreLinhas = 123,
                DefirnirEtiquetaPadrao = true,
                CodigoDeBarraVertical = true,
                RetirarEspacoEntreUnidEQtd = true,
                LayoutWeleda = 1,
                TipoModeloEtiquta = 1,
                FilialId = 1,
                TipoLayoutEtiquetaPersonalizado = true
            };
        }

        public static Etiqueta MontaObjetoMargemLateralInvalida()
        {
            return new Etiqueta
            {
                Id = 1,
                Descricao = "Teste Mock 1",
                Tipo = TipoEtiqueta.MalaDireta,
                MargemSuperior = 123,
                MargemLateral = -123,
                AlturaEtiqueta = 123,
                LarguraEtiqueta = 123,
                DistanciaVertical = 123,
                DistanciaHorizontal = 123,
                LinhasPorPagina = 123,
                ColunasPorPagina = 123,
                LayoutEtiquetaEntrada = 123,
                TextoCabecalho = "Teste Mock 1",
                TextoRodape = "Teste Mock 1",
                Observacao = "Teste Mock 1",
                LinhasPorEtiqueta = 123,
                EspacoEntreLinhas = 123,
                DefirnirEtiquetaPadrao = true,
                CodigoDeBarraVertical = true,
                RetirarEspacoEntreUnidEQtd = true,
                LayoutWeleda = 1,
                TipoModeloEtiquta = 1,
                FilialId = 1,
                TipoLayoutEtiquetaPersonalizado = true
            };
        }

        public static Etiqueta MontaObjetoAlturaEtiquetaInvalida()
        {
            return new Etiqueta
            {
                Id = 1,
                Descricao = "Teste Mock 1",
                Tipo = TipoEtiqueta.MalaDireta,
                MargemSuperior = 123,
                MargemLateral = 123,
                AlturaEtiqueta = -123,
                LarguraEtiqueta = 123,
                DistanciaVertical = 123,
                DistanciaHorizontal = 123,
                LinhasPorPagina = 123,
                ColunasPorPagina = 123,
                LayoutEtiquetaEntrada = 123,
                TextoCabecalho = "Teste Mock 1",
                TextoRodape = "Teste Mock 1",
                Observacao = "Teste Mock 1",
                LinhasPorEtiqueta = 123,
                EspacoEntreLinhas = 123,
                DefirnirEtiquetaPadrao = true,
                CodigoDeBarraVertical = true,
                RetirarEspacoEntreUnidEQtd = true,
                LayoutWeleda = 1,
                TipoModeloEtiquta = 1,
                FilialId = 1,
                TipoLayoutEtiquetaPersonalizado = true
            };
        }

        public static Etiqueta MontaObjetoLarguraEtiquetaInvalida()
        {
            return new Etiqueta
            {
                Id = 1,
                Descricao = "Teste Mock 1",
                Tipo = TipoEtiqueta.MalaDireta,
                MargemSuperior = 123,
                MargemLateral = 123,
                AlturaEtiqueta = 123,
                LarguraEtiqueta = -123,
                DistanciaVertical = 123,
                DistanciaHorizontal = 123,
                LinhasPorPagina = 123,
                ColunasPorPagina = 123,
                LayoutEtiquetaEntrada = 123,
                TextoCabecalho = "Teste Mock 1",
                TextoRodape = "Teste Mock 1",
                Observacao = "Teste Mock 1",
                LinhasPorEtiqueta = 123,
                EspacoEntreLinhas = 123,
                DefirnirEtiquetaPadrao = true,
                CodigoDeBarraVertical = true,
                RetirarEspacoEntreUnidEQtd = true,
                LayoutWeleda = 1,
                TipoModeloEtiquta = 1,
                FilialId = 1,
                TipoLayoutEtiquetaPersonalizado = true
            };
        }

        public static Etiqueta MontaObjetoDistanciaVerticalInvalida()
        {
            return new Etiqueta
            {
                Id = 1,
                Descricao = "Teste Mock 1",
                Tipo = TipoEtiqueta.MalaDireta,
                MargemSuperior = 123,
                MargemLateral = 123,
                AlturaEtiqueta = 123,
                LarguraEtiqueta = 123,
                DistanciaVertical = -123,
                DistanciaHorizontal = 123,
                LinhasPorPagina = 123,
                ColunasPorPagina = 123,
                LayoutEtiquetaEntrada = 123,
                TextoCabecalho = "Teste Mock 1",
                TextoRodape = "Teste Mock 1",
                Observacao = "Teste Mock 1",
                LinhasPorEtiqueta = 123,
                EspacoEntreLinhas = 123,
                DefirnirEtiquetaPadrao = true,
                CodigoDeBarraVertical = true,
                RetirarEspacoEntreUnidEQtd = true,
                LayoutWeleda = 1,
                TipoModeloEtiquta = 1,
                FilialId = 1,
                TipoLayoutEtiquetaPersonalizado = true
            };
        }

        public static Etiqueta MontaObjetoDistanciaHorizontalInvalida()
        {
            return new Etiqueta
            {
                Id = 1,
                Descricao = "Teste Mock 1",
                Tipo = TipoEtiqueta.MalaDireta,
                MargemSuperior = 123,
                MargemLateral = 123,
                AlturaEtiqueta = 123,
                LarguraEtiqueta = 123,
                DistanciaVertical = 123,
                DistanciaHorizontal = -123,
                LinhasPorPagina = 123,
                ColunasPorPagina = 123,
                LayoutEtiquetaEntrada = 123,
                TextoCabecalho = "Teste Mock 1",
                TextoRodape = "Teste Mock 1",
                Observacao = "Teste Mock 1",
                LinhasPorEtiqueta = 123,
                EspacoEntreLinhas = 123,
                DefirnirEtiquetaPadrao = true,
                CodigoDeBarraVertical = true,
                RetirarEspacoEntreUnidEQtd = true,
                LayoutWeleda = 1,
                TipoModeloEtiquta = 1,
                FilialId = 1,
                TipoLayoutEtiquetaPersonalizado = true
            };
        }

        public static Etiqueta MontaObjetoLinhasPorPaginaInvalida()
        {
            return new Etiqueta
            {
                Id = 1,
                Descricao = "Teste Mock 1",
                Tipo = TipoEtiqueta.MalaDireta,
                MargemSuperior = 123,
                MargemLateral = 123,
                AlturaEtiqueta = 123,
                LarguraEtiqueta = 123,
                DistanciaVertical = 123,
                DistanciaHorizontal = 123,
                LinhasPorPagina = -123,
                ColunasPorPagina = 123,
                LayoutEtiquetaEntrada = 123,
                TextoCabecalho = "Teste Mock 1",
                TextoRodape = "Teste Mock 1",
                Observacao = "Teste Mock 1",
                LinhasPorEtiqueta = 123,
                EspacoEntreLinhas = 123,
                DefirnirEtiquetaPadrao = true,
                CodigoDeBarraVertical = true,
                RetirarEspacoEntreUnidEQtd = true,
                LayoutWeleda = 1,
                TipoModeloEtiquta = 1,
                FilialId = 1,
                TipoLayoutEtiquetaPersonalizado = true
            };
        }

        public static Etiqueta MontaObjetoColunasPorPaginaInvalida()
        {
            return new Etiqueta
            {
                Id = 1,
                Descricao = "Teste Mock 1",
                Tipo = TipoEtiqueta.MalaDireta,
                MargemSuperior = 123,
                MargemLateral = 123,
                AlturaEtiqueta = 123,
                LarguraEtiqueta = 123,
                DistanciaVertical = 123,
                DistanciaHorizontal = 123,
                LinhasPorPagina = 123,
                ColunasPorPagina = -123,
                LayoutEtiquetaEntrada = 123,
                TextoCabecalho = "Teste Mock 1",
                TextoRodape = "Teste Mock 1",
                Observacao = "Teste Mock 1",
                LinhasPorEtiqueta = 123,
                EspacoEntreLinhas = 123,
                DefirnirEtiquetaPadrao = true,
                CodigoDeBarraVertical = true,
                RetirarEspacoEntreUnidEQtd = true,
                LayoutWeleda = 1,
                TipoModeloEtiquta = 1,
                FilialId = 1,
                TipoLayoutEtiquetaPersonalizado = true
            };
        }

        public static Etiqueta MontaObjetoLayoutEtiquetaEntradaInvalida()
        {
            return new Etiqueta
            {
                Id = 1,
                Descricao = "Teste Mock 1",
                Tipo = TipoEtiqueta.MalaDireta,
                MargemSuperior = 123,
                MargemLateral = 123,
                AlturaEtiqueta = 123,
                LarguraEtiqueta = 123,
                DistanciaVertical = 123,
                DistanciaHorizontal = 123,
                LinhasPorPagina = 123,
                ColunasPorPagina = 123,
                LayoutEtiquetaEntrada = -123,
                TextoCabecalho = "Teste Mock 1",
                TextoRodape = "Teste Mock 1",
                Observacao = "Teste Mock 1",
                LinhasPorEtiqueta = 123,
                EspacoEntreLinhas = 123,
                DefirnirEtiquetaPadrao = true,
                CodigoDeBarraVertical = true,
                RetirarEspacoEntreUnidEQtd = true,
                LayoutWeleda = 1,
                TipoModeloEtiquta = 1,
                FilialId = 1,
                TipoLayoutEtiquetaPersonalizado = true
            };
        }

        public static Etiqueta MontaObjetoLinhasPorEtiquetaInvalida()
        {
            return new Etiqueta
            {
                Id = 1,
                Descricao = "Teste Mock 1",
                Tipo = TipoEtiqueta.MalaDireta,
                MargemSuperior = 123,
                MargemLateral = 123,
                AlturaEtiqueta = 123,
                LarguraEtiqueta = 123,
                DistanciaVertical = 123,
                DistanciaHorizontal = 123,
                LinhasPorPagina = 123,
                ColunasPorPagina = 123,
                LayoutEtiquetaEntrada = 123,
                TextoCabecalho = "Teste Mock 1",
                TextoRodape = "Teste Mock 1",
                Observacao = "Teste Mock 1",
                LinhasPorEtiqueta = -123,
                EspacoEntreLinhas = 123,
                DefirnirEtiquetaPadrao = true,
                CodigoDeBarraVertical = true,
                RetirarEspacoEntreUnidEQtd = true,
                LayoutWeleda = 1,
                TipoModeloEtiquta = 1,
                FilialId = 1,
                TipoLayoutEtiquetaPersonalizado = true
            };
        }

        public static Etiqueta MontaObjetoEspacoEntreLinhasInvalida()
        {
            return new Etiqueta
            {
                Id = 1,
                Descricao = "Teste Mock 1",
                Tipo = TipoEtiqueta.MalaDireta,
                MargemSuperior = 123,
                MargemLateral = 123,
                AlturaEtiqueta = 123,
                LarguraEtiqueta = 123,
                DistanciaVertical = 123,
                DistanciaHorizontal = 123,
                LinhasPorPagina = 123,
                ColunasPorPagina = 123,
                LayoutEtiquetaEntrada = 123,
                TextoCabecalho = "Teste Mock 1",
                TextoRodape = "Teste Mock 1",
                Observacao = "Teste Mock 1",
                LinhasPorEtiqueta = 123,
                EspacoEntreLinhas = -123,
                DefirnirEtiquetaPadrao = true,
                CodigoDeBarraVertical = true,
                RetirarEspacoEntreUnidEQtd = true,
                LayoutWeleda = 1,
                TipoModeloEtiquta = 1,
                FilialId = 1,
                TipoLayoutEtiquetaPersonalizado = true
            };
        }

        public static List<Etiqueta> MontaListaItems()
        {
            return new List<Etiqueta>()
            {
                new Etiqueta()
                {
                    Id = 1,
                    Descricao = "Teste Mock 1",
                    Tipo = TipoEtiqueta.MalaDireta,
                    MargemSuperior = 123,
                    MargemLateral = 123,
                    AlturaEtiqueta = 123,
                    LarguraEtiqueta = 123,
                    DistanciaVertical = 123,
                    DistanciaHorizontal = 123,
                    LinhasPorPagina = 123,
                    ColunasPorPagina = 123,
                    LayoutEtiquetaEntrada = 123,
                    TextoCabecalho = "Teste Mock 1",
                    TextoRodape = "Teste Mock 1",
                    Observacao = "Teste Mock 1",
                    LinhasPorEtiqueta = 123,
                    EspacoEntreLinhas = 123,
                    DefirnirEtiquetaPadrao = true,
                    CodigoDeBarraVertical = true,
                    RetirarEspacoEntreUnidEQtd = true,
                    LayoutWeleda = 1,
                    TipoModeloEtiquta = 1,
                    FilialId = 1,
                    TipoLayoutEtiquetaPersonalizado = true
                },
                new Etiqueta()
                {
                    Id = 2,
                    Descricao = "Teste Mock 1",
                    Tipo = TipoEtiqueta.MalaDireta,
                    MargemSuperior = 123,
                    MargemLateral = 123,
                    AlturaEtiqueta = 123,
                    LarguraEtiqueta = 123,
                    DistanciaVertical = 123,
                    DistanciaHorizontal = 123,
                    LinhasPorPagina = 123,
                    ColunasPorPagina = 123,
                    LayoutEtiquetaEntrada = 123,
                    TextoCabecalho = "Teste Mock 1",
                    TextoRodape = "Teste Mock 1",
                    Observacao = "Teste Mock 1",
                    LinhasPorEtiqueta = 123,
                    EspacoEntreLinhas = 123,
                    DefirnirEtiquetaPadrao = true,
                    CodigoDeBarraVertical = true,
                    RetirarEspacoEntreUnidEQtd = true,
                    LayoutWeleda = 1,
                    TipoModeloEtiquta = 1,
                    FilialId = 1,
                    TipoLayoutEtiquetaPersonalizado = true
                },
                new Etiqueta()
                {
                    Id = 3,
                    Descricao = "Teste Mock 1",
                    Tipo = TipoEtiqueta.MalaDireta,
                    MargemSuperior = 123,
                    MargemLateral = 123,
                    AlturaEtiqueta = 123,
                    LarguraEtiqueta = 123,
                    DistanciaVertical = 123,
                    DistanciaHorizontal = 123,
                    LinhasPorPagina = 123,
                    ColunasPorPagina = 123,
                    LayoutEtiquetaEntrada = 123,
                    TextoCabecalho = "Teste Mock 1",
                    TextoRodape = "Teste Mock 1",
                    Observacao = "Teste Mock 1",
                    LinhasPorEtiqueta = 123,
                    EspacoEntreLinhas = 123,
                    DefirnirEtiquetaPadrao = true,
                    CodigoDeBarraVertical = true,
                    RetirarEspacoEntreUnidEQtd = true,
                    LayoutWeleda = 1,
                    TipoModeloEtiquta = 1,
                    FilialId = 1,
                    TipoLayoutEtiquetaPersonalizado = true
                }
            };
        }
    }
}
