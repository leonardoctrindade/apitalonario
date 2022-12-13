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
    public class BulaTest
    {
        public Mock<IBula> mock = new Mock<IBula>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockBula.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Bula>())).Returns(Task.CompletedTask);

            var service = new BulaApiController(mock.Object);
            await service.AdicionarBula(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Descricao_Nao_Preenchido()
        {
            var modelo = MockBula.MontaObjetoDescricaoVazia();
            var apiController = new BulaApiController(mock.Object);
            var result = await apiController.AdicionarBula(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Tipo_Invalido()
        {
            var modelo = MockBula.MontaObjetoTipoIncorreto();
            var apiController = new BulaApiController(mock.Object);
            var result = await apiController.AdicionarBula(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockBula.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Bula>())).Returns(Task.CompletedTask);

            var service = new BulaApiController(mock.Object);
            await service.EditarBula(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockBula.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Bula>())).Returns(Task.CompletedTask);

            var service = new BulaApiController(mock.Object);
            await service.ExcluirBula(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockBula.MontaObjetoUnico().Id)).ReturnsAsync(MockBula.MontaObjetoUnico());
            BulaApiController ret = new BulaApiController(mock.Object);
            var result = await ret.RetornaBulaPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Bula)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockBula.MontaListaItems());
            var controller = new BulaApiController(mock.Object);
            var result = await controller.ListaBula();
            var viewResult = Assert.IsType<List<Bula>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
