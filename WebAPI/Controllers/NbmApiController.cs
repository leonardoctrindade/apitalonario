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
    public class NbmApiController : Controller
    {
        private readonly INbm INbm;

        public NbmApiController(INbm iNbm)
        {
            this.INbm = iNbm;
        }

        [HttpGet("/api/ListaPaginacaoNbm/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var nbms = await this.INbm.List();

                var total = Convert.ToDouble(nbms.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.INbm.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : nbms);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os nbms " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaNbm")]
        public async Task<JsonResult> ListaNbm()
        {
            try
            {
                return Json(await this.INbm.List());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os nbm " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarNbm")]
        public async Task<IActionResult> AdicionarNbm([FromBody] Nbm nbm)
        {
            try
            {
                if (string.IsNullOrEmpty(nbm.CodigoNbm.Trim()))
                    return Json(BadRequest(ModelState));
                if (string.IsNullOrEmpty(nbm.Descricao.Trim()))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.INbm.Add(nbm)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o nbm " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaNbmPorId/{id}")]
        public async Task<JsonResult> RetornarNbmPorId(int id)
        {
            try
            {
                if (id == 0)
                    return Json(BadRequest(ModelState));

                return Json(await this.INbm.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar os nbm " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarNbm")]
        public async Task<IActionResult> EditarNbm([FromBody] Nbm nbm)
        {
            try
            {
                if (string.IsNullOrEmpty(nbm.CodigoNbm.Trim()))
                    return Json(BadRequest(ModelState));
                if (string.IsNullOrEmpty(nbm.Descricao.Trim()))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.INbm.Update(nbm)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar os nbm " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirNbm")]
        public async Task<JsonResult> ExcluirNbm([FromBody] Nbm nbm)
        {
            try
            {
                Json(await Task.FromResult(this.INbm.Delete(nbm)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir os nbm " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
