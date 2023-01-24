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
    public class ContabilistaTest
    {
        public Mock<IContabilista> mock = new Mock<IContabilista>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockContabilista.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Contabilista>())).Returns(Task.CompletedTask);

            var service = new ContabilistaApiController(mock.Object);
            await service.AdicionarContabilista(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockContabilista.MontaObjetoNomeVazio();
            var apiController = new ContabilistaApiController(mock.Object);
            var result = await apiController.AdicionarContabilista(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockContabilista.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Contabilista>())).Returns(Task.CompletedTask);

            var service = new ContabilistaApiController(mock.Object);
            await service.EditarContabilista(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockContabilista.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Contabilista>())).Returns(Task.CompletedTask);

            var service = new ContabilistaApiController(mock.Object);
            await service.ExcluirContabilista(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockContabilista.MontaObjetoUnico().Id)).ReturnsAsync(MockContabilista.MontaObjetoUnico());
            ContabilistaApiController ret = new ContabilistaApiController(mock.Object);
            var result = await ret.RetornarContabilistaPorId(1);
            //Assert.Equal("Teste Mock 1", ((Data.Entidades.Contabilista)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockContabilista.MontaListaItems());
            var controller = new ContabilistaApiController(mock.Object);
            var result = await controller.ListaContabilista();
            var viewResult = Assert.IsType<List<Contabilista>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
