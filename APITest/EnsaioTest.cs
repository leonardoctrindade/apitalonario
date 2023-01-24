using Moq;
using Xunit;
using System;
using System.Linq;
using System.Text;
using APITest.Mocks;
using Data.Entidades;
using Data.Interfaces;
using WebAPI.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APITest
{
    public class EnsaioTest
    {
        public Mock<IEnsaio> mock = new Mock<IEnsaio>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockEnsaio.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Ensaio>())).Returns(Task.CompletedTask);

            var service = new EnsaioApiController(mock.Object);
            await service.AdicionarEnsaio(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockEnsaio.MontaObjetoNomeVazio();
            var apiController = new EnsaioApiController(mock.Object);
            var result = await apiController.AdicionarEnsaio(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockEnsaio.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Ensaio>())).Returns(Task.CompletedTask);

            var service = new EnsaioApiController(mock.Object);
            await service.EditarEnsaio(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockEnsaio.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Ensaio>())).Returns(Task.CompletedTask);

            var service = new EnsaioApiController(mock.Object);
            await service.ExcluirEnsaio(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorID()
        {
            mock.Setup(y => y.GetEntityById(MockEnsaio.MontaObjetoUnico().Id)).ReturnsAsync(MockEnsaio.MontaObjetoUnico());
            EnsaioApiController ret = new(mock.Object);
            var result = await ret.RetornaEnsaioPorId(1);
            //Assert.Equal("Teste Mock 1", ((Data.Entidades.Ensaio)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockEnsaio.MontaListaItems());
            var controller = new EnsaioApiController(mock.Object);
            var result = await controller.ListaEnsaio();
            var viewResult = Assert.IsType<List<Ensaio>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
