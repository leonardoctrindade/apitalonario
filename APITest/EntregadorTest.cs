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
    public class EntregadorTest
    {
        public Mock<IEntregador> mock = new Mock<IEntregador>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockEntregador.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Entregador>())).Returns(Task.CompletedTask);

            var service = new EntregadorApiController(mock.Object);
            await service.AdicionarEntregador(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockEntregador.MontaObjetoNomeVazio();
            var apiController = new EntregadorApiController(mock.Object);
            var result = await apiController.AdicionarEntregador(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Ddd_Nao_Preenchido()
        {
            var modelo = MockEntregador.MontaObjetoDddVazio();
            var apiController = new EntregadorApiController(mock.Object);
            var result = await apiController.AdicionarEntregador(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Telefone_Nao_Preenchido()
        {
            var modelo = MockEntregador.MontaObjetoTelefoneVazio();
            var apiController = new EntregadorApiController(mock.Object);
            var result = await apiController.AdicionarEntregador(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockEntregador.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Entregador>())).Returns(Task.CompletedTask);

            var service = new EntregadorApiController(mock.Object);
            await service.EditarEntregador(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockEntregador.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Entregador>())).Returns(Task.CompletedTask);

            var service = new EntregadorApiController(mock.Object);
            await service.ExcluirEntregador(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockEntregador.MontaObjetoUnico().Id)).ReturnsAsync(MockEntregador.MontaObjetoUnico());
            EntregadorApiController ret = new EntregadorApiController(mock.Object);
            var result = await ret.RetornaEntregadorPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Entregador)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockEntregador.MontaListaItems());
            var controller = new EntregadorApiController(mock.Object);
            var result = await controller.ListaEntregador();
            var viewResult = Assert.IsType<List<Entregador>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
