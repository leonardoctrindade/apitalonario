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
    public class GrupoEnsaioTest
    {
        public Mock<IGrupoEnsaio> mock = new Mock<IGrupoEnsaio>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockGrupoEnsaio.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<GrupoEnsaio>())).Returns(Task.CompletedTask);

            var service = new GrupoEnsaioApiController(mock.Object);
            await service.AdicionarGrupoEnsaio(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_GrupoId_Invalido()
        {
            var modelo = MockGrupoEnsaio.MontaObjetoGrupoIdInvalido();
            var apiController = new GrupoEnsaioApiController(mock.Object);
            var result = await apiController.AdicionarGrupoEnsaio(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_EnsaioId_Invalido()
        {
            var modelo = MockGrupoEnsaio.MontaObjetoEnsaioIdInvalido();
            var apiController = new GrupoEnsaioApiController(mock.Object);
            var result = await apiController.AdicionarGrupoEnsaio(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockGrupoEnsaio.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<GrupoEnsaio>())).Returns(Task.CompletedTask);

            var service = new GrupoEnsaioApiController(mock.Object);
            await service.EditarGrupoEnsaio(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockGrupoEnsaio.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<GrupoEnsaio>())).Returns(Task.CompletedTask);

            var service = new GrupoEnsaioApiController(mock.Object);
            await service.ExcluirGrupoEnsaio(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockGrupoEnsaio.MontaObjetoUnico().Id)).ReturnsAsync(MockGrupoEnsaio.MontaObjetoUnico());
            GrupoEnsaioApiController ret = new GrupoEnsaioApiController(mock.Object);
            var result = await ret.RetornaGrupoEnsaioPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.GrupoEnsaio)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockGrupoEnsaio.MontaListaItems());
            var controller = new GrupoEnsaioApiController(mock.Object);
            var result = await controller.ListaGrupoEnsaio();
            var viewResult = Assert.IsType<List<GrupoEnsaio>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
