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
    public class AcompanhamentoPessoalApiController : Controller
    {
        private readonly IAcompanhamentoPessoal IAcompanhamentoPessoal;

        public AcompanhamentoPessoalApiController(IAcompanhamentoPessoal IAcompanhamentoPessoal)
        {
            this.IAcompanhamentoPessoal = IAcompanhamentoPessoal;
        }

        [HttpGet("/api/ListaPaginacaoAcompanhamentoPessoal/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var acompanhamentosPessoal = await this.IAcompanhamentoPessoal.List();

                var total = Convert.ToDouble(acompanhamentosPessoal.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IAcompanhamentoPessoal.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : acompanhamentosPessoal);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as administradoras de cartão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaAcompanhamentoPessoal")]
        public async Task<JsonResult> ListaAcompanhamentoPessoal()
        {
            try
            {
                return Json(await this.IAcompanhamentoPessoal.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os acompanhamentos pessoal " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarAcompanhamentoPessoal")]
        public async Task<IActionResult> AdicionarAcompanhamentoPessoal([FromBody] AcompanhamentoPessoal AcompanhamentoPessoal)
        {
            try
            {
                if (!AcompanhamentoPessoal.Data.HasValue)
                    return BadRequest("Campo de data é obrigatório");
                if (AcompanhamentoPessoal.ClienteId <= 0)
                    return BadRequest("Campo de clienteId é obrigatório");

                Json(await Task.FromResult(this.IAcompanhamentoPessoal.Add(AcompanhamentoPessoal)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o AcompanhamentoPessoal" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaAcompanhamentoPessoalPorId/{id}")]
        public async Task<JsonResult> RetornaAcompanhamentoPessoalPorId(int id)
        {
            try
            {
                return Json(await this.IAcompanhamentoPessoal.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o AcompanhamentoPessoal " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarAcompanhamentoPessoal")]
        public async Task<IActionResult> EditarAcompanhamentoPessoal([FromBody] AcompanhamentoPessoal AcompanhamentoPessoal)
        {
            try
            {
                if (!AcompanhamentoPessoal.Data.HasValue)
                    return BadRequest("Campo de data é obrigatório");
                if (AcompanhamentoPessoal.ClienteId <= 0)
                    return BadRequest("Campo de clienteId é obrigatório");

                Json(await Task.FromResult(this.IAcompanhamentoPessoal.Update(AcompanhamentoPessoal)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o AcompanhamentoPessoal " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirAcompanhamentoPessoal")]
        public async Task<JsonResult> ExcluirAcompanhamentoPessoal([FromBody] AcompanhamentoPessoal AcompanhamentoPessoal)
        {
            try
            {
                Json(await Task.FromResult(this.IAcompanhamentoPessoal.Delete(AcompanhamentoPessoal)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o AcompanhamentoPessoal " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
