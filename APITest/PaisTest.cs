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
    public class PaisTest
    {
        public Mock<IPais> mock = new Mock<IPais>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockPais.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Pais>())).Returns(Task.CompletedTask);

            var service = new PaisApiController(mock.Object);
            await service.AdicionarPais(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockPais.MontaObjetoNomeVazio();
            var apiController = new PaisApiController(mock.Object);
            var result = await apiController.AdicionarPais(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockPais.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Pais>())).Returns(Task.CompletedTask);

            var service = new PaisApiController(mock.Object);
            await service.EditarPais(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockPais.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Pais>())).Returns(Task.CompletedTask);

            var service = new PaisApiController(mock.Object);
            await service.ExcluirPais(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockPais.MontaObjetoUnico().Id)).ReturnsAsync(MockPais.MontaObjetoUnico());
            PaisApiController ret = new PaisApiController(mock.Object);
            var result = await ret.RetornaPaisPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Pais)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockPais.MontaListaItems());
            var controller = new PaisApiController(mock.Object);
            var result = await controller.ListaPais();
            var viewResult = Assert.IsType<List<Pais>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
