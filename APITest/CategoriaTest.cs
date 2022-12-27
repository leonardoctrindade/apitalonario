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
    public class CategoriaTest
    {
        public Mock<ICategoria> mock = new Mock<ICategoria>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockCategoria.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Categoria>())).Returns(Task.CompletedTask);

            var service = new CategoriaApiController(mock.Object);
            await service.AdicionarCategoria(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockCategoria.MontaObjetoNomeVazio();
            var apiController = new CategoriaApiController(mock.Object);
            var result = await apiController.AdicionarCategoria(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockCategoria.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Categoria>())).Returns(Task.CompletedTask);

            var service = new CategoriaApiController(mock.Object);
            await service.EditarCategoria(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockCategoria.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Categoria>())).Returns(Task.CompletedTask);

            var service = new CategoriaApiController(mock.Object);
            await service.ExcluirCategoria(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockCategoria.MontaObjetoUnico().Id)).ReturnsAsync(MockCategoria.MontaObjetoUnico());
            CategoriaApiController ret = new CategoriaApiController(mock.Object);
            var result = await ret.RetornaCategoriaPorId(1);
            //Assert.Equal("Teste Mock 1", ((Data.Entidades.Categoria)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockCategoria.MontaListaItems());
            var controller = new CategoriaApiController(mock.Object);
            var result = await controller.ListaCategoria();
            var viewResult = Assert.IsType<List<Categoria>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
