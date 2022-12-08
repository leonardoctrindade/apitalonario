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
    public class EspecificacaoCapsulaTest
    {
        public Mock<IEspecificacaoCapsula> mock = new Mock<IEspecificacaoCapsula>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockEspecificacaoCapsula.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<EspecificacaoCapsula>())).Returns(Task.CompletedTask);

            var service = new EspecificacaoCapsulaApiController(mock.Object);
            await service.AdicionarEspecificacaoCapsula(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Descricao_Nao_Preenchido()
        {
            var modelo = MockEspecificacaoCapsula.MontaObjetoDescricaoVazia();
            var apiController = new EspecificacaoCapsulaApiController(mock.Object);
            var result = await apiController.AdicionarEspecificacaoCapsula(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockEspecificacaoCapsula.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<EspecificacaoCapsula>())).Returns(Task.CompletedTask);

            var service = new EspecificacaoCapsulaApiController(mock.Object);
            await service.EditarEspecificacaoCapsula(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockEspecificacaoCapsula.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<EspecificacaoCapsula>())).Returns(Task.CompletedTask);

            var service = new EspecificacaoCapsulaApiController(mock.Object);
            await service.ExcluirEspecificacaoCapsula(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockEspecificacaoCapsula.MontaObjetoUnico().Id)).ReturnsAsync(MockEspecificacaoCapsula.MontaObjetoUnico());
            EspecificacaoCapsulaApiController ret = new EspecificacaoCapsulaApiController(mock.Object);
            var result = await ret.RetornaEspecificacaoCapsulaPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.EspecificacaoCapsula)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockEspecificacaoCapsula.MontaListaItems());
            var controller = new EspecificacaoCapsulaApiController(mock.Object);
            var result = await controller.ListaEspecificacaoCapsula();
            var viewResult = Assert.IsType<List<EspecificacaoCapsula>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }

    }
}
