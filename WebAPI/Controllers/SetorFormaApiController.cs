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
    public class SetorFormaApiController : Controller
    {
        private readonly ISetorForma ISetorForma;

        public SetorFormaApiController(ISetorForma ISetorForma)
        {
            this.ISetorForma = ISetorForma;
        }

        [HttpGet("/api/ListaPaginacaoSetorForma/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var setores = await this.ISetorForma.List();

                var total = Convert.ToDouble(setores.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.ISetorForma.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : setores);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os setores forma " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaSetorForma")]
        public async Task<JsonResult> ListaSetorForma()
        {
            try
            {
                return Json(await this.ISetorForma.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os setoresForma " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarSetorForma")]
        public async Task<IActionResult> AdicionarSetorForma([FromBody] SetorForma SetorForma)
        {
            try
            {
                if (SetorForma.SetorId <= 0)
                    return BadRequest("Campo de setor é obrigatório");

                Json(await Task.FromResult(this.ISetorForma.Add(SetorForma)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o setor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaSetorFormaPorId/{id}")]
        public async Task<JsonResult> RetornaSetorFormaPorId(int id)
        {
            try
            {
                return Json(await this.ISetorForma.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o setor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarSetorForma")]
        public async Task<IActionResult> EditarSetorForma([FromBody] SetorForma SetorForma)
        {
            try
            {
                if (SetorForma.SetorId <= 0)
                    return BadRequest("Campo de setor é obrigatório");

                Json(await Task.FromResult(this.ISetorForma.Update(SetorForma)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o setor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirSetorForma")]
        public async Task<JsonResult> ExcluirSetorForma([FromBody] SetorForma SetorForma)
        {
            try
            {
                Json(await Task.FromResult(this.ISetorForma.Delete(SetorForma)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o setor " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
