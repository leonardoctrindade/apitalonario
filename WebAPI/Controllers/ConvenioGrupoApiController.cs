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
    public class ConvenioGrupoApiController: Controller
    {
        private readonly IConvenioGrupo IConvenioGrupo;

        public ConvenioGrupoApiController(IConvenioGrupo IConvenioGrupo)
        {
            this.IConvenioGrupo = IConvenioGrupo;
        }

        [HttpGet("/api/ListaConvenioGrupo")]
        public async Task<JsonResult> ListaConvenioGrupo()
        {
            return Json(await this.IConvenioGrupo.List());
        }

        [HttpPost("/api/AdicionarConvenioGrupo")]
        public async Task<JsonResult> AdicionarConvenioGrupo([FromBody] ConvenioGrupo ConvenioGrupo)
        {
            if (ConvenioGrupo.IdGrupo == 0 || ConvenioGrupo.IdConvenio == 0 || ConvenioGrupo.Desconto <= 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IConvenioGrupo.Add(ConvenioGrupo)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaConvenioGrupoPorId/{id}")]
        public async Task<JsonResult> RetornaConvenioGrupoPorId(int id)
        {
            return Json(await this.IConvenioGrupo.GetEntityById(id));
        }

        [HttpPost("/api/EditarConvenioGrupo")]
        public async Task<JsonResult> EditarConvenioGrupo([FromBody] ConvenioGrupo ConvenioGrupo)
        {
            if (ConvenioGrupo.IdGrupo == 0 || ConvenioGrupo.IdConvenio == 0 || ConvenioGrupo.Desconto <= 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IConvenioGrupo.Update(ConvenioGrupo)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirConvenioGrupo")]
        public async Task ExcluirConvenioGrupo([FromBody] ConvenioGrupo ConvenioGrupo)
        {
            await Task.FromResult(this.IConvenioGrupo.Delete(ConvenioGrupo));
        }
    }
}
