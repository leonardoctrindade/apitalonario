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
    public class GrupoTest
    {
        public Mock<IGrupo> mock = new Mock<IGrupo>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockGrupo.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Grupo>())).Returns(Task.CompletedTask);

            var service = new GrupoApiController(mock.Object);
            await service.AdicionarGrupo(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Descricao_Nao_Preenchido()
        {
            var modelo = MockGrupo.MontaObjetoDescricaoVazia();
            var apiController = new GrupoApiController(mock.Object);
            var result = await apiController.AdicionarGrupo(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_PercentualDesconto_Invalida()
        {
            var modelo = MockGrupo.MontaObjetoPercentualDescontoInvalido();
            var apiController = new GrupoApiController(mock.Object);
            var result = await apiController.AdicionarGrupo(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockGrupo.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Grupo>())).Returns(Task.CompletedTask);

            var service = new GrupoApiController(mock.Object);
            await service.EditarGrupo(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockGrupo.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Grupo>())).Returns(Task.CompletedTask);

            var service = new GrupoApiController(mock.Object);
            await service.ExcluirGrupo(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockGrupo.MontaObjetoUnico().Id)).ReturnsAsync(MockGrupo.MontaObjetoUnico());
            GrupoApiController ret = new GrupoApiController(mock.Object);
            var result = await ret.RetornaGrupoPorId(1);
            //Assert.Equal("Teste Mock 1", ((Data.Entidades.Grupo)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockGrupo.MontaListaItems());
            var controller = new GrupoApiController(mock.Object);
            var result = await controller.ListaGrupo();
            var viewResult = Assert.IsType<List<Grupo>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
