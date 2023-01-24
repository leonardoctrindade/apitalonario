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
    public class ContaCorrenteTest
    {
        public Mock<IContaCorrente> mock = new Mock<IContaCorrente>();
        [Fact]
        public async Task Insere_ContaCorrente_Sucesso()
        {
            var contaCorrente = MockContaCorente.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<ContaCorrente>())).Returns(Task.CompletedTask);

            var service = new ContaCorrenteApiController(mock.Object);
            await service.AdicionarContaCorrente(contaCorrente);

            mock.Verify(y => y.Add(contaCorrente));
        }
        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var contaCorrente = MockContaCorente.MontaObjetoNomeVazio();
            var service = new ContaCorrenteApiController(mock.Object);
            var result = await service.AdicionarContaCorrente(contaCorrente);

            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(),((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_NumeroConta_Nao_Preenchido()
        {
            var contaCorrente = MockContaCorente.MontaObjetoComNumeroContaInvalido();
            var service = new ContaCorrenteApiController(mock.Object);
            var result = await service.AdicionarContaCorrente(contaCorrente);

            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }
        [Fact]
        public async Task Editar_Sucesso()
        {
            var contaCorrente = MockContaCorente.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<ContaCorrente>())).Returns(Task.CompletedTask);

            var service = new ContaCorrenteApiController(mock.Object);
            await service.EditarContaCorrente(contaCorrente);

            mock.Verify(y => y.Update(contaCorrente));

        }
        [Fact]
        public async Task Excluir_Sucesso()
        {
            var contaCorrente = MockContaCorente.MontaObjetoUnico();
            mock.Setup(y => y.Delete(It.IsAny<ContaCorrente>())).Returns(Task.CompletedTask);

            var service = new ContaCorrenteApiController(mock.Object);
            await service.ExcluirContaCorrente(contaCorrente);

            mock.Verify(y => y.Delete(contaCorrente));
        }
        [Fact]
        public async Task RetornarPorId()
        {
            mock.Setup(y => y.GetEntityById(MockContaCorente.MontaObjetoUnico().Id)).ReturnsAsync(MockContaCorente.MontaObjetoUnico());
            ContaCorrenteApiController ret = new ContaCorrenteApiController(mock.Object);
            var result = await ret.RetornarContaCorrentePorId(1);

            Assert.Equal("Teste Conta Corrente", ((Data.Entidades.ContaCorrente)result.Value).Nome);
        }
        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(y => y.List()).ReturnsAsync(MockContaCorente.MontaListaItems());

            var service = new ContaCorrenteApiController(mock.Object);
            var result = await service.ListarContaCorrente();
            var viewResult = Assert.IsType<List<ContaCorrente>>(result.Value);
        }
    }
}
