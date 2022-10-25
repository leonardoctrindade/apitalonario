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
    public class RegimeTributarioTest
    {

        #region Property  
        public Mock<IDOM_RegimeTributario> mock = new Mock<IDOM_RegimeTributario>();
        #endregion

        [Fact]
        public async Task RetornaSimplesPorID()
        {
            mock.Setup(p => p.RetornaRegimeTributarioPorID(MockRegimeTributario.MontaObjetoUnicoSimplesNacional().Id)).ReturnsAsync(MockRegimeTributario.MontaObjetoUnicoSimplesNacional());
            DOM_RegimeTributarioApiController ret = new DOM_RegimeTributarioApiController(mock.Object);
            var result = await ret.RetornaRegimeTributarioPorID(1);
            Assert.Equal("Simples Nacional", ((Data.Entidades.DOM_RegimeTributario)result.Value).RegimeTributario);
        }

      


        [Fact]
        public async Task RetornaLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockRegimeTributario.MontaListaItems());
            var controller = new DOM_RegimeTributarioApiController(mock.Object);
            var result = await controller.ListaRegimeTributario();
            var viewResult = Assert.IsType<List<DOM_RegimeTributario>>(result.Value);
           
            Assert.Equal(3, viewResult.Count());
        }


    }
}
