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
    public class UsuarioTest
    {
        public Mock<IUsuario> mock = new Mock<IUsuario>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockUsuario.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Usuario>())).Returns(Task.CompletedTask);

            var service = new UsuarioApiController(mock.Object);
            await service.AdicionarUsuario(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockUsuario.MontaObjetoNomeVazio();
            var apiController = new UsuarioApiController(mock.Object);
            var result = await apiController.AdicionarUsuario(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_NomeAbreviado_Nao_Preenchido()
        {
            var modelo = MockUsuario.MontaObjetoNomeAbreviadoVazio();
            var apiController = new UsuarioApiController(mock.Object);
            var result = await apiController.AdicionarUsuario(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Senha_Nao_Preenchido()
        {
            var modelo = MockUsuario.MontaObjetoSenhaVazia();
            var apiController = new UsuarioApiController(mock.Object);
            var result = await apiController.AdicionarUsuario(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_IdGrupuUsuario_Invalido()
        {
            var modelo = MockUsuario.MontaObjetoIdGrupoUsuarioInvalido();
            var apiController = new UsuarioApiController(mock.Object);
            var result = await apiController.AdicionarUsuario(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockUsuario.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Usuario>())).Returns(Task.CompletedTask);

            var service = new UsuarioApiController(mock.Object);
            await service.EditarUsuario(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockUsuario.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Usuario>())).Returns(Task.CompletedTask);

            var service = new UsuarioApiController(mock.Object);
            await service.ExcluirUsuario(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockUsuario.MontaObjetoUnico().Id)).ReturnsAsync(MockUsuario.MontaObjetoUnico());
            UsuarioApiController ret = new UsuarioApiController(mock.Object);
            var result = await ret.RetornaUsuarioPorId(1);
            //Assert.Equal("Teste Mock 1", ((Data.Entidades.Usuario)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockUsuario.MontaListaItems());
            var controller = new UsuarioApiController(mock.Object);
            var result = await controller.ListaUsuario();
            var viewResult = Assert.IsType<List<Usuario>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
