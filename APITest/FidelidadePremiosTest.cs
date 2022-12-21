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
    public class FidelidadePremiosTest
    {
        public Mock<IFidelidadePremios> mock = new Mock<IFidelidadePremios>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockFidelidadePremios.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<FidelidadePremios>())).Returns(Task.CompletedTask);

            var service = new FidelidadePremiosApiController(mock.Object);
            await service.AdicionarFidelidadePremios(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_IdGrupo_Invalido()
        {
            var modelo = MockFidelidadePremios.MontaObjetoIdGrupoInvalido();
            var apiController = new FidelidadePremiosApiController(mock.Object);
            var result = await apiController.AdicionarFidelidadePremios(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_IdProduto_Invalido()
        {
            var modelo = MockFidelidadePremios.MontaObjetoIdProdutoInvalido();
            var apiController = new FidelidadePremiosApiController(mock.Object);
            var result = await apiController.AdicionarFidelidadePremios(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_IdFidelidade_Invalido()
        {
            var modelo = MockFidelidadePremios.MontaObjetoIdFidelidadeInvalido();
            var apiController = new FidelidadePremiosApiController(mock.Object);
            var result = await apiController.AdicionarFidelidadePremios(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Pontos_Invalido()
        {
            var modelo = MockFidelidadePremios.MontaObjetoPontosInvalido();
            var apiController = new FidelidadePremiosApiController(mock.Object);
            var result = await apiController.AdicionarFidelidadePremios(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockFidelidadePremios.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<FidelidadePremios>())).Returns(Task.CompletedTask);

            var service = new FidelidadePremiosApiController(mock.Object);
            await service.EditarFidelidadePremios(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockFidelidadePremios.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<FidelidadePremios>())).Returns(Task.CompletedTask);

            var service = new FidelidadePremiosApiController(mock.Object);
            await service.ExcluirFidelidadePremios(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockFidelidadePremios.MontaObjetoUnico().Id)).ReturnsAsync(MockFidelidadePremios.MontaObjetoUnico());
            FidelidadePremiosApiController ret = new FidelidadePremiosApiController(mock.Object);
            var result = await ret.RetornaFidelidadePremiosPorId(1);
            Assert.Equal(0 , ((Data.Entidades.FidelidadePremios)result.Value).Pontos);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockFidelidadePremios.MontaListaItems());
            var controller = new FidelidadePremiosApiController(mock.Object);
            var result = await controller.ListaFidelidadePremios();
            var viewResult = Assert.IsType<List<FidelidadePremios>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
