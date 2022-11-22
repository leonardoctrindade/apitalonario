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
    public class DciTest
    {
        public Mock<IDci> mock = new Mock<IDci>();
        [Fact]
        public async Task Insere_Sucesso()
        {
            var dci = MockDci.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Dci>())).Returns(Task.CompletedTask);

            var service = new DciApiController(mock.Object);

            await service.AdicionarDci(dci);

            mock.Verify(y => y.Add(dci));
        }
        [Fact]
        public async Task Insere_CodigoDci_Vazio()
        {
            var dci = MockDci.MontaObjetoCodigoDciVazio();
            var service = new DciApiController(mock.Object);
            var result = await service.AdicionarDci(dci);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }
        [Fact]
        public async Task Insere_Descricao_Vazio()
        {
            var dci = MockDci.MontaObjetoDescricaoVazio();
            var service = new DciApiController(mock.Object);
            var result = await service.AdicionarDci(dci);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }
        [Fact]
        public async Task Editar_Sucesso()
        {
            var dci = MockDci.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Dci>())).Returns(Task.CompletedTask);

            var service = new DciApiController(mock.Object);
            await service.EditarDci(dci);

            mock.Verify(y => y.Update(dci));
        }
        [Fact]
        public async Task Excluir_Sucesso()
        {
            var dci = MockDci.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Dci>())).Returns(Task.CompletedTask);

            var service = new DciApiController(mock.Object);
            await service.ExcluirDci(dci);

            mock.Verify(y => y.Delete(dci));
        }
        [Fact]
        public async Task RetornarPorId()
        {
            mock.Setup(y => y.GetEntityById(MockDci.MontaObjetoUnico().Id)).ReturnsAsync(MockDci.MontaObjetoUnico());
            var service = new DciApiController(mock.Object);
            var result = await service.RetornarPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Dci)result.Value).Descricao);
        }
        [Fact]
        public async Task RetornarLista()
        {
            mock.Setup(rep => rep.List()).ReturnsAsync(MockDci.MontaListaItems());
            var service = new DciApiController(mock.Object);
            var result = await service.ListaDci();
            var viewResult = Assert.IsType<List<Dci>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
