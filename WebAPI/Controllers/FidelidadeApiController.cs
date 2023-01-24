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
    public class FidelidadeApiController: Controller
    {
        private readonly IFidelidade IFidelidade;

        public FidelidadeApiController(IFidelidade IFidelidade)
        {
            this.IFidelidade = IFidelidade;
        }

        [HttpGet("/api/ListaPaginacaoFidelidade/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var fidelidades = await this.IFidelidade.List();

                var total = Convert.ToDouble(fidelidades.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IFidelidade.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : fidelidades);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as fidelidades " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaFidelidade")]
        public async Task<JsonResult> ListaFidelidade()
        {
            try
            {
                return Json(await this.IFidelidade.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as fidelidades " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarFidelidade")]
        public async Task<IActionResult> AdicionarFidelidade([FromBody] Fidelidade Fidelidade)
        {
            try
            {
                if (String.IsNullOrEmpty(Fidelidade.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.IFidelidade.Add(Fidelidade)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a fidelidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaFidelidadePorId/{id}")]
        public async Task<JsonResult> RetornaFidelidadePorId(int id)
        {
            try
            {
                return Json(await this.IFidelidade.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a fidelidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarFidelidade")]
        public async Task<IActionResult> EditarFidelidade([FromBody] Fidelidade Fidelidade)
        {
            try
            {
                if (String.IsNullOrEmpty(Fidelidade.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.IFidelidade.Update(Fidelidade)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a fidelidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirFidelidade")]
        public async Task<JsonResult> ExcluirFidelidade([FromBody] Fidelidade Fidelidade)
        {
            try
            {
                Json(await Task.FromResult(this.IFidelidade.Delete(Fidelidade)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a fidelidade " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
