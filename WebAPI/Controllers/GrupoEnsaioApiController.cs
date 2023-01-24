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
    public class GrupoEnsaioApiController: Controller
    {
        private readonly IGrupoEnsaio IGrupoEnsaio;

        public GrupoEnsaioApiController(IGrupoEnsaio IGrupoEnsaio)
        {
            this.IGrupoEnsaio = IGrupoEnsaio;
        }

        [HttpGet("/api/ListaPaginacaoGrupoEnsaio/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var gruposEnsaios = await this.IGrupoEnsaio.List();

                var total = Convert.ToDouble(gruposEnsaios.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IGrupoEnsaio.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : gruposEnsaios);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os grupos de ensaios " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaGrupoEnsaio")]
        public async Task<JsonResult> ListaGrupoEnsaio()
        {
            try
            {
                return Json(await this.IGrupoEnsaio.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os Grupos de Ensaio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarGrupoEnsaio")]
        public async Task<IActionResult> AdicionarGrupoEnsaio([FromBody] GrupoEnsaio GrupoEnsaio)
        {
            try
            {
                if (GrupoEnsaio.EnsaioId <= 0)
                    return BadRequest("Campo de ensaio é obrigatório");
                if (GrupoEnsaio.GrupoId <= 0)
                    return BadRequest("Campo de grupo é obrigatório");

                Json(await Task.FromResult(this.IGrupoEnsaio.Add(GrupoEnsaio)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o Grupo de Ensaio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaGrupoEnsaioPorId/{id}")]
        public async Task<JsonResult> RetornaGrupoEnsaioPorId(int id)
        {
            try
            {
                return Json(await this.IGrupoEnsaio.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o Grupo de Ensaio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarGrupoEnsaio")]
        public async Task<IActionResult> EditarGrupoEnsaio([FromBody] GrupoEnsaio GrupoEnsaio)
        {
            try
            {
                if (GrupoEnsaio.EnsaioId <= 0)
                    return BadRequest("Campo de ensaio é obrigatório");
                if (GrupoEnsaio.GrupoId <= 0)
                    return BadRequest("Campo de grupo é obrigatório");

                Json(await Task.FromResult(this.IGrupoEnsaio.Update(GrupoEnsaio)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o Grupo de Ensaio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirGrupoEnsaio")]
        public async Task<JsonResult> ExcluirGrupoEnsaio([FromBody] GrupoEnsaio GrupoEnsaio)
        {
            try
            {
                Json(await Task.FromResult(this.IGrupoEnsaio.Delete(GrupoEnsaio)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o Grupo de Ensaio " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
