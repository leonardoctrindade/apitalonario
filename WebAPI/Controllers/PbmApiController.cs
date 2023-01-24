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
    public class PbmApiController : Controller
    {
        private readonly IPbm IPbm;
        public PbmApiController(IPbm iPbm)
        {
            this.IPbm = iPbm;
        }

        [HttpGet("/api/ListaPaginacaoPbm/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var pbms = await this.IPbm.List();

                var total = Convert.ToDouble(pbms.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IPbm.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : pbms);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os pbms " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaPbm")]
        public async Task<JsonResult> ListaPbm()
        {
            try
            {
                return Json(await this.IPbm.List());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os pbms " + ex.Message }) { StatusCode = 400 };
            }
        }


        [HttpPost("/api/AdicionarPbm")]
        public async Task<IActionResult> AdicionarPbm([FromBody] Pbm Pbm)
        {
            try
            {
                if (String.IsNullOrEmpty(Pbm.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

                Json(await Task.FromResult(this.IPbm.Add(Pbm)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o pbm " + ex.Message }) { StatusCode = 400 };
            }
        }


        [HttpGet("/api/RetornaPbmPorId/{id}")]
        public async Task<JsonResult> RetornaPbmPorId(int id)
        {
            try
            {
                return Json(await this.IPbm.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o pbm " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarPbm")]
        public async Task<IActionResult> EditarPbm([FromBody] Pbm Pbm)
        {
            try
            {
                if (String.IsNullOrEmpty(Pbm.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

                Json(await Task.FromResult(this.IPbm.Update(Pbm)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o pbm " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirPbm")]
        public async Task<JsonResult> ExcluirBpm([FromBody] Pbm Pbm)
        {
            try
            {
                Json(await Task.FromResult(this.IPbm.Delete(Pbm)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o pbm " + ex.Message }) { StatusCode = 400 };
            }
        }

    }
}