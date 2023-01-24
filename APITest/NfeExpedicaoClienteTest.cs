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
    public class NfeExpedicaoClienteTest
    {
        public Mock<INfeExpedicaoCliente> mock = new Mock<INfeExpedicaoCliente>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockNfeExpedicaoCliente.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<NfeExpedicaoCliente>())).Returns(Task.CompletedTask);

            var service = new NfeExpedicaoClienteApiController(mock.Object);
            await service.AdicionarNfeExpedicaoCliente(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_ClienteId_Invalida()
        {
            var modelo = MockNfeExpedicaoCliente.MontaObjetoClienteIdInvalido();
            var apiController = new NfeExpedicaoClienteApiController(mock.Object);
            var result = await apiController.AdicionarNfeExpedicaoCliente(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockNfeExpedicaoCliente.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<NfeExpedicaoCliente>())).Returns(Task.CompletedTask);

            var service = new NfeExpedicaoClienteApiController(mock.Object);
            await service.EditarNfeExpedicaoCliente(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockNfeExpedicaoCliente.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<NfeExpedicaoCliente>())).Returns(Task.CompletedTask);

            var service = new NfeExpedicaoClienteApiController(mock.Object);
            await service.ExcluirNfeExpedicaoCliente(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockNfeExpedicaoCliente.MontaObjetoUnico().Id)).ReturnsAsync(MockNfeExpedicaoCliente.MontaObjetoUnico());
            NfeExpedicaoClienteApiController ret = new NfeExpedicaoClienteApiController(mock.Object);
            var result = await ret.RetornaNfeExpedicaoClientePorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.NfeExpedicaoCliente)result.Value).LocalEmbarque);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockNfeExpedicaoCliente.MontaListaItems());
            var controller = new NfeExpedicaoClienteApiController(mock.Object);
            var result = await controller.ListaNfeExpedicaoCliente();
            var viewResult = Assert.IsType<List<NfeExpedicaoCliente>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
