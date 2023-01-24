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
    public class SetorApiController : Controller
    {
        private readonly ISetor ISetor;

        public SetorApiController(ISetor ISetor)
        {
            this.ISetor = ISetor;
        }

        [HttpGet("/api/ListaPaginacaoSetor/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var setores = await this.ISetor.List();

                var total = Convert.ToDouble(setores.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.ISetor.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : setores);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os setores " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaSetor")]
        public async Task<JsonResult> ListaSetor()
        {
            try
            {
                return Json(await this.ISetor.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os setores " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarSetor")]
        public async Task<JsonResult> AdicionarSetor([FromBody] Setor Setor)
        {
            try
            {
                Json(await Task.FromResult(this.ISetor.Add(Setor)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o setor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaSetorPorId/{id}")]
        public async Task<JsonResult> RetornaSetorPorId(int id)
        {
            try
            {
                return Json(await this.ISetor.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o setor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarSetor")]
        public async Task<JsonResult> EditarSetor([FromBody] Setor Setor)
        {
            try
            {
                Json(await Task.FromResult(this.ISetor.Update(Setor)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o setor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirSetor")]
        public async Task<JsonResult> ExcluirSetor([FromBody] Setor Setor)
        {
            try
            {
                Json(await Task.FromResult(this.ISetor.Delete(Setor)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o setor " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
