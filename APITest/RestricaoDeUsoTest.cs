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
    public class RestricaoDeUsoTest
    {
        public Mock<IRestricaoDeUso> mock = new Mock<IRestricaoDeUso>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockRestricaoDeUso.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<RestricaoDeUso>())).Returns(Task.CompletedTask);

            var service = new RestricaoDeUsoApiController(mock.Object);
            await service.AdicionarRestricaoDeUso(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_ProdutoId_Invalido()
        {
            var modelo = MockRestricaoDeUso.MontaObjetoProdutoIdInvalido();
            var apiController = new RestricaoDeUsoApiController(mock.Object);
            var result = await apiController.AdicionarRestricaoDeUso(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_GrupoId_Invalido()
        {
            var modelo = MockRestricaoDeUso.MontaObjetoGrupoIdInvalido();
            var apiController = new RestricaoDeUsoApiController(mock.Object);
            var result = await apiController.AdicionarRestricaoDeUso(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_ClienteId_Invalido()
        {
            var modelo = MockRestricaoDeUso.MontaObjetoClienteIdInvalido();
            var apiController = new RestricaoDeUsoApiController(mock.Object);
            var result = await apiController.AdicionarRestricaoDeUso(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockRestricaoDeUso.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<RestricaoDeUso>())).Returns(Task.CompletedTask);

            var service = new RestricaoDeUsoApiController(mock.Object);
            await service.EditarRestricaoDeUso(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockRestricaoDeUso.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<RestricaoDeUso>())).Returns(Task.CompletedTask);

            var service = new RestricaoDeUsoApiController(mock.Object);
            await service.ExcluirRestricaoDeUso(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockRestricaoDeUso.MontaObjetoUnico().Id)).ReturnsAsync(MockRestricaoDeUso.MontaObjetoUnico());
            RestricaoDeUsoApiController ret = new RestricaoDeUsoApiController(mock.Object);
            var result = await ret.RetornaRestricaoDeUsoPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.RestricaoDeUso)result.Value).Observacao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockRestricaoDeUso.MontaListaItems());
            var controller = new RestricaoDeUsoApiController(mock.Object);
            var result = await controller.ListaRestricaoDeUso();
            var viewResult = Assert.IsType<List<RestricaoDeUso>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
