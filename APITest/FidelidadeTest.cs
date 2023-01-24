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
    public class FidelidadeTest
    {
        public Mock<IFidelidade> mock = new Mock<IFidelidade>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockFidelidade.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Fidelidade>())).Returns(Task.CompletedTask);

            var service = new FidelidadeApiController(mock.Object);
            await service.AdicionarFidelidade(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Descricao_Nao_Preenchido()
        {
            var modelo = MockFidelidade.MontaObjetoDescricaoVazia();
            var apiController = new FidelidadeApiController(mock.Object);
            var result = await apiController.AdicionarFidelidade(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockFidelidade.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Fidelidade>())).Returns(Task.CompletedTask);

            var service = new FidelidadeApiController(mock.Object);
            await service.EditarFidelidade(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockFidelidade.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Fidelidade>())).Returns(Task.CompletedTask);

            var service = new FidelidadeApiController(mock.Object);
            await service.ExcluirFidelidade(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockFidelidade.MontaObjetoUnico().Id)).ReturnsAsync(MockFidelidade.MontaObjetoUnico());
            FidelidadeApiController ret = new FidelidadeApiController(mock.Object);
            var result = await ret.RetornaFidelidadePorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Fidelidade)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockFidelidade.MontaListaItems());
            var controller = new FidelidadeApiController(mock.Object);
            var result = await controller.ListaFidelidade();
            var viewResult = Assert.IsType<List<Fidelidade>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
