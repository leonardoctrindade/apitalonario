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
    public class ObservacoesClienteTest
    {
        public Mock<IObservacoesCliente> mock = new Mock<IObservacoesCliente>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockObservacoesCliente.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<ObservacoesCliente>())).Returns(Task.CompletedTask);

            var service = new ObservacoesClienteApiController(mock.Object);
            await service.AdicionarObservacoesCliente(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_ClienteId_Invalido()
        {
            var modelo = MockObservacoesCliente.MontaObjetoClienteIdInvalido();
            var apiController = new ObservacoesClienteApiController(mock.Object);
            var result = await apiController.AdicionarObservacoesCliente(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockObservacoesCliente.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<ObservacoesCliente>())).Returns(Task.CompletedTask);

            var service = new ObservacoesClienteApiController(mock.Object);
            await service.EditarObservacoesCliente(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockObservacoesCliente.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<ObservacoesCliente>())).Returns(Task.CompletedTask);

            var service = new ObservacoesClienteApiController(mock.Object);
            await service.ExcluirObservacoesCliente(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockObservacoesCliente.MontaObjetoUnico().Id)).ReturnsAsync(MockObservacoesCliente.MontaObjetoUnico());
            ObservacoesClienteApiController ret = new ObservacoesClienteApiController(mock.Object);
            var result = await ret.RetornaObservacoesClientePorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.ObservacoesCliente)result.Value).ObservacaoOp);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockObservacoesCliente.MontaListaItems());
            var controller = new ObservacoesClienteApiController(mock.Object);
            var result = await controller.ListaObservacoesCliente();
            var viewResult = Assert.IsType<List<ObservacoesCliente>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
