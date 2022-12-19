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
    public class ConvenioApiController: Controller
    {
        public readonly IConvenio IConvenio;

        public ConvenioApiController(IConvenio IConvenio)
        {
            this.IConvenio = IConvenio;
        }

        [HttpGet("/api/ListaConvenio")]
        public async Task<JsonResult> ListaConvenio()
        {
            return Json(await this.IConvenio.List());
        }

        [HttpPost("/api/AdicionarConvenio")]
        public async Task<JsonResult> AdicionarConvenio([FromBody] Convenio Convenio)
        {
            if (String.IsNullOrEmpty(Convenio.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IConvenio.Add(Convenio)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaConvenioPorId/{id}")]
        public async Task<JsonResult> RetornaConvenioPorId(int id)
        {
            return Json(await this.IConvenio.GetEntityById(id));
        }

        [HttpPost("/api/EditarConvenio")]
        public async Task<JsonResult> EditarConvenio([FromBody] Convenio Convenio)
        {
            if (String.IsNullOrEmpty(Convenio.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IConvenio.Update(Convenio)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirConvenio")]
        public async Task ExcluirConvenio([FromBody] Convenio Convenio)
        {
            await Task.FromResult(this.IConvenio.Delete(Convenio));
        }
    }
}
