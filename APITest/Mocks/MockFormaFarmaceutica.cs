using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public static class MockFormaFarmaceutica
    {
        public static FormaFarmaceutica MontaObjetoUnico()
        {
            return new FormaFarmaceutica
            {
                Id = 1,
                Descricao = "Teste Mock 1",
                Inativo = true,
                Tipo = TipoFormaFarmaceutica.Volume,
                SelecionaQuantidadeSugerida = true,
                MultiplicaComposicao = true,
                HomeopatiaLiquida = true,
                DeduzirQuantidadeVeiculo = true,
                CalculoEmbalagemForma = 1323,
                ConverteVolumeEmbalagem = true,
                Uso = "Teste Mock 1",
                TipoUso = 1,
                POPForma = "Teste Mock 1",
                ImprimirCamposAnalise = true,
                SelecionarVolumeAutomático = true,
                Validade = 2131,
                MlGotas = 312,
                ImprimirUnidadeMedidaNoRotulo = true,
                FatorPerdaProduto = 132,
                AtivaFatorPerdaQsp = true,
                ManipuladorId = 1,
                QuantidadeFormulasHora = 123,
                DescricaoRotulo = "Teste Mock 1",
                QuantidadeQspMinimo = 1,
                ProdutoVeiculoId = 1,
                GrupoVeiculoId = 1,
                AtivaPesagemMonitorada = true,
                CalcularDensidade = true,
                ValorMinimo = 231,
                CustoAdicional = 315,
                NcmId = 1,
                CodigoLaboratorioLp = "SD",
                CodigoFuncionarioManipulacao = 1,
                CodigoFormaReceituario = 1,
                CodigoFilialProducao = 1,
                AliquotaIva = 123124
            };
        }

        public static FormaFarmaceutica MontaObjetoDescricaoVazia()
        {
            return new FormaFarmaceutica
            {
                Id = 1,
                Descricao = null,
                Inativo = true,
                Tipo = TipoFormaFarmaceutica.Volume,
                SelecionaQuantidadeSugerida = true,
                MultiplicaComposicao = true,
                HomeopatiaLiquida = true,
                DeduzirQuantidadeVeiculo = true,
                CalculoEmbalagemForma = 1323,
                ConverteVolumeEmbalagem = true,
                Uso = "Teste Mock 1",
                TipoUso = 1,
                POPForma = "Teste Mock 1",
                ImprimirCamposAnalise = true,
                SelecionarVolumeAutomático = true,
                Validade = 2131,
                MlGotas = 312,
                ImprimirUnidadeMedidaNoRotulo = true,
                FatorPerdaProduto = 132,
                AtivaFatorPerdaQsp = true,
                ManipuladorId = 1,
                QuantidadeFormulasHora = 123,
                DescricaoRotulo = "Teste Mock 1",
                QuantidadeQspMinimo = 1,
                ProdutoVeiculoId = 1,
                GrupoVeiculoId = 1,
                AtivaPesagemMonitorada = true,
                CalcularDensidade = true,
                ValorMinimo = 231,
                CustoAdicional = 315,
                NcmId = 1,
                CodigoLaboratorioLp = "SD",
                CodigoFuncionarioManipulacao = 1,
                CodigoFormaReceituario = 1,
                CodigoFilialProducao = 1,
                AliquotaIva = 123124
            };
        }

        public static List<FormaFarmaceutica> MontaListaItems()
        {
            return new List<FormaFarmaceutica>()
            {
                new FormaFarmaceutica()
                {
                    Id = 1,
                    Descricao = null,
                    Inativo = true,
                    Tipo = TipoFormaFarmaceutica.Volume,
                    SelecionaQuantidadeSugerida = true,
                    MultiplicaComposicao = true,
                    HomeopatiaLiquida = true,
                    DeduzirQuantidadeVeiculo = true,
                    CalculoEmbalagemForma = 1323,
                    ConverteVolumeEmbalagem = true,
                    Uso = "Teste Mock 1",
                    TipoUso = 1,
                    POPForma = "Teste Mock 1",
                    ImprimirCamposAnalise = true,
                    SelecionarVolumeAutomático = true,
                    Validade = 2131,
                    MlGotas = 312,
                    ImprimirUnidadeMedidaNoRotulo = true,
                    FatorPerdaProduto = 132,
                    AtivaFatorPerdaQsp = true,
                    ManipuladorId = 1,
                    QuantidadeFormulasHora = 123,
                    DescricaoRotulo = "Teste Mock 1",
                    QuantidadeQspMinimo = 1,
                    ProdutoVeiculoId = 1,
                    GrupoVeiculoId = 1,
                    AtivaPesagemMonitorada = true,
                    CalcularDensidade = true,
                    ValorMinimo = 231,
                    CustoAdicional = 315,
                    NcmId = 1,
                    CodigoLaboratorioLp = "SD",
                    CodigoFuncionarioManipulacao = 1,
                    CodigoFormaReceituario = 1,
                    CodigoFilialProducao = 1,
                    AliquotaIva = 123124
                },
                new FormaFarmaceutica()
                {
                    Id = 2,
                    Descricao = null,
                    Inativo = true,
                    Tipo = TipoFormaFarmaceutica.Volume,
                    SelecionaQuantidadeSugerida = true,
                    MultiplicaComposicao = true,
                    HomeopatiaLiquida = true,
                    DeduzirQuantidadeVeiculo = true,
                    CalculoEmbalagemForma = 1323,
                    ConverteVolumeEmbalagem = true,
                    Uso = "Teste Mock 2",
                    TipoUso = 2,
                    POPForma = "Teste Mock 2",
                    ImprimirCamposAnalise = true,
                    SelecionarVolumeAutomático = true,
                    Validade = 2131,
                    MlGotas = 312,
                    ImprimirUnidadeMedidaNoRotulo = true,
                    FatorPerdaProduto = 132,
                    AtivaFatorPerdaQsp = true,
                    ManipuladorId = 2,
                    QuantidadeFormulasHora = 123,
                    DescricaoRotulo = "Teste Mock 2",
                    QuantidadeQspMinimo = 2,
                    ProdutoVeiculoId = 2,
                    GrupoVeiculoId = 2,
                    AtivaPesagemMonitorada = true,
                    CalcularDensidade = true,
                    ValorMinimo = 231,
                    CustoAdicional = 315,
                    NcmId = 2,
                    CodigoLaboratorioLp = "SD",
                    CodigoFuncionarioManipulacao = 2,
                    CodigoFormaReceituario = 2,
                    CodigoFilialProducao = 2,
                    AliquotaIva = 123124
                },
                new FormaFarmaceutica()
                {
                    Id = 3,
                    Descricao = null,
                    Inativo = true,
                    Tipo = TipoFormaFarmaceutica.Volume,
                    SelecionaQuantidadeSugerida = true,
                    MultiplicaComposicao = true,
                    HomeopatiaLiquida = true,
                    DeduzirQuantidadeVeiculo = true,
                    CalculoEmbalagemForma = 1323,
                    ConverteVolumeEmbalagem = true,
                    Uso = "Teste Mock 3",
                    TipoUso = 1,
                    POPForma = "Teste Mock 3",
                    ImprimirCamposAnalise = true,
                    SelecionarVolumeAutomático = true,
                    Validade = 2131,
                    MlGotas = 312,
                    ImprimirUnidadeMedidaNoRotulo = true,
                    FatorPerdaProduto = 132,
                    AtivaFatorPerdaQsp = true,
                    ManipuladorId = 1,
                    QuantidadeFormulasHora = 123,
                    DescricaoRotulo = "Teste Mock 3",
                    QuantidadeQspMinimo = 3,
                    ProdutoVeiculoId = 3,
                    GrupoVeiculoId = 3,
                    AtivaPesagemMonitorada = true,
                    CalcularDensidade = true,
                    ValorMinimo = 231,
                    CustoAdicional = 315,
                    NcmId = 3,
                    CodigoLaboratorioLp = "SD",
                    CodigoFuncionarioManipulacao = 3,
                    CodigoFormaReceituario = 3,
                    CodigoFilialProducao = 3,
                    AliquotaIva = 123124
                }
            };
        }
    }
}
