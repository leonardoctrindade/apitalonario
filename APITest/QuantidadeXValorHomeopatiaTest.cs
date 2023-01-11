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
    public class QuantidadeXValorHomeopatiaTest
    {
        public Mock<IQuantidadeXValorHomeopatia> mock = new Mock<IQuantidadeXValorHomeopatia>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockQuantidadeXValorHomeopatia.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<QuantidadeXValorHomeopatia>())).Returns(Task.CompletedTask);

            var service = new QuantidadeXValorHomeopatiaApiController(mock.Object);
            await service.AdicionarQuantidadeXValorHomeopatia(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_QuantidadeInicial_Invalida()
        {
            var modelo = MockQuantidadeXValorHomeopatia.MontaObjetoQuantidadeInicialInvalida();
            var apiController = new QuantidadeXValorHomeopatiaApiController(mock.Object);
            var result = await apiController.AdicionarQuantidadeXValorHomeopatia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_QuantidadeFinal_Invalida()
        {
            var modelo = MockQuantidadeXValorHomeopatia.MontaObjetoQuantidadeFinalInvalida();
            var apiController = new QuantidadeXValorHomeopatiaApiController(mock.Object);
            var result = await apiController.AdicionarQuantidadeXValorHomeopatia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_ValorVenda_Invalida()
        {
            var modelo = MockQuantidadeXValorHomeopatia.MontaObjetoValorVendaInvalida();
            var apiController = new QuantidadeXValorHomeopatiaApiController(mock.Object);
            var result = await apiController.AdicionarQuantidadeXValorHomeopatia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_ValorAdicional_Invalida()
        {
            var modelo = MockQuantidadeXValorHomeopatia.MontaObjetoValorAdicionalInvalido();
            var apiController = new QuantidadeXValorHomeopatiaApiController(mock.Object);
            var result = await apiController.AdicionarQuantidadeXValorHomeopatia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_IntervaloDinamizacaoId_Invalida()
        {
            var modelo = MockQuantidadeXValorHomeopatia.MontaObjetoIntervaloDinamizacaoIdInvalido();
            var apiController = new QuantidadeXValorHomeopatiaApiController(mock.Object);
            var result = await apiController.AdicionarQuantidadeXValorHomeopatia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_QuantidadeFinalMenorQueQuantidadeIncial()
        {
            var modelo = MockQuantidadeXValorHomeopatia.MontaObjetoQuantidadeFinalMenorQueQuantidadeInicial();
            var apiController = new QuantidadeXValorHomeopatiaApiController(mock.Object);
            var result = await apiController.AdicionarQuantidadeXValorHomeopatia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockQuantidadeXValorHomeopatia.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<QuantidadeXValorHomeopatia>())).Returns(Task.CompletedTask);

            var service = new QuantidadeXValorHomeopatiaApiController(mock.Object);
            await service.EditarQuantidadeXValorHomeopatia(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockQuantidadeXValorHomeopatia.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<QuantidadeXValorHomeopatia>())).Returns(Task.CompletedTask);

            var service = new QuantidadeXValorHomeopatiaApiController(mock.Object);
            await service.ExcluirQuantidadeXValorHomeopatia(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockQuantidadeXValorHomeopatia.MontaObjetoUnico().Id)).ReturnsAsync(MockQuantidadeXValorHomeopatia.MontaObjetoUnico());
            QuantidadeXValorHomeopatiaApiController ret = new QuantidadeXValorHomeopatiaApiController(mock.Object);
            var result = await ret.RetornaQuantidadeXValorHomeopatiaPorId(1);
            Assert.Equal(1, ((Data.Entidades.QuantidadeXValorHomeopatia)result.Value).IntervaloDinamizacaoId);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockQuantidadeXValorHomeopatia.MontaListaItems());
            var controller = new QuantidadeXValorHomeopatiaApiController(mock.Object);
            var result = await controller.ListaQuantidadeXValorHomeopatia();
            var viewResult = Assert.IsType<List<QuantidadeXValorHomeopatia>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
