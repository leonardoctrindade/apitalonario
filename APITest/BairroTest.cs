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
    public class BairroTest
    {
        public Mock<IBairro> mock = new Mock<IBairro>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockBairro.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Bairro>())).Returns(Task.CompletedTask);

            var service = new BairroApiController(mock.Object);
            await service.AdicionarBairro(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockBairro.MontaObjetoNomeVazio();
            var apiController = new BairroApiController(mock.Object);
            var result = await apiController.AdicionarBairro(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockBairro.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Bairro>())).Returns(Task.CompletedTask);

            var service = new BairroApiController(mock.Object);
            await service.EditarBairro(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockBairro.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Bairro>())).Returns(Task.CompletedTask);

            var service = new BairroApiController(mock.Object);
            await service.ExcluirBairro(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockBairro.MontaObjetoUnico().Id)).ReturnsAsync(MockBairro.MontaObjetoUnico());
            BairroApiController ret = new BairroApiController(mock.Object);
            var result = await ret.RetornaBairroPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Bairro)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockBairro.MontaListaItems());
            var controller = new BairroApiController(mock.Object);
            var result = await controller.ListaBairro();
            var viewResult = Assert.IsType<List<Bairro>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
