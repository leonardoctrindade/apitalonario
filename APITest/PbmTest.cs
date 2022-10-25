using Moq;
using System;
using Xunit;
using WebAPI;
using Data.Interfaces;
using WebAPI.Controllers;
using System.Threading.Tasks;
using Data.Entidades;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using APITest.Mocks;

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
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
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
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
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

    }
}
