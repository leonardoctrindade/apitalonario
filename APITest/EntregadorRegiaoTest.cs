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
    public class EntregadorRegiaoTest
    {
        public Mock<IEntregadorRegiao> mock = new Mock<IEntregadorRegiao>();


        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockEntregadorRegiao.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<EntregadorRegiao>())).Returns(Task.CompletedTask);

            var service = new EntregadorRegiaoApiController(mock.Object);
            await service.AdicionarEntregadorRegiao(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_IdEntregador_Nao_Preenchido()
        {
            var modelo = MockEntregadorRegiao.MontaObjetoIdEntregadorInvalido();
            var apiController = new EntregadorRegiaoApiController(mock.Object);
            var result = await apiController.AdicionarEntregadorRegiao(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_IdRegiao_Nao_Preenchido()
        {
            var modelo = MockEntregadorRegiao.MontaObjetoIdRegiaoInvalido();
            var apiController = new EntregadorRegiaoApiController(mock.Object);
            var result = await apiController.AdicionarEntregadorRegiao(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockEntregadorRegiao.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<EntregadorRegiao>())).Returns(Task.CompletedTask);

            var service = new EntregadorRegiaoApiController(mock.Object);
            await service.EditarEntregadorRegiao(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockEntregadorRegiao.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<EntregadorRegiao>())).Returns(Task.CompletedTask);

            var service = new EntregadorRegiaoApiController(mock.Object);
            await service.ExcluirEntregadorRegiao(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockEntregadorRegiao.MontaObjetoUnico().Id)).ReturnsAsync(MockEntregadorRegiao.MontaObjetoUnico());
            EntregadorRegiaoApiController ret = new EntregadorRegiaoApiController(mock.Object);
            var result = await ret.RetornaEntregadorRegiaoPorId(1);
            //Assert.Equal(1, ((Data.Entidades.EntregadorRegiao)result.Value).EntregadorId);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockEntregadorRegiao.MontaListaItems());
            var controller = new EntregadorRegiaoApiController(mock.Object);
            var result = await controller.ListaEntregadorRegiao();
            var viewResult = Assert.IsType<List<EntregadorRegiao>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
