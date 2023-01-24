using Moq;
using Xunit;
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
    public class PbmTest
    {

        #region Property  
        public Mock<IPbm> mock = new Mock<IPbm>();
        #endregion

        [Fact]
        public async Task Insere_Sucesso()
        {

            var modelo = MockPbm.MontaObjetoUnico();

            mock.Setup(x => x.Add(It.IsAny<Pbm>())).Returns(Task.CompletedTask);

            var service = new PbmApiController(mock.Object);
            await service.AdicionarPbm(modelo);

            mock.Verify(x => x.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockPbm.MontaObjetoNomeVazio();
            var apiController = new PbmApiController(mock.Object);
            var result = await apiController.AdicionarPbm(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }


        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockPbm.MontaObjetoUnico();

            mock.Setup(x => x.Update(It.IsAny<Pbm>())).Returns(Task.CompletedTask);

            var service = new PbmApiController(mock.Object);
            await service.EditarPbm(modelo);

            mock.Verify(x => x.Update(modelo));
        }


        [Fact]
        public async Task Editar_Nome_Nao_Preenchido()
        {
            var modelo = MockPbm.MontaObjetoNomeVazio();
            var apiController = new PbmApiController(mock.Object);
            var result = await apiController.EditarPbm(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }


        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockPbm.MontaObjetoUnico();

            mock.Setup(x => x.Delete(It.IsAny<Pbm>())).Returns(Task.CompletedTask);

            var service = new PbmApiController(mock.Object);
            await service.ExcluirBpm(modelo);

            mock.Verify(x => x.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorID()
        {
            mock.Setup(p => p.GetEntityById(MockPbm.MontaObjetoUnico().Id)).ReturnsAsync(MockPbm.MontaObjetoUnico());
            PbmApiController ret = new PbmApiController(mock.Object);
            var result = await ret.RetornaPbmPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Pbm)result.Value).Nome);
        }




        [Fact]
        public async Task RetornaLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockPbm.MontaListaItems());
            var controller = new PbmApiController(mock.Object);
            var result = await controller.ListaPbm();
            var viewResult = Assert.IsType<List<Pbm>>(result.Value);

            Assert.Equal(3, viewResult.Count());
        }

    }
}
