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
    public class ClasseTest
    {
        public Mock<IClasse> mock = new Mock<IClasse>();
        [Fact]
        public async Task Insere_Sucesso()
        {
            var classe = MockClasse.MontaObjetoUnico();
            mock.Setup(y => y.Add(It.IsAny<Classe>())).Returns(Task.CompletedTask);
            var service = new ClasseApiController(mock.Object);
            await service.AdicionarClasse(classe);

            mock.Verify(y => y.Add(classe));
        }
        [Fact]
        public async Task Insere_Descricao_Vazio()
        {
            var classe = MockClasse.MontaObjetoDescricaoVazio();
            var service = new ClasseApiController(mock.Object);
            var result = await service.AdicionarClasse(classe);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }
        [Fact]
        public async Task Editar_Sucesso()
        {
            var classe = MockClasse.MontaObjetoUnico();
            mock.Setup(y => y.Update(It.IsAny<Classe>())).Returns(Task.CompletedTask);

            var service = new ClasseApiController(mock.Object);
            await service.EditarClasse(classe);

            mock.Verify(y => y.Update(classe));
        }
        [Fact]
        public async Task Excluir_Sucesso()
        {
            var classe = MockClasse.MontaObjetoUnico();
            mock.Setup(y => y.Delete(It.IsAny<Classe>())).Returns(Task.CompletedTask);

            var service = new ClasseApiController(mock.Object);
            await service.ExcluirClasse(classe);

            mock.Verify(y => y.Delete(classe));
        }
        [Fact]
        public async Task RetornarProId()
        {
            mock.Setup(y => y.GetEntityById(MockClasse.MontaObjetoUnico().Id)).ReturnsAsync(MockClasse.MontaObjetoUnico());
            var ret = new ClasseApiController(mock.Object);
            var result = await ret.RetornarClassePorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Classe)result.Value).Descricao);

        }
        [Fact]
        public async Task RetornarLista()
        {
            mock.Setup(rep => rep.List()).ReturnsAsync(MockClasse.MontaListaItens());

            var service = new ClasseApiController(mock.Object);
            var result = await service.ListaClasse();
            var viewResult = Assert.IsType<List<Classe>>(result.Value);

            Assert.Equal(3,viewResult.Count);
        }
    }
}
