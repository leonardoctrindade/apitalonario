using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            return Json(await this.IFornecedor.List());
        }

        [HttpPost("/api/AdicionarFornecedor")]
        public async Task<JsonResult> AdicionarFornecedor([FromBody] Fornecedor Fornecedor)
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
            if (Fornecedor.IdEstado == 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IFornecedor.Add(Fornecedor)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaFornecedorPorId/{id}")]
        public async Task<JsonResult> RetornaFornecedorPorId(int id)
        {
            return Json(await this.IFornecedor.GetEntityById(id));
        }

        [HttpPost("/api/EditarFornecedor")]
        public async Task<JsonResult> EditarFornecedor([FromBody] Fornecedor Fornecedor)
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
            if (Fornecedor.IdEstado == 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IFornecedor.Update(Fornecedor)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirFornecedor")]
        public async Task ExcluirFornecedor([FromBody] Fornecedor Fornecedor)
        {
            await Task.FromResult(this.IFornecedor.Delete(Fornecedor));
        }
    }
}
