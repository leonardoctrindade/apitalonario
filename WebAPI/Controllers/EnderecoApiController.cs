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
    public class EnderecoApiController : Controller
    {
        private readonly IEndereco IEndereco;

        public EnderecoApiController(IEndereco IEndereco)
        {
            this.IEndereco = IEndereco;
        }

        [HttpGet("/api/ListaEndereco")]
        public async Task<JsonResult> ListaEndereco()
        {
            try
            {
                return Json(await this.IEndereco.List());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as Enderecos " + ex.Message }) { StatusCode = 400 };
            }
        }

        //[HttpPost("/api/AdicionarEndereco")]
        //public async Task<JsonResult> AdicionarEndereco([FromBody] Endereco Endereco)
        //{
        //    try
        //    {
        //        //if (String.IsNullOrEmpty(Endereco.Nome))
        //        //    return Json(BadRequest(ModelState));

        //        Json(await Task.FromResult(this.IEndereco.Add(Endereco)));

        //        return Json(Ok());
        //    } catch (Exception ex) 
        //    {
        //        return new JsonResult(new { message = "Error ao adicionar o bairro " + ex.Message }) { StatusCode = 400 };
        //    }
        //}

        //[HttpGet("/api/RetornaEnderecoPorId/{id}")]
        //public async Task<JsonResult> RetornaEnderecoPorId(int id)
        //{
        //    try
        //    {
        //        return Json(await this.IEndereco.GetEntityById(id));
        //    } catch(Exception ex)
        //    {
        //        return new JsonResult(new { message = "Error ao retornar o bairro " + ex.Message }) { StatusCode = 400 };
        //    }
        //}

        //[HttpPost("/api/EditarEndereco")]
        //public async Task<JsonResult> EditarEndereco([FromBody] Endereco Endereco)
        //{
        //    try
        //    {
        //        if (String.IsNullOrEmpty(Endereco.Nome))
        //            return Json(BadRequest(ModelState));

        //        Json(await Task.FromResult(this.IEndereco.Update(Endereco)));
        //        return Json(Ok());
        //    } catch(Exception ex) 
        //    {
        //        return new JsonResult(new { message = "Error ao editar o bairro " + ex.Message }) { StatusCode = 400 };
        //    }
            
        //}

        //[HttpPost("/api/ExcluirEndereco")]
        //public async Task<JsonResult> ExcluirEndereco([FromBody] Endereco Endereco)
        //{
        //    try
        //    {
        //        return Json(await Task.FromResult(this.IEndereco.Delete(Endereco)));
        //    } catch (Exception ex) 
        //    {
        //        return new JsonResult(new { message = "Error ao excluir o bairro " + ex.Message }) { StatusCode = 400 };
        //    }
        //}
    }
}
