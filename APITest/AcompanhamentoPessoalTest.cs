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
    public class AcompanhamentoPessoalTest
    {
        public Mock<IAcompanhamentoPessoal> mock = new Mock<IAcompanhamentoPessoal>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockAcompanhamentoPessoal.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<AcompanhamentoPessoal>())).Returns(Task.CompletedTask);

            var service = new AcompanhamentoPessoalApiController(mock.Object);
            await service.AdicionarAcompanhamentoPessoal(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Data_Nao_Preenchida()
        {
            var modelo = MockAcompanhamentoPessoal.MontaObjetoDataVazia();
            var apiController = new AcompanhamentoPessoalApiController(mock.Object);
            var result = await apiController.AdicionarAcompanhamentoPessoal(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_ClienteId_Invalido()
        {
            var modelo = MockAcompanhamentoPessoal.MontaObjetoClienteIdInvalido();
            var apiController = new AcompanhamentoPessoalApiController(mock.Object);
            var result = await apiController.AdicionarAcompanhamentoPessoal(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockAcompanhamentoPessoal.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<AcompanhamentoPessoal>())).Returns(Task.CompletedTask);

            var service = new AcompanhamentoPessoalApiController(mock.Object);
            await service.EditarAcompanhamentoPessoal(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockAcompanhamentoPessoal.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<AcompanhamentoPessoal>())).Returns(Task.CompletedTask);

            var service = new AcompanhamentoPessoalApiController(mock.Object);
            await service.ExcluirAcompanhamentoPessoal(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockAcompanhamentoPessoal.MontaObjetoUnico().Id)).ReturnsAsync(MockAcompanhamentoPessoal.MontaObjetoUnico());
            AcompanhamentoPessoalApiController ret = new AcompanhamentoPessoalApiController(mock.Object);
            var result = await ret.RetornaAcompanhamentoPessoalPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.AcompanhamentoPessoal)result.Value).OutrasInformacoes);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockAcompanhamentoPessoal.MontaListaItems());
            var controller = new AcompanhamentoPessoalApiController(mock.Object);
            var result = await controller.ListaAcompanhamentoPessoal();
            var viewResult = Assert.IsType<List<AcompanhamentoPessoal>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
