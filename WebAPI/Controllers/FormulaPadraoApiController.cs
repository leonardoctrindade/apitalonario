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
    public class FormulaPadraoApiController: Controller
    {
        private readonly IFormulaPadrao IFormulaPadrao;

        public FormulaPadraoApiController(IFormulaPadrao IFormulaPadrao)
        {
            this.IFormulaPadrao = IFormulaPadrao;
        }

        [HttpGet("/api/ListaFormulaPadrao")]
        public async Task<JsonResult> ListaFormulaPadrao()
        {
            try
            {
                return Json(await this.IFormulaPadrao.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as formulas padrao " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarFormulaPadrao")]
        public async Task<JsonResult> AdicionarFormulaPadrao([FromBody] FormulaPadrao FormulaPadrao)
        {
            try
            {
                if (String.IsNullOrEmpty(FormulaPadrao.Descricao))
                    return Json(BadRequest(ModelState));
                if (FormulaPadrao.FormaFarmaceuticaId <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IFormulaPadrao.Add(FormulaPadrao)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar as formulas padrao " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaFormulaPadraoPorId/{id}")]
        public async Task<JsonResult> RetornaFormulaPadraoPorId(int id)
        {
            try
            {
                return Json(await this.IFormulaPadrao.GetFormulaPadrao(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar as formulas padrao " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarFormulaPadrao")]
        public async Task<JsonResult> EditarFormulaPadrao([FromBody] FormulaPadrao FormulaPadrao)
        {
            try
            {
                if (String.IsNullOrEmpty(FormulaPadrao.Descricao))
                    return Json(BadRequest(ModelState));
                if (FormulaPadrao.FormaFarmaceuticaId <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IFormulaPadrao.Update(FormulaPadrao)));
                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar as formulas padrao " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirFormulaPadrao")]
        public async Task<JsonResult> ExcluirFormulaPadrao([FromBody] FormulaPadrao FormulaPadrao)
        {
            try
            {
                return Json(await Task.FromResult(this.IFormulaPadrao.Delete(FormulaPadrao)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir as formulas padrao " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
