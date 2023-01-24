using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    public class DiferimentoApiController : Controller
    {
        private readonly IDiferimento IDiferimento;

        public DiferimentoApiController(IDiferimento IDiferimento)
        {
            this.IDiferimento = IDiferimento;
        }

        [HttpGet("/api/ListaPaginacaoDiferimento/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var diferimentos = await this.IDiferimento.List();

                var total = Convert.ToDouble(diferimentos.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IDiferimento.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : diferimentos);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os diferimentos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaDiferimento")]
        public async Task<JsonResult> ListaDiferimento()
        {
            try
            {
                return Json(await this.IDiferimento.List());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os diferimentos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarDiferimento")]
        public async Task<IActionResult> AdicionarDiferimento([FromBody] Diferimento Diferimento)
        {
            try
            {
                if (String.IsNullOrEmpty(Diferimento.Cst.Trim()))
                    return BadRequest("Campo de Cst é obrigatório");
                if (String.IsNullOrEmpty(Diferimento.SiglaEstado.Trim()))
                    return BadRequest("Campo de sigla do estado é obrigatório");
                if (Diferimento.AliquotaDiferimento <= 0)
                    return BadRequest("Campo de alíquota de diferimento é obrigatório");

                Json(await Task.FromResult(this.IDiferimento.Add(Diferimento)));

                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o diferimento " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaDiferimentoPorId/{id}")]
        public async Task<JsonResult> RetornaDiferimentoPorId(int id)
        {
            try
            {
                return Json(await this.IDiferimento.GetEntityById(id));
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao retornar o diferimento " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarDiferimento")]
        public async Task<IActionResult> EditarDiferimento([FromBody] Diferimento Diferimento)
        {
            try
            {
                if (String.IsNullOrEmpty(Diferimento.Cst.Trim()))
                    return BadRequest("Campo de Cst é obrigatório");
                if (String.IsNullOrEmpty(Diferimento.SiglaEstado.Trim()))
                    return BadRequest("Campo de sigla do estado é obrigatório");
                if (Diferimento.AliquotaDiferimento <= 0)
                    return BadRequest("Campo de alíquota de diferimento é obrigatório");

                Json(await Task.FromResult(this.IDiferimento.Update(Diferimento)));
                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar o diferimento " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirDiferimento")]
        public async Task<JsonResult> ExcluirDiferimento([FromBody] Diferimento Diferimento)
        {
            try
            {
                Json(await Task.FromResult(this.IDiferimento.Delete(Diferimento)));
                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o diferimento " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
