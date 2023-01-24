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
    public class TipoContatoTest
    {
        public Mock<ITipoContato> mock = new Mock<ITipoContato>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockTipoContato.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<TipoContato>())).Returns(Task.CompletedTask);

            var service = new TipoContatoApiController(mock.Object);
            await service.AdicionarTipoContato(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Descricao_Nao_Preenchido()
        {
            var modelo = MockTipoContato.MontaObjetoDescricaoVazio();
            var apiController = new TipoContatoApiController(mock.Object);
            var result = await apiController.AdicionarTipoContato(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockTipoContato.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<TipoContato>())).Returns(Task.CompletedTask);

            var service = new TipoContatoApiController(mock.Object);
            await service.EditarTipoContato(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockTipoContato.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<TipoContato>())).Returns(Task.CompletedTask);

            var service = new TipoContatoApiController(mock.Object);
            await service.ExcluirTipoContato(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockTipoContato.MontaObjetoUnico().Id)).ReturnsAsync(MockTipoContato.MontaObjetoUnico());
            TipoContatoApiController ret = new TipoContatoApiController(mock.Object);
            var result = await ret.RetornaTipoContatoPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.TipoContato)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockTipoContato.MontaListaItems());
            var controller = new TipoContatoApiController(mock.Object);
            var result = await controller.ListaTipoContato();
            var viewResult = Assert.IsType<List<TipoContato>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
