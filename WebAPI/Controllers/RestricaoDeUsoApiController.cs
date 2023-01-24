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
    public class RestricaoDeUsoApiController: Controller
    {
        private readonly IRestricaoDeUso IRestricaoDeUso;

        public RestricaoDeUsoApiController(IRestricaoDeUso IRestricaoDeUso)
        {
            this.IRestricaoDeUso = IRestricaoDeUso;
        }

        [HttpGet("/api/ListaPaginacaoRestricaoDeUso/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var restricoes = await this.IRestricaoDeUso.List();

                var total = Convert.ToDouble(restricoes.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IRestricaoDeUso.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : restricoes);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os restrições de uso " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaRestricaoDeUso")]
        public async Task<JsonResult> ListaRestricaoDeUso()
        {
            try
            {
                return Json(await this.IRestricaoDeUso.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as restricoes de uso" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarRestricaoDeUso")]
        public async Task<IActionResult> AdicionarRestricaoDeUso([FromBody] RestricaoDeUso RestricaoDeUso)
        {
            try
            {
                if (RestricaoDeUso.ProdutoId <= 0)
                    return BadRequest("Campo de produto é obrigatório");
                if (RestricaoDeUso.GrupoId <= 0)
                    return BadRequest("Campo de grupo é obrigatório");
                if (RestricaoDeUso.ClienteId <= 0)
                    return BadRequest("Campo de cliente é obrigatório");

                Json(await Task.FromResult(this.IRestricaoDeUso.Add(RestricaoDeUso)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar a restricao de uso " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaRestricaoDeUsoPorId/{id}")]
        public async Task<JsonResult> RetornaRestricaoDeUsoPorId(int id)
        {
            try
            {
                return Json(await this.IRestricaoDeUso.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a restricao de uso " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarRestricaoDeUso")]
        public async Task<IActionResult> EditarRestricaoDeUso([FromBody] RestricaoDeUso RestricaoDeUso)
        {
            try
            {
                if (RestricaoDeUso.ProdutoId <= 0)
                    return BadRequest("Campo de produto é obrigatório");
                if (RestricaoDeUso.GrupoId <= 0)
                    return BadRequest("Campo de grupo é obrigatório");
                if (RestricaoDeUso.ClienteId <= 0)
                    return BadRequest("Campo de cliente é obrigatório");

                Json(await Task.FromResult(this.IRestricaoDeUso.Update(RestricaoDeUso)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a restricao de uso " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirRestricaoDeUso")]
        public async Task<JsonResult> ExcluirRestricaoDeUso([FromBody] RestricaoDeUso RestricaoDeUso)
        {
            try
            {
                Json(await Task.FromResult(this.IRestricaoDeUso.Delete(RestricaoDeUso)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a restricao de uso " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
