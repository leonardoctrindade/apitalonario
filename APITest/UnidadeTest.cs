using APITest.Mocks;
using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
    public class UnidadeTest
    {
        public Mock<IUnidade> mock = new Mock<IUnidade>();
        [Fact]
        public async Task Insere_Sucesso()
        {
            var unidade = MockUnidade.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Unidade>())).Returns(Task.CompletedTask);

            var service = new UnidadeApiController(mock.Object);
            await service.AdicionarUnidade(unidade);

            mock.Verify(y => y.Add(unidade));
        }
        [Fact]
        public async Task Insere_Sigla_Vazio()
        {
            var unidade = MockUnidade.MontaObjetoSiglaVazio();
            var service = new UnidadeApiController(mock.Object);
            var result  = await service.AdicionarUnidade(unidade);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }
        [Fact]
        public async Task Insere_Descricao_Vazio()
        {
            var unidade = MockUnidade.MontaObjetoDescricaoVazio();
            var service = new UnidadeApiController(mock.Object);
            var result = await service.AdicionarUnidade(unidade);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var unidade = MockUnidade.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Unidade>())).Returns(Task.CompletedTask);

            var service = new UnidadeApiController(mock.Object);
            await service.EditarUnidade(unidade);

            mock.Verify(y => y.Update(unidade));
        }

        [Fact]
        public async Task RetornarProId()
        {
            mock.Setup(y => y.GetEntityById(MockUnidade.MontaObjetoUnico().Id)).ReturnsAsync(MockUnidade.MontaObjetoUnico);
            var service = new UnidadeApiController(mock.Object);
            var result = await service.RetornarUnidadeProId(1);
            //Assert.Equal("Unidade", ((Data.Entidades.Unidade)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornarLista()
        {
            mock.Setup(y => y.List()).ReturnsAsync(MockUnidade.MontaListaItens());
            var service = new UnidadeApiController(mock.Object);
            var result = await service.ListaUnidade();
            var viewResult = Assert.IsType<List<Unidade>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
