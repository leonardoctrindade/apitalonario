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
    public class DiferimentoTest
    {
        public Mock<IDiferimento> mock = new Mock<IDiferimento>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockDiferimento.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Diferimento>())).Returns(Task.CompletedTask);

            var service = new DiferimentoApiController(mock.Object);
            await service.AdicionarDiferimento(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Cst_Nao_Preenchido()
        {
            var modelo = MockDiferimento.MontaObjetoCstNaoPreenchido();
            var apiController = new DiferimentoApiController(mock.Object);
            var result = await apiController.AdicionarDiferimento(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_SiglaEstado_Nao_Preenchido()
        {
            var modelo = MockDiferimento.MontaObjetoSiglaEstadoNaoPreenchido();
            var apiController = new DiferimentoApiController(mock.Object);
            var result = await apiController.AdicionarDiferimento(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_AliquotaDiferimento_Invalido()
        {
            var modelo = MockDiferimento.MontaObjetoAliquotaDiferimentoInvalido();
            var apiController = new DiferimentoApiController(mock.Object);
            var result = await apiController.AdicionarDiferimento(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockDiferimento.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Diferimento>())).Returns(Task.CompletedTask);

            var service = new DiferimentoApiController(mock.Object);
            await service.EditarDiferimento(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockDiferimento.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Diferimento>())).Returns(Task.CompletedTask);

            var service = new DiferimentoApiController(mock.Object);
            await service.ExcluirDiferimento(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockDiferimento.MontaObjetoUnico().Id)).ReturnsAsync(MockDiferimento.MontaObjetoUnico());
            DiferimentoApiController ret = new DiferimentoApiController(mock.Object);
            var result = await ret.RetornaDiferimentoPorId(1);
            Assert.Equal("SC", ((Data.Entidades.Diferimento)result.Value).SiglaEstado);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockDiferimento.MontaListaItems());
            var controller = new DiferimentoApiController(mock.Object);
            var result = await controller.ListaDiferimento();
            var viewResult = Assert.IsType<List<Diferimento>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
