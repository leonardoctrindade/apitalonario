using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Data.Config;

namespace WebAPI.Controllers
{
    public class FornecedorApiController : Controller
    {
        private readonly IFornecedor IFornecedor;

        public FornecedorApiController(IFornecedor IFornecedor)
        {
            this.IFornecedor = IFornecedor;
        }

        [HttpGet("/api/ListaFornecedor")]
        public async Task<JsonResult> ListaFornecedor()
        {
            try
            {
                return Json(await this.IFornecedor.List());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os fornecedores " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarFornecedor")]
        public async Task<JsonResult> AdicionarFornecedor([FromBody] Fornecedor Fornecedor)
        {
            try
            {
                if (String.IsNullOrEmpty(Fornecedor.NomeFornecedor))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Fornecedor.NomeFantasia))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Fornecedor.Cnpj))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Fornecedor.Cpf))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Fornecedor.InscricaoEstadual))
                    return Json(BadRequest(ModelState));
                if (Fornecedor.EstadoId == 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IFornecedor.Add(Fornecedor)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o fornecedor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaFornecedorPorId/{id}")]
        public async Task<JsonResult> RetornaFornecedorPorId(int id)
        {
            try
            {
                return Json(await this.IFornecedor.GetFornecedor(id));
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao retornar o fornecedor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarFornecedor")]
        public async Task<JsonResult> EditarFornecedor([FromBody] Fornecedor Fornecedor)
        {
            try
            {
                if (String.IsNullOrEmpty(Fornecedor.NomeFornecedor))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Fornecedor.NomeFantasia))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Fornecedor.Cnpj))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Fornecedor.Cpf))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Fornecedor.InscricaoEstadual))
                    return Json(BadRequest(ModelState));
                if (Fornecedor.EstadoId == 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IFornecedor.Update(Fornecedor)));
                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar o fornecedor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirFornecedor")]
        public async Task<JsonResult> ExcluirFornecedor([FromBody] Fornecedor Fornecedor)
        {
            try
            {
                Json(await Task.FromResult(this.IFornecedor.Delete(Fornecedor)));
                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o fornecedor " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
