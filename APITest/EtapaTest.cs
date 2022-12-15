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
    public class EtapaTest
    {
        public Mock<IEtapa> mock = new Mock<IEtapa>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var etapa = MockEtapa.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Etapa>())).Returns(Task.CompletedTask);

            var service = new EtapaApiController(mock.Object);
            await service.AdicionarEtapa(etapa);

            mock.Verify(y => y.Add(etapa));
        }
        [Fact]
        public async Task Insere_Descricao_Vazio()
        {
            var etapa = MockEtapa.MontaObjetoDescricoVazio();
            var service = new EtapaApiController(mock.Object);
            var result = await service.AdicionarEtapa(etapa);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }
        [Fact]
        public async Task Insere_Sequencia_Zero()
        {
            var etapa = MockEtapa.MontaObjetoSequenciaZero();
            var service = new EtapaApiController(mock.Object);
            var result = await service.AdicionarEtapa(etapa);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }
        [Fact]
        public async Task Insere_Tipo_Vazio()
        {
            var etapa = MockEtapa.MontaObjetoTipoVazio();
            var service = new EtapaApiController(mock.Object);
            var result = await service.AdicionarEtapa(etapa);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }
        [Fact]
        public async Task Editar_Sucesso()
        {
            var etapa = MockEtapa.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Etapa>())).Returns(Task.CompletedTask);

            var service = new EtapaApiController(mock.Object);
            await service.EditarEtapa(etapa);

            mock.Verify(y => y.Update(etapa));
        }
        [Fact]
        public async Task Excluir_Sucesso()
        {
            var etapa = MockEtapa.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Etapa>())).Returns(Task.CompletedTask);

            var service = new EtapaApiController(mock.Object);
            await service.ExcluirEtapa(etapa);

            mock.Verify(y => y.Delete(etapa));
        }
        [Fact]
        public async Task RetornarPorId()
        {
            mock.Setup(y => y.GetEntityById(MockEtapa.MontaObjetoUnico().Id)).ReturnsAsync(MockEtapa.MontaObjetoUnico);
            
            var service = new EtapaApiController(mock.Object);
            var result = await service.RetornarEtapaPorId(1);

            Assert.Equal("Teste Mock", ((Data.Entidades.Etapa)result.Value).Descricao);
        }
        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(y => y.List()).ReturnsAsync(MockEtapa.MontaListaItens());

            var service = new EtapaApiController(mock.Object);

            var result = await service.ListaEtapa();

            var viewResult = Assert.IsType<List<Etapa>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
