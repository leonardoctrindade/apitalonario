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
    public class TransportadorTest
    {
        public Mock<ITransportador> mock = new Mock<ITransportador>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockTransportador.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Transportador>())).Returns(Task.CompletedTask);

            var service = new TransportadorApiController(mock.Object);
            await service.AdicionarTransportador(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockTransportador.MontaObjetoNomeVazio();
            var apiController = new TransportadorApiController(mock.Object);
            var result = await apiController.AdicionarTransportador(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_CpfOuCnpj_Nao_Preenchido()
        {
            var modelo = MockTransportador.MontaObjetoCpfOuCnpjVazio();
            var apiController = new TransportadorApiController(mock.Object);
            var result = await apiController.AdicionarTransportador(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockTransportador.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Transportador>())).Returns(Task.CompletedTask);

            var service = new TransportadorApiController(mock.Object);
            await service.EditarTransportador(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockTransportador.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Transportador>())).Returns(Task.CompletedTask);

            var service = new TransportadorApiController(mock.Object);
            await service.ExcluirTransportador(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockTransportador.MontaObjetoUnico().Id)).ReturnsAsync(MockTransportador.MontaObjetoUnico());
            TransportadorApiController ret = new TransportadorApiController(mock.Object);
            var result = await ret.RetornaTransportadorPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Transportador)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockTransportador.MontaListaItems());
            var controller = new TransportadorApiController(mock.Object);
            var result = await controller.ListaTransportador();
            var viewResult = Assert.IsType<List<Transportador>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
