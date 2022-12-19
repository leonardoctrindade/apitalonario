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
    public class AliquotaEstadoApiController: Controller
    {
        private readonly IAliquotaEstado IAliquotaEstado;

        public AliquotaEstadoApiController(IAliquotaEstado IAliquotaEstado)
        {
            this.IAliquotaEstado = IAliquotaEstado;
        }

        [HttpGet("/api/ListaAliquotaEstado")]
        public async Task<JsonResult> ListaAliquotaEstado()
        {
            return Json(await this.IAliquotaEstado.List());
        }

        [HttpPost("/api/AdicionarAliquotaEstado")]
        public async Task<JsonResult> AdicionarAliquotaEstado([FromBody] AliquotaEstado AliquotaEstado)
        {
            Json(await Task.FromResult(this.IAliquotaEstado.Add(AliquotaEstado)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaAliquotaEstadoPorId/{id}")]
        public async Task<JsonResult> RetornaAliquotaEstadoPorId(int id)
        {
            return Json(await this.IAliquotaEstado.GetEntityById(id));
        }

        [HttpPost("/api/EditarAliquotaEstado")]
        public async Task<JsonResult> EditarAliquotaEstado([FromBody] AliquotaEstado AliquotaEstado)
        {
            Json(await Task.FromResult(this.IAliquotaEstado.Update(AliquotaEstado)));

            return Json(Ok());
        }

        [HttpPost("/api/ExcluirAliquotaEstado")]
        public async Task ExcluirAliquotaEstado([FromBody] AliquotaEstado AliquotaEstado)
        {
            await Task.FromResult(this.IAliquotaEstado.Delete(AliquotaEstado));
        }
    }
}
