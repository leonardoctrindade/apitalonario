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
    public class CidadeApiController : Controller
    {
        private readonly ICidade ICidade;

        public CidadeApiController(ICidade ICidade)
        {
            this.ICidade = ICidade;
        }

        [HttpGet("/api/ListaCidade")]
        public async Task<JsonResult> ListaCidade()
        {
            try
            {
                return Json(await this.ICidade.List());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as cidades " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarCidade")]
        public async Task<JsonResult> AdicionarCidade([FromBody] Cidade Cidade)
        {
            try
            {
                if (String.IsNullOrEmpty(Cidade.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ICidade.Add(Cidade)));

                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o bairro " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaCidadePorId/{id}")]
        public async Task<JsonResult> RetornaCidadePorId(int id)
        {
            try
            {
                return Json(await this.ICidade.GetCidade(id));
            } catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o bairro " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarCidade")]
        public async Task<JsonResult> EditarCidade([FromBody] Cidade Cidade)
        {
            try
            {
                if (String.IsNullOrEmpty(Cidade.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ICidade.Update(Cidade)));
                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar o bairro " + ex.Message }) { StatusCode = 400 };
            }
            
        }

        [HttpPost("/api/ExcluirCidade")]
        public async Task<JsonResult> ExcluirCidade([FromBody] Cidade Cidade)
        {
            try
            {
                return Json(await Task.FromResult(this.ICidade.Delete(Cidade)));
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o bairro " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
