using APITest.Mocks;
using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace APITest
{
    public class VisitadorTest
    {
        public Mock<IVisitador> mock = new Mock<IVisitador>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var visitador = MockVisitador.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Visitador>())).Returns(Task.CompletedTask);

            var service = new VisitadorApiController(mock.Object);
            await service.AdicionarVisitador(visitador);

            mock.Verify(y => y.Add(visitador));
        }
        [Theory]
        [InlineData("")]
        public async Task Insere_Nome_Nao_Preenchido(string nome)
        {
            var visitador = MockVisitador.MontaObjetoNomeVazio(nome);

            var service = new VisitadorApiController(mock.Object);

            var result = await service.AdicionarVisitador(visitador);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }
        [Fact]
        public async Task Editar_Sucesso()
        {
            var visitador = MockVisitador.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Visitador>())).Returns(Task.CompletedTask);

            var service = new VisitadorApiController(mock.Object);
            await service.EditarVisitador(visitador);

            mock.Verify(y => y.Update(visitador));
        }
        [Fact]
        public async Task Excluir_Sucesso()
        {
            var visitador = MockVisitador.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Visitador>())).Returns(Task.CompletedTask);

            var service = new VisitadorApiController(mock.Object);
            await service.ExcluirVisitador(visitador);

            mock.Verify(y => y.Delete(visitador));
        }
        [Fact]
        public async Task RetornarPorId()
        {
            mock.Setup(y => y.GetEntityById(MockVisitador.MontaObjetoUnico().Id)).ReturnsAsync(MockVisitador.MontaObjetoUnico());
            
            var service = new VisitadorApiController(mock.Object);

            var result = await service.RetornarVisitadorPorId(1);

            //Assert.Equal("Teste Mock", ((Data.Entidades.Visitador)result.Value).Nome);
        }
        [Fact]
        public async Task RetornarLista()
        {
            mock.Setup(y => y.List()).ReturnsAsync(MockVisitador.MontaListaItens());

            var service = new VisitadorApiController(mock.Object);
            var result = await service.ListaVisitador();

            var viewResult = Assert.IsType<List<Visitador>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }

    }
}
