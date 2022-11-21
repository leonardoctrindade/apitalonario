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
    public class PrincipioAtivoTest
    {
        public Mock<IPrincipioAtivo> mock = new Mock<IPrincipioAtivo>();
        [Fact]
        public async Task Insere_Sucesso()
        {
            var principioAtivo = MockPrincipioAtivo.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<PrincipioAtivo>())).Returns(Task.CompletedTask);
            var service = new PrincipioAtivoApiController(mock.Object);
            await service.AdicionarPrincipioAtivo(principioAtivo);

            mock.Verify(y => y.Add(principioAtivo));
        }
        [Fact]
        public async Task Insere_Descricao_Nao_Preenchido()
        {
            var principioAtivo = MockPrincipioAtivo.MontaObjetoDescricaoVazio();
            var service = new PrincipioAtivoApiController(mock.Object);
            var result = await service.AdicionarPrincipioAtivo(principioAtivo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }
        [Fact]
        public async Task Editar_Sucesso()
        {
            var principioAtivo = MockPrincipioAtivo.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<PrincipioAtivo>())).Returns(Task.CompletedTask);

            var service = new PrincipioAtivoApiController(mock.Object);
            await service.EditarPrincipioAtivo(principioAtivo);

            mock.Verify(y => y.Update(principioAtivo));
        }
        [Fact]
        public async Task Excluir_Sucesso()
        {
            var principioAtivo = MockPrincipioAtivo.MontaObjetoUnico();
            mock.Setup(y => y.Delete(It.IsAny<PrincipioAtivo>())).Returns(Task.CompletedTask);
            var service = new PrincipioAtivoApiController(mock.Object);
            await service.ExcluirPrincipioAtivo(principioAtivo);

            mock.Verify(y => y.Delete(principioAtivo));
        }
        [Fact]
        public async Task RetornarPorId()
        {
            mock.Setup(y =>y.GetEntityById(MockPrincipioAtivo.MontaObjetoUnico().Id)).ReturnsAsync(MockPrincipioAtivo.MontaObjetoUnico());
            var ret = new PrincipioAtivoApiController(mock.Object);
            var result = await ret.RetornarPrincipioAtivoProId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.PrincipioAtivo)result.Value).Descricao);
        }
        [Fact]
        public async Task RetornarLista()
        {
            mock.Setup(rep => rep.List()).ReturnsAsync(MockPrincipioAtivo.MontaListaItens());
            var service = new PrincipioAtivoApiController(mock.Object);
            var result = await service.ListaPrincipioAtivo();
            var viewResult = Assert.IsType<List<PrincipioAtivo>>(result.Value);
            Assert.Equal(3, viewResult.Count);
        }
    }
}
