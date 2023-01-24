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
    public class LimiteDeCompraClienteTest
    {
        public Mock<ILimiteDeCompraCliente> mock = new Mock<ILimiteDeCompraCliente>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockLimiteDeCompraCliente.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<LimiteDeCompraCliente>())).Returns(Task.CompletedTask);

            var service = new LimiteDeCompraClienteApiController(mock.Object);
            await service.AdicionarLimiteDeCompraCliente(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_ClienteId_Invalido()
        {
            var modelo = MockLimiteDeCompraCliente.MontaObjetoClienteIdInvalido();
            var apiController = new LimiteDeCompraClienteApiController(mock.Object);
            var result = await apiController.AdicionarLimiteDeCompraCliente(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockLimiteDeCompraCliente.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<LimiteDeCompraCliente>())).Returns(Task.CompletedTask);

            var service = new LimiteDeCompraClienteApiController(mock.Object);
            await service.EditarLimiteDeCompraCliente(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockLimiteDeCompraCliente.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<LimiteDeCompraCliente>())).Returns(Task.CompletedTask);

            var service = new LimiteDeCompraClienteApiController(mock.Object);
            await service.ExcluirLimiteDeCompraCliente(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockLimiteDeCompraCliente.MontaObjetoUnico().Id)).ReturnsAsync(MockLimiteDeCompraCliente.MontaObjetoUnico());
            LimiteDeCompraClienteApiController ret = new LimiteDeCompraClienteApiController(mock.Object);
            var result = await ret.RetornaLimiteDeCompraClientePorId(1);
            Assert.Equal(1 , ((Data.Entidades.LimiteDeCompraCliente)result.Value).ClienteId);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockLimiteDeCompraCliente.MontaListaItems());
            var controller = new LimiteDeCompraClienteApiController(mock.Object);
            var result = await controller.ListaLimiteDeCompraCliente();
            var viewResult = Assert.IsType<List<LimiteDeCompraCliente>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
