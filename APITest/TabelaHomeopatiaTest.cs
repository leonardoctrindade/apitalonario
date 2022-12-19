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
using System.Diagnostics.Contracts;

namespace APITest
{
    public class TabelaHomeopatiaTest
    {
        public Mock<ITabelaHomeopatia> mock = new Mock<ITabelaHomeopatia>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockTabelaHomeopatia.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<TabelaHomeopatia>())).Returns(Task.CompletedTask);

            var service = new TabelaHomeopatiaApiController(mock.Object);
            await service.AdicionarTabelaHomeopatia(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Metodo_Nao_Preenchido()
        {
            var modelo = MockTabelaHomeopatia.MontaObjetoMetodoVazio();
            var apiController = new TabelaHomeopatiaApiController(mock.Object);
            var result = await apiController.AdicionarTabelaHomeopatia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_DinamizacaoInicial_invalido()
        {
            var modelo = MockTabelaHomeopatia.MontaObjetoDinamizacaoInicialInvalida();
            var apiController = new TabelaHomeopatiaApiController(mock.Object);
            var result = await apiController.AdicionarTabelaHomeopatia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_DinamizacaoFinal_invalido()
        {
            var modelo = MockTabelaHomeopatia.MontaObjetoDinamizacaoFinalInvalida();
            var apiController = new TabelaHomeopatiaApiController(mock.Object);
            var result = await apiController.AdicionarTabelaHomeopatia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Volume_invalido()
        {
            var modelo = MockTabelaHomeopatia.MontaObjetoVolumeInvalida();
            var apiController = new TabelaHomeopatiaApiController(mock.Object);
            var result = await apiController.AdicionarTabelaHomeopatia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockTabelaHomeopatia.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<TabelaHomeopatia>())).Returns(Task.CompletedTask);

            var service = new TabelaHomeopatiaApiController(mock.Object);
            await service.EditarTabelaHomeopatia(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockTabelaHomeopatia.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<TabelaHomeopatia>())).Returns(Task.CompletedTask);

            var service = new TabelaHomeopatiaApiController(mock.Object);
            await service.ExcluirTabelaHomeopatia(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockTabelaHomeopatia.MontaObjetoUnico().Id)).ReturnsAsync(MockTabelaHomeopatia.MontaObjetoUnico());
            TabelaHomeopatiaApiController ret = new TabelaHomeopatiaApiController(mock.Object);
            var result = await ret.RetornaTabelaHomeopatiaPorId(1);
            Assert.Equal("Teste 1", ((Data.Entidades.TabelaHomeopatia)result.Value).Metodo);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockTabelaHomeopatia.MontaListaItems());
            var controller = new TabelaHomeopatiaApiController(mock.Object);
            var result = await controller.ListaTabelaHomeopatia();
            var viewResult = Assert.IsType<List<TabelaHomeopatia>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
