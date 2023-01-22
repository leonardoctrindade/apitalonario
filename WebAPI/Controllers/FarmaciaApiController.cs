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
    public class FarmaciaApiController : Controller
    {
        private readonly IFarmacia IFarmacia;

        public FarmaciaApiController(IFarmacia IFarmacia)
        {
            this.IFarmacia = IFarmacia;
        }

        [HttpGet("/api/ListaFarmacia")]
        public async Task<JsonResult> ListaFarmacia()
        {
            try
            {
                return Json(await this.IFarmacia.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as farmácias " + ex.Message }) { StatusCode = 400 };
            }
        }

      
    }
}
