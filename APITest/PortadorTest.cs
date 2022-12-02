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
    public class PortadorTest
    {
        public Mock<IPortador> mock = new Mock<IPortador>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockPortador.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Portador>())).Returns(Task.CompletedTask);

            var service = new PortadorApiController(mock.Object);
            await service.AdicionarPortador(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockPortador.MontaObjetoNomeVazio();
            var apiController = new PortadorApiController(mock.Object);
            var result = await apiController.AdicionarPortador(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockPortador.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Portador>())).Returns(Task.CompletedTask);

            var service = new PortadorApiController(mock.Object);
            await service.EditarPortador(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockPortador.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Portador>())).Returns(Task.CompletedTask);

            var service = new PortadorApiController(mock.Object);
            await service.ExcluirPortador(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockPortador.MontaObjetoUnico().Id)).ReturnsAsync(MockPortador.MontaObjetoUnico());
            PortadorApiController ret = new PortadorApiController(mock.Object);
            var result = await ret.RetornaPortadorPorId(1);
            Assert.Equal("Teste 1", ((Data.Entidades.Portador)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockPortador.MontaListaItems());
            var controller = new PortadorApiController(mock.Object);
            var result = await controller.ListaPortador();
            var viewResult = Assert.IsType<List<Portador>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
