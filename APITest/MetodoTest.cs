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
    public class MetodoTest
    {
        public Mock<IMetodo> mock = new Mock<IMetodo>();


        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockMetodo.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Metodo>())).Returns(Task.CompletedTask);

            var service = new MetodoApiController(mock.Object);
            await service.AdicionarMetodo(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Descricao_Nao_Preenchido()
        {
            var modelo = MockMetodo.MontaObjetoDescricaoVazia();
            var apiController = new MetodoApiController(mock.Object);
            var result = await apiController.AdicionarMetodo(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockMetodo.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Metodo>())).Returns(Task.CompletedTask);

            var service = new MetodoApiController(mock.Object);
            await service.EditarMetodo(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockMetodo.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Metodo>())).Returns(Task.CompletedTask);

            var service = new MetodoApiController(mock.Object);
            await service.ExcluirMetodo(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockMetodo.MontaObjetoUnico().Id)).ReturnsAsync(MockMetodo.MontaObjetoUnico());
            MetodoApiController ret = new MetodoApiController(mock.Object);
            var result = await ret.RetornaMetodoPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Metodo)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockMetodo.MontaListaItems());
            var controller = new MetodoApiController(mock.Object);
            var result = await controller.ListaMetodo();
            var viewResult = Assert.IsType<List<Metodo>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
