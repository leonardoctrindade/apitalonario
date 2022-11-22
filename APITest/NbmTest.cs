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
    public class NbmTest
    {
        public Mock<INbm> mock = new Mock<INbm>();
        [Fact]
        public async Task Insere_Sucesso()
        {
            var nbm = MockNbm.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Nbm>())).Returns(Task.CompletedTask);

            var service = new NbmApiController(mock.Object);

            await service.AdicionarNbm(nbm);

            mock.Verify(y => y.Add(nbm));
        }
        [Fact]
        public async Task Insere_CodigoNbm_Vazio()
        {
            var nbm = MockNbm.MontaObjetoCodigoNbmVazio();
            var service = new NbmApiController(mock.Object);
            var result = await service.AdicionarNbm(nbm);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }
        [Fact]
        public async Task Insere_Descricao_Vazio()
        {
            var nbm = MockNbm.MontaObjetoDescricaoVazio();
            var service = new NbmApiController(mock.Object);
            var result = await service.AdicionarNbm(nbm);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }
        [Fact]
        public async Task Editar_Sucesso()
        {
            var nbm = MockNbm.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Nbm>())).Returns(Task.CompletedTask);

            var service = new NbmApiController(mock.Object);

            await service.EditarNbm(nbm);

            mock.Verify(y => y.Update(nbm));
        }
        [Fact]
        public async Task Excluir_Sucesso()
        {
            var nbm = MockNbm.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Nbm>())).Returns(Task.CompletedTask);

            var service = new NbmApiController(mock.Object);
            await service.ExcluirNbm(nbm);

            mock.Verify(y => y.Delete(nbm));
        }
        [Fact]
        public async Task RetornarPorId()
        {
            mock.Setup(y => y.GetEntityById(MockNbm.MontaObjetoUnico().Id)).ReturnsAsync(MockNbm.MontaObjetoUnico());
            var service = new NbmApiController(mock.Object);
            var result = await service.RetornarNbmPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Nbm)result.Value).Descricao);
        }
        [Fact]
        public async Task RetornarLista()
        {
            mock.Setup(y => y.List()).ReturnsAsync(MockNbm.MontaListaItens());
            var service = new NbmApiController(mock.Object);
            var result = await service.ListaNbm();
            var viewResult = Assert.IsType<List<Nbm>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
