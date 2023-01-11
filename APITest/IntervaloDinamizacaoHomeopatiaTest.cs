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
    public class IntervaloDinamizacaoHomeopatiaTest
    {
        public Mock<IIntervaloDinamizacaoHomeopatia> mock = new Mock<IIntervaloDinamizacaoHomeopatia>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockIntervaloDinamizacaoHomeopatia.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<IntervaloDinamizacaoHomeopatia>())).Returns(Task.CompletedTask);

            var service = new IntervaloDinamizacaoHomeopatiaApiController(mock.Object);
            await service.AdicionarIntervaloDinamizacaoHomeopatia(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Inicial_Invalido()
        {
            var modelo = MockIntervaloDinamizacaoHomeopatia.MontaObjetoInicialInvalido();
            var apiController = new IntervaloDinamizacaoHomeopatiaApiController(mock.Object);
            var result = await apiController.AdicionarIntervaloDinamizacaoHomeopatia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Final_Invalido()
        {
            var modelo = MockIntervaloDinamizacaoHomeopatia.MontaObjetoFinalInvalido();
            var apiController = new IntervaloDinamizacaoHomeopatiaApiController(mock.Object);
            var result = await apiController.AdicionarIntervaloDinamizacaoHomeopatia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_TabelaHomeopatiaId_Invalido()
        {
            var modelo = MockIntervaloDinamizacaoHomeopatia.MontaObjetoTabelaHomeopatiaIdInvalido();
            var apiController = new IntervaloDinamizacaoHomeopatiaApiController(mock.Object);
            var result = await apiController.AdicionarIntervaloDinamizacaoHomeopatia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_FinalMenorQueInicial()
        {
            var modelo = MockIntervaloDinamizacaoHomeopatia.MontaObjetoFinalMenorQueInicial();
            var apiController = new IntervaloDinamizacaoHomeopatiaApiController(mock.Object);
            var result = await apiController.AdicionarIntervaloDinamizacaoHomeopatia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockIntervaloDinamizacaoHomeopatia.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<IntervaloDinamizacaoHomeopatia>())).Returns(Task.CompletedTask);

            var service = new IntervaloDinamizacaoHomeopatiaApiController(mock.Object);
            await service.EditarIntervaloDinamizacaoHomeopatia(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockIntervaloDinamizacaoHomeopatia.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<IntervaloDinamizacaoHomeopatia>())).Returns(Task.CompletedTask);

            var service = new IntervaloDinamizacaoHomeopatiaApiController(mock.Object);
            await service.ExcluirIntervaloDinamizacaoHomeopatia(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockIntervaloDinamizacaoHomeopatia.MontaObjetoUnico().Id)).ReturnsAsync(MockIntervaloDinamizacaoHomeopatia.MontaObjetoUnico());
            IntervaloDinamizacaoHomeopatiaApiController ret = new IntervaloDinamizacaoHomeopatiaApiController(mock.Object);
            var result = await ret.RetornaIntervaloDinamizacaoHomeopatiaPorId(1);
            Assert.Equal(1 , ((Data.Entidades.IntervaloDinamizacaoHomeopatia)result.Value).Inicial);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockIntervaloDinamizacaoHomeopatia.MontaListaItems());
            var controller = new IntervaloDinamizacaoHomeopatiaApiController(mock.Object);
            var result = await controller.ListaIntervaloDinamizacaoHomeopatia();
            var viewResult = Assert.IsType<List<IntervaloDinamizacaoHomeopatia>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
