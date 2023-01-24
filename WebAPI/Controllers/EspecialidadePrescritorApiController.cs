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
    public class EspecialidadePrescritorApiController : Controller
    {
        private readonly IEspecialidadePrescritor IEspecialidadePrescritor;
        
        public EspecialidadePrescritorApiController(IEspecialidadePrescritor especialidadePrescritor)
        {
            this.IEspecialidadePrescritor = especialidadePrescritor;
        }

        [HttpGet("/api/ListaPaginacaoEspecialidadePrescritor/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var especialidadesPrescritor = await this.IEspecialidadePrescritor.List();

                var total = Convert.ToDouble(especialidadesPrescritor.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IEspecialidadePrescritor.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : especialidadesPrescritor);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as especialidades do prescritor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaEspecialidadePrescritor")]
        public async Task<JsonResult> ListaEspecialidadePrescritor()
        {
            try
            {
                return Json(await this.IEspecialidadePrescritor.List());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as especialidades do prescritor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarEspecialidadePrescritor")]
        public async Task<IActionResult> AdicionarEspecialidadePrescritor([FromBody] EspecialidadePrescritor especialidadePrescritor)
        {
            try
            {
                if (especialidadePrescritor.EspecialidadeId == 0)
                    return BadRequest("Campo de especialidade é obrigatório");
                if (especialidadePrescritor.PrescritorId == 0)
                    return BadRequest("Campo de prescritor é obrigatório");

                Json(await Task.FromResult(this.IEspecialidadePrescritor.Add(especialidadePrescritor)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a especialidade do prescritor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornarEspecialidadePrescritorPorId/{id}")]
        public async Task<JsonResult> RetornarEspecialidadePrescritorPorId(int id)
        {
            try
            {
                return Json(await this.IEspecialidadePrescritor.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a especialidade do prescritor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirEspecialidadePrescritor")]
        public async Task<JsonResult> ExcluirEspecialidadePrescritor([FromBody] EspecialidadePrescritor especialidadePrescritor)
        {
            try
            {
                Json(await Task.FromResult(this.IEspecialidadePrescritor.Delete(especialidadePrescritor)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a especialidade do prescritor " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
