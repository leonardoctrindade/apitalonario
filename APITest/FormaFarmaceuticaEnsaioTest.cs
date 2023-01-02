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
    public class FormaFarmaceuticaEnsaioTest
    {
        public Mock<IFormaFarmaceuticaEnsaio> mock = new Mock<IFormaFarmaceuticaEnsaio>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockFormaFarmaceuticaEnsaio.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<FormaFarmaceuticaEnsaio>())).Returns(Task.CompletedTask);

            var service = new FormaFarmaceuticaEnsaioApiController(mock.Object);
            await service.AdicionarFormaFarmaceuticaEnsaio(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Descricao_Vazia()
        {
            var modelo = MockFormaFarmaceuticaEnsaio.MontaObjetoDescricaoVazia();
            var apiController = new FormaFarmaceuticaEnsaioApiController(mock.Object);
            var result = await apiController.AdicionarFormaFarmaceuticaEnsaio(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_FormaFarmaceuticaId_Invalida()
        {
            var modelo = MockFormaFarmaceuticaEnsaio.MontaObjetoFormaFarmaceuticaIdInvalido();
            var apiController = new FormaFarmaceuticaEnsaioApiController(mock.Object);
            var result = await apiController.AdicionarFormaFarmaceuticaEnsaio(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockFormaFarmaceuticaEnsaio.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<FormaFarmaceuticaEnsaio>())).Returns(Task.CompletedTask);

            var service = new FormaFarmaceuticaEnsaioApiController(mock.Object);
            await service.EditarFormaFarmaceuticaEnsaio(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockFormaFarmaceuticaEnsaio.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<FormaFarmaceuticaEnsaio>())).Returns(Task.CompletedTask);

            var service = new FormaFarmaceuticaEnsaioApiController(mock.Object);
            await service.ExcluirFormaFarmaceuticaEnsaio(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockFormaFarmaceuticaEnsaio.MontaObjetoUnico().Id)).ReturnsAsync(MockFormaFarmaceuticaEnsaio.MontaObjetoUnico());
            FormaFarmaceuticaEnsaioApiController ret = new FormaFarmaceuticaEnsaioApiController(mock.Object);
            var result = await ret.RetornaFormaFarmaceuticaEnsaioPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.FormaFarmaceuticaEnsaio)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockFormaFarmaceuticaEnsaio.MontaListaItems());
            var controller = new FormaFarmaceuticaEnsaioApiController(mock.Object);
            var result = await controller.ListaFormaFarmaceuticaEnsaio();
            var viewResult = Assert.IsType<List<FormaFarmaceuticaEnsaio>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
