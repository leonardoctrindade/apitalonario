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
    public class EstadoTest
    {
        public Mock<IEstado> mock = new Mock<IEstado>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockEstado.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Estado>())).Returns(Task.CompletedTask);

            var service = new EstadoApiController(mock.Object);
            await service.AdicionarEstado(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockEstado.MontaObjetoNomeVazio();
            var apiController = new EstadoApiController(mock.Object);
            var result = await apiController.AdicionarEstado(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockEstado.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Estado>())).Returns(Task.CompletedTask);

            var service = new EstadoApiController(mock.Object);
            await service.EditarEstado(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockEstado.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Estado>())).Returns(Task.CompletedTask);

            var service = new EstadoApiController(mock.Object);
            await service.ExcluirEstado(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockEstado.MontaObjetoUnico().Id)).ReturnsAsync(MockEstado.MontaObjetoUnico());
            EstadoApiController ret = new EstadoApiController(mock.Object);
            var result = await ret.RetornaEstadoPorId(1);
            //Assert.Equal("Teste Mock 1", ((Data.Entidades.Estado)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockEstado.MontaListaItems());
            var controller = new EstadoApiController(mock.Object);
            var result = await controller.ListaEstado();
            var viewResult = Assert.IsType<List<Estado>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }

        [Fact]
        public async Task Insere_Sigla_Nao_Preenchido()
        {
            var modelo = MockEstado.MontaObjetoSiglaVazia();
            var apiController = new EstadoApiController(mock.Object);
            var result = await apiController.AdicionarEstado(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Sigla_Um_Caractere()
        {
            var modelo = MockEstado.MontaObjetoSiglaUmCaracter();
            var apiController = new EstadoApiController(mock.Object);
            var result = await apiController.AdicionarEstado(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Sigla_Tres_Caracteres()
        {
            var modelo = MockEstado.MontaObjetoSiglaTresCaracter();
            var apiController = new EstadoApiController(mock.Object);
            var result = await apiController.AdicionarEstado(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }
    }
}
