using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class GrupoApiController: Controller
    {
        private readonly IGrupo IGrupo;

        public GrupoApiController(IGrupo IGrupo)
        {
            this.IGrupo = IGrupo;
        }

        [HttpGet("/api/ListaGrupo")]
        public async Task<JsonResult> ListaGrupo()
        {
            try
            {
                return Json(await this.IGrupo.List());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os grupos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarGrupo")]
        public async Task<JsonResult> AdicionarGrupo([FromBody] Grupo Grupo)
        {
            try
            {
                if (String.IsNullOrEmpty(Grupo.Descricao))
                    return Json(BadRequest(ModelState));
                if (Grupo.Comissao <= 0 || Grupo.PercentualDesconto <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IGrupo.Add(Grupo)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o grupo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaGrupoPorId/{id}")]
        public async Task<JsonResult> RetornaGrupoPorId(int id)
        {
            try
            {
                return Json(await this.IGrupo.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o grupo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarGrupo")]
        public async Task<JsonResult> EditarGrupo([FromBody] Grupo Grupo)
        {
            try
            {
                if (String.IsNullOrEmpty(Grupo.Descricao))
                    return Json(BadRequest(ModelState));
                if (Grupo.Comissao <= 0 || Grupo.PercentualDesconto <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IGrupo.Update(Grupo)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o grupo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirGrupo")]
        public async Task<JsonResult> ExcluirGrupo([FromBody] Grupo Grupo)
        {
            try
            {
                Json(await Task.FromResult(this.IGrupo.Delete(Grupo)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o grupo " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
