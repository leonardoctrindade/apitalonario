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
    public class GrupoUsuarioTest
    {
        public Mock<IGrupoUsuario> mock = new Mock<IGrupoUsuario>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockGrupoUsuario.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<GrupoUsuario>())).Returns(Task.CompletedTask);

            var service = new GrupoUsuarioApiController(mock.Object);
            await service.AdicionarGrupoUsuario(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Descricao_Nao_Preenchido()
        {
            var modelo = MockGrupoUsuario.MontaObjetoDescricaoVazia();
            var apiController = new GrupoUsuarioApiController(mock.Object);
            var result = await apiController.AdicionarGrupoUsuario(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockGrupoUsuario.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<GrupoUsuario>())).Returns(Task.CompletedTask);

            var service = new GrupoUsuarioApiController(mock.Object);
            await service.EditarGrupoUsuario(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockGrupoUsuario.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<GrupoUsuario>())).Returns(Task.CompletedTask);

            var service = new GrupoUsuarioApiController(mock.Object);
            await service.ExcluirGrupoUsuario(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockGrupoUsuario.MontaObjetoUnico().Id)).ReturnsAsync(MockGrupoUsuario.MontaObjetoUnico());
            GrupoUsuarioApiController ret = new GrupoUsuarioApiController(mock.Object);
            var result = await ret.RetornaGrupoUsuarioPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.GrupoUsuario)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockGrupoUsuario.MontaListaItems());
            var controller = new GrupoUsuarioApiController(mock.Object);
            var result = await controller.ListaGrupoUsuario();
            var viewResult = Assert.IsType<List<GrupoUsuario>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
