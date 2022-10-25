﻿using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize]
    public class PbmApiController : Controller
    {
        private readonly IPbm IPbm;
        public PbmApiController(IPbm IPbm)
        {
            this.IPbm = IPbm;
        }


        [HttpGet("/api/ListaPbm")]
        public async Task<JsonResult> ListaPbm()
        {
            return Json(await this.IPbm.List());
        }


        [HttpPost("/api/AdicionarPbm")]
        public async Task<JsonResult> AdicionarPbm([FromBody] Pbm Pbm)
        {
            if (String.IsNullOrEmpty(Pbm.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IPbm.Add(Pbm)));

            return Json(Ok());
        }


        [HttpGet("/api/RetornaPbmPorId/{id}")]
        public async Task<JsonResult> RetornaPbmPorId(int id)
        {
            return Json(await this.IPbm.GetEntityById(id));
        }

        [HttpPost("/api/EditarPbm")]
        public async Task<JsonResult> EditarPbm([FromBody] Pbm Pbm)
        {
            if (String.IsNullOrEmpty(Pbm.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IPbm.Update(Pbm)));
            return Json(Ok());

        }

        [HttpPost("/api/ExcluirBpm")]
        public async Task ExcluirBpm([FromBody] Pbm Pbm)
        {
            await Task.FromResult(this.IPbm.Delete(Pbm));
        }

    }
}