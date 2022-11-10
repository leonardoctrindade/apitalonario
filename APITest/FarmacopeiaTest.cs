using Moq;
using Xunit;
using System;
using System.Linq;
using System.Text;
using APITest.Mocks;
using Data.Entidades;
using Data.Interfaces;
using WebAPI.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APITest
{
    public class FarmacopeiaTest
    {
        public Mock<IFarmacopeia> mock = new Mock<IFarmacopeia>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockFarmacopeia.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Farmacopeia>())).Returns(Task.CompletedTask);

            var service = new FarmacopeiaApiController(mock.Object);
            await service.AdicionarFarmacopeia(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockFarmacopeia.MontaObjetoNomeVazio();
            var apiController = new FarmacopeiaApiController(mock.Object);
            var result = await apiController.AdicionarFarmacopeia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]

        public async Task Editar_Sucesso()
        {
            var modelo = MockFarmacopeia.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Farmacopeia>())).Returns(Task.CompletedTask);

            var service = new FarmacopeiaApiController(mock.Object);
            await service.EditarFarmacopeia(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]

        public async Task Excluir_Sucesso()
        {
            var modelo = MockFarmacopeia.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Farmacopeia>())).Returns(Task.CompletedTask);

            var service = new FarmacopeiaApiController(mock.Object);
            await service.ExcluirFarmacopeia(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]

        public async Task RetornaPorID()
        {
            mock.Setup(y => y.GetEntityById(MockFarmacopeia.MontaObjetoUnico().Id)).ReturnsAsync(MockFarmacopeia.MontaObjetoUnico());
            FarmacopeiaApiController ret = new FarmacopeiaApiController(mock.Object);
            var result = await ret.RetornaFarmacopeiaPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Farmacopeia)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockFarmacopeia.MontaListaItems());
            var controller = new FarmacopeiaApiController(mock.Object);
            var result = await controller.ListaFarmacopeia();
            var viewResult = Assert.IsType<List<Farmacopeia>>(result.Value);

            Assert.Equal(3, viewResult.Count());
        }
    }
}
