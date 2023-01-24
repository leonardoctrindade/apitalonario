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
    public class RegiaoTest
    {
        public Mock<IRegiao> mock = new Mock<IRegiao>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockRegiao.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Regiao>())).Returns(Task.CompletedTask);

            var service = new RegiaoApiController(mock.Object);
            await service.AdicionarRegiao(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Descricao_Nao_Preenchido()
        {
            var modelo = MockRegiao.MontaObjetoDescricaoVazia();
            var apiController = new RegiaoApiController(mock.Object);
            var result = await apiController.AdicionarRegiao(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockRegiao.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Regiao>())).Returns(Task.CompletedTask);

            var service = new RegiaoApiController(mock.Object);
            await service.EditarRegiao(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockRegiao.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Regiao>())).Returns(Task.CompletedTask);

            var service = new RegiaoApiController(mock.Object);
            await service.ExcluirRegiao(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockRegiao.MontaObjetoUnico().Id)).ReturnsAsync(MockRegiao.MontaObjetoUnico());
            RegiaoApiController ret = new RegiaoApiController(mock.Object);
            var result = await ret.RetornaRegiaoPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Regiao)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockRegiao.MontaListaItems());
            var controller = new RegiaoApiController(mock.Object);
            var result = await controller.ListaRegiao();
            var viewResult = Assert.IsType<List<Regiao>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
