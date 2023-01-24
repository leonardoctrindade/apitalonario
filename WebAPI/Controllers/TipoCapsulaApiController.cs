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
    public class TipoCapsulaApiController : Controller
    {
        private readonly ITipoCapsula ITipoCapsula;

        public TipoCapsulaApiController(ITipoCapsula ITipoCapsula)
        {
            this.ITipoCapsula = ITipoCapsula;
        }

        [HttpGet("/api/ListaPaginacaoTipoCapsula/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var tipoCapsulas = await this.ITipoCapsula.List();

                var total = Convert.ToDouble(tipoCapsulas.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.ITipoCapsula.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : tipoCapsulas);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os tipos de capsulas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaTipoCapsula")]
        public async Task<JsonResult> ListaTipoCapsula()
        {
            try
            {
                return Json(await this.ITipoCapsula.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os tipos de capsula " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarTipoCapsula")]
        public async Task<IActionResult> AdicionarTipoCapsula([FromBody] TipoCapsula TipoCapsula)
        {
            try
            {
                if (String.IsNullOrEmpty(TipoCapsula.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.ITipoCapsula.Add(TipoCapsula)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o tipo de capsula " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaTipoCapsulaPorId/{id}")]
        public async Task<JsonResult> RetornaTipoCapsulaPorId(int id)
        {
            try
            {
                return Json(await this.ITipoCapsula.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o tipo de capsula " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarTipoCapsula")]
        public async Task<IActionResult> EditarTipoCapsula([FromBody] TipoCapsula TipoCapsula)
        {
            try
            {
                if (String.IsNullOrEmpty(TipoCapsula.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.ITipoCapsula.Update(TipoCapsula)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o tipo de capsula " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirTipoCapsula")]
        public async Task<JsonResult> ExcluirTipoCapsula([FromBody] TipoCapsula TipoCapsula)
        {
            try
            {
                Json(await Task.FromResult(this.ITipoCapsula.Delete(TipoCapsula)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o tipo de capsula " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
