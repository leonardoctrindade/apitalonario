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
    public class EcfTest
    {
        public Mock<IEcf> mock = new Mock<IEcf>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockEcf.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Ecf>())).Returns(Task.CompletedTask);

            var service = new EcfApiController(mock.Object);
            await service.AdicionarEcf(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_NumeroEquipamento_Invalido()
        {
            var modelo = MockEcf.MontaObjetoNumeroEquipamentoInvalido();
            var apiController = new EcfApiController(mock.Object);
            var result = await apiController.AdicionarEcf(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_NumeroSerie_Vazio()
        {
            var modelo = MockEcf.MontaObjetoNumeroSerieVazia();
            var apiController = new EcfApiController(mock.Object);
            var result = await apiController.AdicionarEcf(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockEcf.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Ecf>())).Returns(Task.CompletedTask);

            var service = new EcfApiController(mock.Object);
            await service.EditarEcf(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockEcf.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Ecf>())).Returns(Task.CompletedTask);

            var service = new EcfApiController(mock.Object);
            await service.ExcluirEcf(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockEcf.MontaObjetoUnico().Id)).ReturnsAsync(MockEcf.MontaObjetoUnico());
            EcfApiController ret = new EcfApiController(mock.Object);
            var result = await ret.RetornaEcfPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Ecf)result.Value).NumeroSerie);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockEcf.MontaListaItems());
            var controller = new EcfApiController(mock.Object);
            var result = await controller.ListaEcf();
            var viewResult = Assert.IsType<List<Ecf>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
