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
    public class BalancaTest
    {
        public Mock<IBalanca> mock = new Mock<IBalanca>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockBalanca.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Balanca>())).Returns(Task.CompletedTask);

            var service = new BalancaApiController(mock.Object);
            await service.AdicionarBalanca(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Modelo_Vazio()
        {
            var modelo = MockBalanca.MontaObjetoModeloVazio();
            var apiController = new BalancaApiController(mock.Object);
            var result = await apiController.AdicionarBalanca(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_PortaCom_Vazio()
        {
            var modelo = MockBalanca.MontaObjetoPortaComVazia();
            var apiController = new BalancaApiController(mock.Object);
            var result = await apiController.AdicionarBalanca(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockBalanca.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Balanca>())).Returns(Task.CompletedTask);

            var service = new BalancaApiController(mock.Object);
            await service.EditarBalanca(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockBalanca.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Balanca>())).Returns(Task.CompletedTask);

            var service = new BalancaApiController(mock.Object);
            await service.ExcluirBalanca(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockBalanca.MontaObjetoUnico().Id)).ReturnsAsync(MockBalanca.MontaObjetoUnico());
            BalancaApiController ret = new BalancaApiController(mock.Object);
            var result = await ret.RetornaBalancaPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Balanca)result.Value).Modelo);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockBalanca.MontaListaItems());
            var controller = new BalancaApiController(mock.Object);
            var result = await controller.ListaBalanca();
            var viewResult = Assert.IsType<List<Balanca>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
