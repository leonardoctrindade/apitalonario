using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Data.Config;
using System.Linq;

namespace WebAPI.Controllers
{
    public class FornecedorApiController : Controller
    {
        private readonly IFornecedor IFornecedor;

        public FornecedorApiController(IFornecedor IFornecedor)
        {
            this.IFornecedor = IFornecedor;
        }

        [HttpGet("/api/ListaPaginacaoFornecedor/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var fornecedores = await this.IFornecedor.List();

                var total = Convert.ToDouble(fornecedores.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IFornecedor.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : fornecedores);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os fornecedores " + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarFornecedor([FromBody] Fornecedor Fornecedor)
        {
            try
            {
                if (String.IsNullOrEmpty(Fornecedor.NomeFornecedor.Trim()))
                    return BadRequest("Campo de nome fornecedor é obrigatório");
                if (String.IsNullOrEmpty(Fornecedor.NomeFantasia.Trim()))
                    return BadRequest("Campo do nome fantasia é obrigatório");
                if (String.IsNullOrEmpty(Fornecedor.Cnpj.Trim()))
                    return BadRequest("Campo de cnpj é obrigatório");
                if (String.IsNullOrEmpty(Fornecedor.Cpf.Trim()))
                    return BadRequest("Campo de cpf é obrigatório");
                if (String.IsNullOrEmpty(Fornecedor.InscricaoEstadual.Trim()))
                    return BadRequest("Campo de inscrição estadual é obrigatório");
                if (Fornecedor.EstadoId == 0)
                    return BadRequest("Campo de estado é obrigatório");

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
        public async Task<IActionResult> EditarFornecedor([FromBody] Fornecedor Fornecedor)
        {
            try
            {
                if (String.IsNullOrEmpty(Fornecedor.NomeFornecedor.Trim()))
                    return BadRequest("Campo de nome fornecedor é obrigatório");
                if (String.IsNullOrEmpty(Fornecedor.NomeFantasia.Trim()))
                    return BadRequest("Campo do nome fantasia é obrigatório");
                if (String.IsNullOrEmpty(Fornecedor.Cnpj.Trim()))
                    return BadRequest("Campo de cnpj é obrigatório");
                if (String.IsNullOrEmpty(Fornecedor.Cpf.Trim()))
                    return BadRequest("Campo de cpf é obrigatório");
                if (String.IsNullOrEmpty(Fornecedor.InscricaoEstadual.Trim()))
                    return BadRequest("Campo de inscrição estadual é obrigatório");
                if (Fornecedor.EstadoId == 0)
                    return BadRequest("Campo de estado é obrigatório");

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
