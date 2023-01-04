using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockEcf
    {
        public static Ecf MontaObjetoUnico()
        {
            return new Ecf
            {
                Id = 1,
                NumeroEquipamento = 1,
                NumeroSerie = "Teste Mock 1",
                Marca = MarcaEcf.Epson,
                Modelo = "Teste Mock 1",
                CniEcf = "Teste 1",
                Cro = 1,
                TipoModelo = "Matricial",
                OrdemUsuario = 1,
                DataCadastroUsuario = DateTime.Now,
                HoraCadastroUsuario = DateTime.Now,
                MfAdicional = '1',
                VersaoSb = "Teste 1",
                DataGravacaoSb = DateTime.Now,
                HoraGravacaoSb = DateTime.Now,
                VersaoDll = "Teste 1",
                AcentoFormaPagamento = true,
                MaisculoFormaPagamento = true,
                SaltoFinalCupom = 1,
                PafNumeroFabricacao = "Teste Mock 1",
                PafEcf = "Teste Mock 1",
                NumeroFabricacaoCripto = "Teste Mock 1",
                GrandeTotalCripto = "Teste Mock 1",
                FilialId = 1
            };
        }

        public static Ecf MontaObjetoNumeroEquipamentoInvalido()
        {
            return new Ecf
            {
                Id = 1,
                NumeroEquipamento = -1,
                NumeroSerie = "Teste Mock 1",
                Marca = MarcaEcf.Epson,
                Modelo = "Teste Mock 1",
                CniEcf = "Teste 1",
                Cro = 1,
                TipoModelo = "Matricial",
                OrdemUsuario = 1,
                DataCadastroUsuario = DateTime.Now,
                HoraCadastroUsuario = DateTime.Now,
                MfAdicional = '1',
                VersaoSb = "Teste 1",
                DataGravacaoSb = DateTime.Now,
                HoraGravacaoSb = DateTime.Now,
                VersaoDll = "Teste 1",
                AcentoFormaPagamento = true,
                MaisculoFormaPagamento = true,
                SaltoFinalCupom = 1,
                PafNumeroFabricacao = "Teste Mock 1",
                PafEcf = "Teste Mock 1",
                NumeroFabricacaoCripto = "Teste Mock 1",
                GrandeTotalCripto = "Teste Mock 1",
                FilialId = 1
            };
        }

        public static Ecf MontaObjetoNumeroSerieVazia()
        {
            return new Ecf
            {
                Id = 1,
                NumeroEquipamento = 1,
                NumeroSerie = null,
                Marca = MarcaEcf.Epson,
                Modelo = "Teste Mock 1",
                CniEcf = "Teste 1",
                Cro = 1,
                TipoModelo = "Matricial",
                OrdemUsuario = 1,
                DataCadastroUsuario = DateTime.Now,
                HoraCadastroUsuario = DateTime.Now,
                MfAdicional = '1',
                VersaoSb = "Teste 1",
                DataGravacaoSb = DateTime.Now,
                HoraGravacaoSb = DateTime.Now,
                VersaoDll = "Teste 1",
                AcentoFormaPagamento = true,
                MaisculoFormaPagamento = true,
                SaltoFinalCupom = 1,
                PafNumeroFabricacao = "Teste Mock 1",
                PafEcf = "Teste Mock 1",
                NumeroFabricacaoCripto = "Teste Mock 1",
                GrandeTotalCripto = "Teste Mock 1",
                FilialId = 1
            };
        }

        public static List<Ecf> MontaListaItems()
        {
            return new List<Ecf>()
            {
                new Ecf()
                {
                    Id = 1,
                    NumeroEquipamento = 1,
                    NumeroSerie = "Teste Mock 1",
                    Marca = MarcaEcf.Epson,
                    Modelo = "Teste Mock 1",
                    CniEcf = "Teste 1",
                    Cro = 1,
                    TipoModelo = "Matricial",
                    OrdemUsuario = 1,
                    DataCadastroUsuario = DateTime.Now,
                    HoraCadastroUsuario = DateTime.Now,
                    MfAdicional = '1',
                    VersaoSb = "Teste 1",
                    DataGravacaoSb = DateTime.Now,
                    HoraGravacaoSb = DateTime.Now,
                    VersaoDll = "Teste 1",
                    AcentoFormaPagamento = true,
                    MaisculoFormaPagamento = true,
                    SaltoFinalCupom = 1,
                    PafNumeroFabricacao = "Teste Mock 1",
                    PafEcf = "Teste Mock 1",
                    NumeroFabricacaoCripto = "Teste Mock 1",
                    GrandeTotalCripto = "Teste Mock 1",
                    FilialId = 1
                },
                new Ecf()
                {
                    Id = 2,
                    NumeroEquipamento = 2,
                    NumeroSerie = "Teste Mock 2",
                    Marca = MarcaEcf.Epson,
                    Modelo = "Teste Mock 2",
                    CniEcf = "Teste 2",
                    Cro = 2,
                    TipoModelo = "Matricial",
                    OrdemUsuario = 2,
                    DataCadastroUsuario = DateTime.Now,
                    HoraCadastroUsuario = DateTime.Now,
                    MfAdicional = '2',
                    VersaoSb = "Teste 2",
                    DataGravacaoSb = DateTime.Now,
                    HoraGravacaoSb = DateTime.Now,
                    VersaoDll = "Teste 2",
                    AcentoFormaPagamento = false,
                    MaisculoFormaPagamento = true,
                    SaltoFinalCupom = 2,
                    PafNumeroFabricacao = "Teste Mock 2",
                    PafEcf = "Teste Mock 2",
                    NumeroFabricacaoCripto = "Teste Mock 2",
                    GrandeTotalCripto = "Teste Mock 2",
                    FilialId = 2
                },
                new Ecf()
                {
                    Id = 3,
                    NumeroEquipamento = 3,
                    NumeroSerie = "Teste Mock 3",
                    Marca = MarcaEcf.Epson,
                    Modelo = "Teste Mock 3",
                    CniEcf = "Teste 3",
                    Cro = 3,
                    TipoModelo = "Matricial",
                    OrdemUsuario = 3,
                    DataCadastroUsuario = DateTime.Now,
                    HoraCadastroUsuario = DateTime.Now,
                    MfAdicional = '3',
                    VersaoSb = "Teste 3",
                    DataGravacaoSb = DateTime.Now,
                    HoraGravacaoSb = DateTime.Now,
                    VersaoDll = "Teste 3",
                    AcentoFormaPagamento = true,
                    MaisculoFormaPagamento = false,
                    SaltoFinalCupom = 3,
                    PafNumeroFabricacao = "Teste Mock 3",
                    PafEcf = "Teste Mock 3",
                    NumeroFabricacaoCripto = "Teste Mock 3",
                    GrandeTotalCripto = "Teste Mock 3",
                    FilialId = 3
                },
            };
        }
    }
}
