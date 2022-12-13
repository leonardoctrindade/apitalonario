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
    public class TransacaoTest
    {
        public Mock<ITransacao> mock = new Mock<ITransacao>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockTransacao.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Transacao>())).Returns(Task.CompletedTask);

            var service = new TransacaoApiController(mock.Object);
            await service.AdicionarTransacao(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockTransacao.MontaObjetoDescricaoVazia();
            var apiController = new TransacaoApiController(mock.Object);
            var result = await apiController.AdicionarTransacao(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Tipo_Invalido()
        {
            var modelo = MockTransacao.MontaObjetoTipoInvalido();
            var apiController = new TransacaoApiController(mock.Object);
            var result = await apiController.AdicionarTransacao(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockTransacao.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Transacao>())).Returns(Task.CompletedTask);

            var service = new TransacaoApiController(mock.Object);
            await service.EditarTransacao(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockTransacao.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Transacao>())).Returns(Task.CompletedTask);

            var service = new TransacaoApiController(mock.Object);
            await service.ExcluirTransacao(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockTransacao.MontaObjetoUnico().Id)).ReturnsAsync(MockTransacao.MontaObjetoUnico());
            TransacaoApiController ret = new TransacaoApiController(mock.Object);
            var result = await ret.RetornaTransacaoPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Transacao)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockTransacao.MontaListaItems());
            var controller = new TransacaoApiController(mock.Object);
            var result = await controller.ListaTransacao();
            var viewResult = Assert.IsType<List<Transacao>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
