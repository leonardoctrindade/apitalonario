using APITest.Mocks;
using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace APITest
{
    public class MoedaTest
    {
        public Mock<IMoeda> mock = new Mock<IMoeda>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var moeda = MockMoeda.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Moeda>())).Returns(Task.CompletedTask);

            var service = new MoedaApiController(mock.Object);
            await service.AdicionarMoeda(moeda);

            mock.Verify(y => y.Add(moeda));
        }
        [Fact]
        public async Task Insere_Nome_Vazio()
        {
            var moeda = MockMoeda.MontaObjetoNomeVazio();
            var service = new MoedaApiController(mock.Object);
            var result = await service.AdicionarMoeda(moeda);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }
        [Fact]
        public async Task Editar_Sucesso()
        {
            var moeda = MockMoeda.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Moeda>())).Returns(Task.CompletedTask);

            var service = new MoedaApiController(mock.Object);
            await service.EditarMoeda(moeda);

            mock.Verify(y => y.Update(moeda));
        }
        [Fact]
        public async Task Excluir_Sucesso()
        {
            var moeda = MockMoeda.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Moeda>())).Returns(Task.CompletedTask);

            var service = new MoedaApiController(mock.Object);
            await service.ExcluirMoeda(moeda);

            mock.Verify(y => y.Delete(moeda));
        }
        [Fact]
        public async Task RetornarProId()
        {
            mock.Setup(y => y.GetEntityById(MockMoeda.MontaObjetoUnico().Id)).ReturnsAsync(MockMoeda.MontaObjetoUnico());

            var service = new MoedaApiController(mock.Object);
            var result = await service.RetornarMoedaProId(1);
            Assert.Equal("Dólar", ((Data.Entidades.Moeda)result.Value).Nome);
        }
        [Fact]
        public async Task RetornarLista()
        {
            mock.Setup(rep => rep.List()).ReturnsAsync(MockMoeda.MontaListaItens());
            var service = new MoedaApiController(mock.Object);
            var result = await service.ListaMoeda();
            var ViewResult = Assert.IsType<List<Moeda>>(result.Value);

            Assert.Equal(3,ViewResult.Count);
        }
    }
}
