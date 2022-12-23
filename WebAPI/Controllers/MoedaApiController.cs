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
    public class MoedaApiController : Controller
    {
        private readonly IMoeda IMoeda;

        public MoedaApiController(IMoeda imoeda)
        {
            IMoeda = imoeda;
        }

        [HttpGet("/api/ListaMoeda")]
        public async Task<JsonResult> ListaMoeda()
        {
            try
            {
                return Json(await this.IMoeda.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as moedas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarMoeda")]
        public async Task<JsonResult> AdicionarMoeda([FromBody] Moeda moeda)
        {
            try
            {
                if (string.IsNullOrEmpty(moeda.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IMoeda.Add(moeda)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a moeda " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornarMoedaProId/{id}")]
        public async Task<JsonResult> RetornarMoedaProId(int id)
        {
            try
            {
                if (id == 0)
                    return Json(BadRequest(ModelState));

                return Json(await this.IMoeda.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a moeda " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarMoeda")]
        public async Task<JsonResult> EditarMoeda([FromBody] Moeda moeda)
        {
            try
            {
                if (string.IsNullOrEmpty(moeda.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IMoeda.Update(moeda)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a moeda " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirMoeda")]
        public async Task<JsonResult> ExcluirMoeda([FromBody] Moeda moeda)
        {
            try
            {
                return Json(await Task.FromResult(this.IMoeda.Delete(moeda)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a moeda " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
