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
    public class ConvenioClienteTest
    {
        public Mock<IConvenioCliente> mock = new Mock<IConvenioCliente>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockConvenioCliente.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<ConvenioCliente>())).Returns(Task.CompletedTask);

            var service = new ConvenioClienteApiController(mock.Object);
            await service.AdicionarConvenioCliente(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_ClienteId_Invalido()
        {
            var modelo = MockConvenioCliente.MontaObjetoClienteIdInvalido();
            var apiController = new ConvenioClienteApiController(mock.Object);
            var result = await apiController.AdicionarConvenioCliente(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockConvenioCliente.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<ConvenioCliente>())).Returns(Task.CompletedTask);

            var service = new ConvenioClienteApiController(mock.Object);
            await service.EditarConvenioCliente(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockConvenioCliente.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<ConvenioCliente>())).Returns(Task.CompletedTask);

            var service = new ConvenioClienteApiController(mock.Object);
            await service.ExcluirConvenioCliente(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockConvenioCliente.MontaObjetoUnico().Id)).ReturnsAsync(MockConvenioCliente.MontaObjetoUnico());
            ConvenioClienteApiController ret = new ConvenioClienteApiController(mock.Object);
            var result = await ret.RetornaConvenioClientePorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.ConvenioCliente)result.Value).Numero);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockConvenioCliente.MontaListaItems());
            var controller = new ConvenioClienteApiController(mock.Object);
            var result = await controller.ListaConvenioCliente();
            var viewResult = Assert.IsType<List<ConvenioCliente>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
