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
    public class ClienteTest
    {
        public Mock<ICliente> mock = new Mock<ICliente>();


        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockCliente.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Cliente>())).Returns(Task.CompletedTask);

            var service = new ClienteApiController(mock.Object);
            await service.AdicionarCliente(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockCliente.MontaObjetoNomeVazio();
            var apiController = new ClienteApiController(mock.Object);
            var result = await apiController.AdicionarCliente(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockCliente.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Cliente>())).Returns(Task.CompletedTask);

            var service = new ClienteApiController(mock.Object);
            await service.EditarCliente(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockCliente.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Cliente>())).Returns(Task.CompletedTask);

            var service = new ClienteApiController(mock.Object);
            await service.ExcluirCliente(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockCliente.MontaObjetoUnico().Id)).ReturnsAsync(MockCliente.MontaObjetoUnico());
            ClienteApiController ret = new ClienteApiController(mock.Object);
            var result = await ret.RetornaClientePorId(1);
            Assert.Equal("Fragas", ((Data.Entidades.Cliente)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockCliente.MontaListaItems());
            var controller = new ClienteApiController(mock.Object);
            var result = await controller.ListaCliente();
            var viewResult = Assert.IsType<List<Cliente>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
