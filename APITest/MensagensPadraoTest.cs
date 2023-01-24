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
    public class MensagensPadraoTest
    {
        public Mock<IMensagensPadrao> mock = new Mock<IMensagensPadrao>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockMensagensPadrao.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<MensagensPadrao>())).Returns(Task.CompletedTask);

            var service = new MensagensPadraoApiController(mock.Object);
            await service.AdicionarMensagensPadrao(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockMensagensPadrao.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<MensagensPadrao>())).Returns(Task.CompletedTask);

            var service = new MensagensPadraoApiController(mock.Object);
            await service.EditarMensagensPadrao(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockMensagensPadrao.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<MensagensPadrao>())).Returns(Task.CompletedTask);

            var service = new MensagensPadraoApiController(mock.Object);
            await service.ExcluirMensagensPadrao(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockMensagensPadrao.MontaObjetoUnico().Id)).ReturnsAsync(MockMensagensPadrao.MontaObjetoUnico());
            MensagensPadraoApiController ret = new MensagensPadraoApiController(mock.Object);
            var result = await ret.RetornaMensagensPadraoPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.MensagensPadrao)result.Value).Mensagem);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockMensagensPadrao.MontaListaItems());
            var controller = new MensagensPadraoApiController(mock.Object);
            var result = await controller.ListaMensagensPadrao();
            var viewResult = Assert.IsType<List<MensagensPadrao>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }

        [Fact]
        public async Task Insere_Mensagem_Nao_Preenchido()
        {
            var modelo = MockMensagensPadrao.MontaObjetoMensagemVazia();
            var apiController = new MensagensPadraoApiController(mock.Object);
            var result = await apiController.AdicionarMensagensPadrao(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_StatusDescricao_Nao_Preenchido()
        {
            var modelo = MockMensagensPadrao.MontaObjetoStatusDescricaoVazio();
            var apiController = new MensagensPadraoApiController(mock.Object);
            var result = await apiController.AdicionarMensagensPadrao(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }
    }
}
