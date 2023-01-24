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
    public class NaturezaOperacaoTest
    {
        public Mock<INaturezaOperacao> mock = new Mock<INaturezaOperacao>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockNaturezaOperacao.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<NaturezaOperacao>())).Returns(Task.CompletedTask);

            var service = new NaturezaOperacaoApiController(mock.Object);
            await service.AdicionarNaturezaOperacao(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Descricao_Nao_Preenchido()
        {
            var modelo = MockNaturezaOperacao.MontaObjetoDescricaoVazia();
            var apiController = new NaturezaOperacaoApiController(mock.Object);
            var result = await apiController.AdicionarNaturezaOperacao(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Tipo_Nao_Valido()
        {
            var modelo = MockNaturezaOperacao.MontaObjetoTipoInvalido();
            var apiController = new NaturezaOperacaoApiController(mock.Object);
            var result = await apiController.AdicionarNaturezaOperacao(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockNaturezaOperacao.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<NaturezaOperacao>())).Returns(Task.CompletedTask);

            var service = new NaturezaOperacaoApiController(mock.Object);
            await service.EditarNaturezaOperacao(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockNaturezaOperacao.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<NaturezaOperacao>())).Returns(Task.CompletedTask);

            var service = new NaturezaOperacaoApiController(mock.Object);
            await service.ExcluirNaturezaOperacao(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockNaturezaOperacao.MontaObjetoUnico().Id)).ReturnsAsync(MockNaturezaOperacao.MontaObjetoUnico());
            NaturezaOperacaoApiController ret = new NaturezaOperacaoApiController(mock.Object);
            var result = await ret.RetornaNaturezaOperacaoPorId(1);
            //Assert.Equal("Teste Mock 1", ((Data.Entidades.NaturezaOperacao)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockNaturezaOperacao.MontaListaItems());
            var controller = new NaturezaOperacaoApiController(mock.Object);
            var result = await controller.ListaNaturezaOperacao();
            var viewResult = Assert.IsType<List<NaturezaOperacao>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
