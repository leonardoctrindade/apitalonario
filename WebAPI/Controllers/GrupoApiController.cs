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
            return Json(await this.IGrupo.List());
        }

        [HttpPost("/api/AdicionarGrupo")]
        public async Task<JsonResult> AdicionarGrupo([FromBody] Grupo Grupo)
        {
            if (String.IsNullOrEmpty(Grupo.Descricao))
                return Json(BadRequest(ModelState));
            if (Grupo.Comissao <= 0 || Grupo.PercentualDesconto <= 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IGrupo.Add(Grupo)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaGrupoPorId/{id}")]
        public async Task<JsonResult> RetornaGrupoPorId(int id)
        {
            return Json(await this.IGrupo.GetEntityById(id));
        }

        [HttpPost("/api/EditarGrupo")]
        public async Task<JsonResult> EditarGrupo([FromBody] Grupo Grupo)
        {
            if (String.IsNullOrEmpty(Grupo.Descricao))
                return Json(BadRequest(ModelState));
            if (Grupo.Comissao <= 0 || Grupo.PercentualDesconto <= 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IGrupo.Update(Grupo)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirGrupo")]
        public async Task ExcluirGrupo([FromBody] Grupo Grupo)
        {
            await Task.FromResult(this.IGrupo.Delete(Grupo));
        }
    }
}
