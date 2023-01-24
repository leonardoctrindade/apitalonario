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
    public class ConvenioGrupoTest
    {
        public Mock<IConvenioGrupo> mock = new Mock<IConvenioGrupo>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockConvenioGrupo.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<ConvenioGrupo>())).Returns(Task.CompletedTask);

            var service = new ConvenioGrupoApiController(mock.Object);
            await service.AdicionarConvenioGrupo(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_IdGrupo_Nao_Preenchido()
        {
            var modelo = MockConvenioGrupo.MontaObjetoIdGrupoInvalido();
            var apiController = new ConvenioGrupoApiController(mock.Object);
            var result = await apiController.AdicionarConvenioGrupo(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Desconto_Nao_Preenchido()
        {
            var modelo = MockConvenioGrupo.MontaObjetoDescontoInvalido();
            var apiController = new ConvenioGrupoApiController(mock.Object);
            var result = await apiController.AdicionarConvenioGrupo(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_IdConvenio_Nao_Preenchido()
        {
            var modelo = MockConvenioGrupo.MontaObjetoIdConvenioInvalido();
            var apiController = new ConvenioGrupoApiController(mock.Object);
            var result = await apiController.AdicionarConvenioGrupo(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockConvenioGrupo.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<ConvenioGrupo>())).Returns(Task.CompletedTask);

            var service = new ConvenioGrupoApiController(mock.Object);
            await service.EditarConvenioGrupo(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockConvenioGrupo.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<ConvenioGrupo>())).Returns(Task.CompletedTask);

            var service = new ConvenioGrupoApiController(mock.Object);
            await service.ExcluirConvenioGrupo(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockConvenioGrupo.MontaObjetoUnico().Id)).ReturnsAsync(MockConvenioGrupo.MontaObjetoUnico());
            ConvenioGrupoApiController ret = new ConvenioGrupoApiController(mock.Object);
            var result = await ret.RetornaConvenioGrupoPorId(1);
            Assert.Equal(24 , ((Data.Entidades.ConvenioGrupo)result.Value).Desconto);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockConvenioGrupo.MontaListaItems());
            var controller = new ConvenioGrupoApiController(mock.Object);
            var result = await controller.ListaConvenioGrupo();
            var viewResult = Assert.IsType<List<ConvenioGrupo>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
