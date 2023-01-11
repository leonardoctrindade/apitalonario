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
    public class VolumeXValorHomeopatiaTest
    {
        public Mock<IVolumeXValorHomeopatia> mock = new Mock<IVolumeXValorHomeopatia>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockVolumeXValorHomeopatia.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<VolumeXValorHomeopatia>())).Returns(Task.CompletedTask);

            var service = new VolumeXValorHomeopatiaApiController(mock.Object);
            await service.AdicionarVolumeXValorHomeopatia(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Volume_Invalido()
        {
            var modelo = MockVolumeXValorHomeopatia.MontaObjetoVolumeInvalido();
            var apiController = new VolumeXValorHomeopatiaApiController(mock.Object);
            var result = await apiController.AdicionarVolumeXValorHomeopatia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_IntervaloDinamizacaoId_Invalido()
        {
            var modelo = MockVolumeXValorHomeopatia.MontaObjetoIntervaloDinanamizacaoIdInvalido();
            var apiController = new VolumeXValorHomeopatiaApiController(mock.Object);
            var result = await apiController.AdicionarVolumeXValorHomeopatia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_ValorVenda_Invalido()
        {
            var modelo = MockVolumeXValorHomeopatia.MontaObjetoValorVendaInvalido();
            var apiController = new VolumeXValorHomeopatiaApiController(mock.Object);
            var result = await apiController.AdicionarVolumeXValorHomeopatia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_ValorAdicional_Invalido()
        {
            var modelo = MockVolumeXValorHomeopatia.MontaObjetoValorAdicionalInvalido();
            var apiController = new VolumeXValorHomeopatiaApiController(mock.Object);
            var result = await apiController.AdicionarVolumeXValorHomeopatia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockVolumeXValorHomeopatia.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<VolumeXValorHomeopatia>())).Returns(Task.CompletedTask);

            var service = new VolumeXValorHomeopatiaApiController(mock.Object);
            await service.EditarVolumeXValorHomeopatia(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockVolumeXValorHomeopatia.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<VolumeXValorHomeopatia>())).Returns(Task.CompletedTask);

            var service = new VolumeXValorHomeopatiaApiController(mock.Object);
            await service.ExcluirVolumeXValorHomeopatia(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockVolumeXValorHomeopatia.MontaObjetoUnico().Id)).ReturnsAsync(MockVolumeXValorHomeopatia.MontaObjetoUnico());
            VolumeXValorHomeopatiaApiController ret = new VolumeXValorHomeopatiaApiController(mock.Object);
            var result = await ret.RetornaVolumeXValorHomeopatiaPorId(1);
            Assert.Equal(1, ((Data.Entidades.VolumeXValorHomeopatia)result.Value).Volume);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockVolumeXValorHomeopatia.MontaListaItems());
            var controller = new VolumeXValorHomeopatiaApiController(mock.Object);
            var result = await controller.ListaVolumeXValorHomeopatia();
            var viewResult = Assert.IsType<List<VolumeXValorHomeopatia>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
