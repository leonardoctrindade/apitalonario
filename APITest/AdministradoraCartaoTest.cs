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
    public class AdministradoraCartaoTest
    {
        public Mock<IAdministradoraCartao> mock = new Mock<IAdministradoraCartao>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockAdministradoraCartao.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<AdministradoraCartao>())).Returns(Task.CompletedTask);

            var service = new AdministradoraCartaoApiController(mock.Object);
            await service.AdicionarAdministradoraCartao(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockAdministradoraCartao.MontaObjetoNomeVazio();
            var apiController = new AdministradoraCartaoApiController(mock.Object);
            var result = await apiController.AdicionarAdministradoraCartao(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockAdministradoraCartao.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<AdministradoraCartao>())).Returns(Task.CompletedTask);

            var service = new AdministradoraCartaoApiController(mock.Object);
            await service.EditarAdministradoraCartao(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockAdministradoraCartao.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<AdministradoraCartao>())).Returns(Task.CompletedTask);

            var service = new AdministradoraCartaoApiController(mock.Object);
            await service.ExcluirAdministradoraCartao(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockAdministradoraCartao.MontaObjetoUnico().Id)).ReturnsAsync(MockAdministradoraCartao.MontaObjetoUnico());
            AdministradoraCartaoApiController ret = new AdministradoraCartaoApiController(mock.Object);
            var result = await ret.RetornaAdministradoraCartaoPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.AdministradoraCartao)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockAdministradoraCartao.MontaListaItems());
            var controller = new AdministradoraCartaoApiController(mock.Object);
            var result = await controller.ListaAdministradoraCartao();
            var viewResult = Assert.IsType<List<AdministradoraCartao>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
