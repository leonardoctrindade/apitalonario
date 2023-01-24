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
    public class EspecialidadeApiController : Controller
    {
        private readonly IEspecialidade IEspecialidade;

        public EspecialidadeApiController(IEspecialidade iEspecialidade)
        {
            IEspecialidade = iEspecialidade;
        }

        [HttpGet("/api/ListaPaginacaoEspecialidade/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var especialidades = await this.IEspecialidade.List();

                var total = Convert.ToDouble(especialidades.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IEspecialidade.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : especialidades);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as especialidades " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaEspecialidade")]
        public async Task<JsonResult> ListaEspecialidade()
        {
            try
            {
                return Json(await this.IEspecialidade.List());
            }
            catch (Exception)
            {
                return Json(BadRequest(ModelState));
            }
        }

        [HttpPost("/api/AdicionarEspecialidade")]
        public async Task<IActionResult> AdicionarEspecialidade([FromBody] Especialidade especialidade)
        {
            if (string.IsNullOrEmpty(especialidade.Descricao.Trim()))
                return BadRequest("Campo de descrição é obrigatório");

            try
            {
                Json(await Task.FromResult(this.IEspecialidade.Add(especialidade)));
                return Json(Ok());
            }
            catch (Exception)
            {
                return Json(BadRequest(ModelState));
            }
        }

        [HttpGet("/api/RetornarEspecialidadePorId/{id}")]
        public async Task<JsonResult> RetornarEspecialidadePorId(int id)
        {
            try
            {
                return Json(await this.IEspecialidade.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a especialidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarEspecialidade")]
        public async Task<IActionResult> EditarEspecialidade([FromBody] Especialidade especialidade)
        {
            if (string.IsNullOrEmpty(especialidade.Descricao.Trim()))
                return BadRequest("Campo de descrição é obrigatório");

            try
            {
                Json(await Task.FromResult(this.IEspecialidade.Update(especialidade)));
                return Json(Ok());
            }
            catch (Exception)
            {
                return Json(BadRequest(ModelState));
            }
        }

        [HttpPost("/api/ExcluirEspecialidade")]
        public async Task<JsonResult> ExcluirEspecialidade([FromBody] Especialidade especialidade)
        {
            try
            {
                Json(await Task.FromResult(this.IEspecialidade.Delete(especialidade)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a especialidade " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
