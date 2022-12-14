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
    public class VendedorTest
    {
        public Mock<IVendedor> mock = new Mock<IVendedor>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockVendedor.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Vendedor>())).Returns(Task.CompletedTask);

            var service = new VendedorApiController(mock.Object);
            await service.AdicionarVendedor(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockVendedor.MontaObjetoNomeVazio();
            var apiController = new VendedorApiController(mock.Object);
            var result = await apiController.AdicionarVendedor(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockVendedor.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Vendedor>())).Returns(Task.CompletedTask);

            var service = new VendedorApiController(mock.Object);
            await service.EditarVendedor(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockVendedor.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Vendedor>())).Returns(Task.CompletedTask);

            var service = new VendedorApiController(mock.Object);
            await service.ExcluirVendedor(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockVendedor.MontaObjetoUnico().Id)).ReturnsAsync(MockVendedor.MontaObjetoUnico());
            VendedorApiController ret = new VendedorApiController(mock.Object);
            var result = await ret.RetornaVendedorPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Vendedor)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockVendedor.MontaListaItems());
            var controller = new VendedorApiController(mock.Object);
            var result = await controller.ListaVendedor();
            var viewResult = Assert.IsType<List<Vendedor>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
