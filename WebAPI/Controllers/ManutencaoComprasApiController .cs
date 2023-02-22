using System;
using System.Linq;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    public class ManutencaoComprasApiController : Controller
    {
        private readonly IManutencaoCompras IManutencaoCompras;

        public ManutencaoComprasApiController(IManutencaoCompras IManutencaoCompras)
        {
            this.IManutencaoCompras = IManutencaoCompras;
        }

        #region Manutenção de Compras

        [HttpPost("/api/ManutencaoCompras/MontaFiltro")]
        public async Task<JsonResult> MontaFiltro([FromBody] FiltroComprasManutencao filtroComprasManutencao)
        {
            try
            {
                return Json(await Task.FromResult(this.IManutencaoCompras.MontaFiltro(filtroComprasManutencao)));

            }
            catch (Exception ex)
            {
               return new JsonResult(new { message = "Error  " + ex.Message }) { StatusCode = 400 };
            }
        }


      

        #endregion
    }
}
