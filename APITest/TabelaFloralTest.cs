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
    public class TabelaFloralTest
    {
        public Mock<ITabelaFloral> mock = new Mock<ITabelaFloral>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockTabelaFloral.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<TabelaFloral>())).Returns(Task.CompletedTask);

            var service = new TabelaFloralApiController(mock.Object);
            await service.AdicionarTabelaFloral(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Volume_Vazio()
        {
            var modelo = MockTabelaFloral.MontaObjetoVolumeVazio();
            var apiController = new TabelaFloralApiController(mock.Object);
            var result = await apiController.AdicionarTabelaFloral(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_QuantidadeInicial_Vazio()
        {
            var modelo = MockTabelaFloral.MontaObjetoQuantidadeInicialVazio();
            var apiController = new TabelaFloralApiController(mock.Object);
            var result = await apiController.AdicionarTabelaFloral(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_QuantidadeFinal_Vazio()
        {
            var modelo = MockTabelaFloral.MontaObjetoQuantidadeFinalVazio();
            var apiController = new TabelaFloralApiController(mock.Object);
            var result = await apiController.AdicionarTabelaFloral(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_ValorVenda_Vazio()
        {
            var modelo = MockTabelaFloral.MontaObjetoValorVendaVazio();
            var apiController = new TabelaFloralApiController(mock.Object);
            var result = await apiController.AdicionarTabelaFloral(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockTabelaFloral.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<TabelaFloral>())).Returns(Task.CompletedTask);

            var service = new TabelaFloralApiController(mock.Object);
            await service.EditarTabelaFloral(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockTabelaFloral.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<TabelaFloral>())).Returns(Task.CompletedTask);

            var service = new TabelaFloralApiController(mock.Object);
            await service.ExcluirTabelaFloral(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockTabelaFloral.MontaObjetoUnico().Id)).ReturnsAsync(MockTabelaFloral.MontaObjetoUnico());
            TabelaFloralApiController ret = new TabelaFloralApiController(mock.Object);
            var result = await ret.RetornaTabelaFloralPorId(1);
            Assert.Equal(60, ((Data.Entidades.TabelaFloral)result.Value).ValorVenda);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockTabelaFloral.MontaListaItems());
            var controller = new TabelaFloralApiController(mock.Object);
            var result = await controller.ListaTabelaFloral();
            var viewResult = Assert.IsType<List<TabelaFloral>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
