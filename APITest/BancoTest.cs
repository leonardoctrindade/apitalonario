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
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace APITest
{
    public class BancoTest
    {
        public Mock<IBanco> mock = new Mock<IBanco>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockBanco.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Banco>())).Returns(Task.CompletedTask);

            var service = new BancoApiController(mock.Object);
            await service.AdicionarBanco(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockBanco.MontaObjetoNomeVazio();
            var apiController = new BancoApiController(mock.Object);
            var result = await apiController.AdicionarBanco(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_CodigoBanco_Nao_Preenchido()
        {
            var modelo = MockBanco.MontaObjetoCodigoBancoVazio();
            var apiController = new BancoApiController(mock.Object);
            var result = await apiController.AdicionarBanco(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockBanco.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Banco>())).Returns(Task.CompletedTask);

            var service = new BancoApiController(mock.Object);
            await service.EditarBanco(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockBanco.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Banco>())).Returns(Task.CompletedTask);

            var service = new BancoApiController(mock.Object);
            await service.ExcluirBanco(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockBanco.MontaObjetoUnico().Id)).ReturnsAsync(MockBanco.MontaObjetoUnico());
            BancoApiController ret = new BancoApiController(mock.Object);
            var result = await ret.RetornaBancoPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Banco)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockBanco.MontaListaItems());
            var controller = new BancoApiController(mock.Object);
            var result = await controller.ListaBanco();
            var viewResult = Assert.IsType<List<Banco>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
