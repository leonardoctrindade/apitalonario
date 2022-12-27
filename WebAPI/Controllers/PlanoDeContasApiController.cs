using System;
using System.Linq;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography.X509Certificates;
using Data.Config;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    public class PlanoDeContasApiController : Controller
    {
        private readonly IPlanoDeContas IPlanoDeContas;
        public PlanoDeContasApiController(IPlanoDeContas iPlanoDeContas)
        {
            IPlanoDeContas = iPlanoDeContas;
        }

        [HttpGet("/api/ListaPlanoDeContas")]
        public async Task<JsonResult> ListaPlanoDeContas()
        {
            try
            {
                var listaPlanoDeContas = await this.IPlanoDeContas.List();
                return Json(listaPlanoDeContas);
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os planos de contas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarPlanoDeContas")]
        public async Task<JsonResult> AdicionarPlanoDeContas([FromBody] PlanoDeContas planoDeContas)
        {
            try
            {
                if (string.IsNullOrEmpty(planoDeContas.NumeroContaPai) ||
                planoDeContas.NivelConta <= 0 ||
                string.IsNullOrEmpty(planoDeContas.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IPlanoDeContas.Add(planoDeContas)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o plano de contas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornarPlanoDeContasPorId/{id}")]
        public async Task<JsonResult> RetornarPlanoDeContasPorId(int id)
        {
            try
            {
                return Json(await this.IPlanoDeContas.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o plano de contas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarPlanoDeContas")]
        public async Task<JsonResult> EditarPlanoDeContas([FromBody] PlanoDeContas planoDeContas)
        {
            try
            {
                if (string.IsNullOrEmpty(planoDeContas.NumeroContaPai) ||
                planoDeContas.NivelConta <= 0 ||
                string.IsNullOrEmpty(planoDeContas.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IPlanoDeContas.Update(planoDeContas)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar o plano de contas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirPlanoDeContas")]
        public async Task<JsonResult> ExcluirPlanoDeContas([FromBody] PlanoDeContas planoDeContas)
        {
            try
            {
                Json(await Task.FromResult(this.IPlanoDeContas.Delete(planoDeContas)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o plano de contas " + ex.Message }) { StatusCode = 400 };
            }
        } 
    }
}
