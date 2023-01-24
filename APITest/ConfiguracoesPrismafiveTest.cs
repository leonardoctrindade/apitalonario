using Moq;
using Xunit;
using System;
using System.Text;
using System.Linq;
using APITest.Mocks;
using Data.Entidades;
using Data.Interfaces;
using WebAPI.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APITest
{
    public class ConfiguracoesPrismafiveTest
    {
        public Mock<IConfiguracoesPrismafive> mock = new Mock<IConfiguracoesPrismafive>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockConfiguracoesPrismafive.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<ConfiguracoesPrismafive>())).Returns(Task.CompletedTask);

            var service = new ConfiguracoesPrismafiveApiController(mock.Object);
            await service.AdicionarConfiguracoesPrismafive(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Secao_Nao_Preenchido()
        {
            var modelo = MockConfiguracoesPrismafive.MontaObjetoSecaoVazia();
            var apiController = new ConfiguracoesPrismafiveApiController(mock.Object);
            var result = await apiController.AdicionarConfiguracoesPrismafive(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Chave_Nao_Preenchido()
        {
            var modelo = MockConfiguracoesPrismafive.MontaObjetoChaveVazia();
            var apiController = new ConfiguracoesPrismafiveApiController(mock.Object);
            var result = await apiController.AdicionarConfiguracoesPrismafive(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_UserMac_Nao_Preenchido()
        {
            var modelo = MockConfiguracoesPrismafive.MontaObjetoUserMacVazio();
            var apiController = new ConfiguracoesPrismafiveApiController(mock.Object);
            var result = await apiController.AdicionarConfiguracoesPrismafive(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockConfiguracoesPrismafive.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<ConfiguracoesPrismafive>())).Returns(Task.CompletedTask);

            var service = new ConfiguracoesPrismafiveApiController(mock.Object);
            await service.EditarConfiguracoesPrismafive(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockConfiguracoesPrismafive.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<ConfiguracoesPrismafive>())).Returns(Task.CompletedTask);

            var service = new ConfiguracoesPrismafiveApiController(mock.Object);
            await service.ExcluirConfiguracoesPrismafive(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockConfiguracoesPrismafive.MontaObjetoUnico().Id)).ReturnsAsync(MockConfiguracoesPrismafive.MontaObjetoUnico());
            ConfiguracoesPrismafiveApiController ret = new ConfiguracoesPrismafiveApiController(mock.Object);
            var result = await ret.RetornaConfiguracoesPrismafivePorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.ConfiguracoesPrismafive)result.Value).Chave);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockConfiguracoesPrismafive.MontaListaItems());
            var controller = new ConfiguracoesPrismafiveApiController(mock.Object);
            var result = await controller.ListaConfiguracoesPrismafive();
            var viewResult = Assert.IsType<List<ConfiguracoesPrismafive>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
