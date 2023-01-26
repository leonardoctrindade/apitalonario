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
    public class DcbApiController : Controller
    {
        private readonly IDcb iDcb;

        public DcbApiController(IDcb idcb)
        {
            iDcb = idcb;
        }

        [HttpGet("/api/ListaPaginacaoDcb/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var dcbs = await this.iDcb.List();

                var total = Convert.ToDouble(dcbs.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.iDcb.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : dcbs);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os dcbs " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListarDcb")]
        public async Task<JsonResult> ListarDcb()
        {
            try
            {
                return Json(await this.iDcb.List());
            } catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os dcbs " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarDcb")]
        public async Task<IActionResult> AdicionarDcb([FromBody] Dcb dcb)
        {
            try
            {
                if (string.IsNullOrEmpty(dcb.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (string.IsNullOrEmpty(dcb.CodigoDcb.Trim()))
                    return BadRequest("Campo de código Dcb é obrigatório");

                Json(await Task.FromResult(this.iDcb.Add(dcb)));

                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o dcb " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaDcbPorId/{id}")]
        public async Task<JsonResult> RetornarDcbPorId(int id)
        {
            try
            {
                return Json(await this.iDcb.GetEntityById(id));
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o dcb " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarDcb")]
        public async Task<IActionResult> EditarDcb([FromBody] Dcb dcb)
        {
            try
            {
                if (string.IsNullOrEmpty(dcb.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (string.IsNullOrEmpty(dcb.CodigoDcb.Trim()))
                    return BadRequest("Campo de código Dcb é obrigatório");

                Json(await Task.FromResult(this.iDcb.Update(dcb)));

                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar o dcb " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("api/ExcluirDcb")]
        public async Task<JsonResult> ExcluirDcb([FromBody] Dcb dcb)
        {
            try
            {
                Json(await Task.FromResult(this.iDcb.Delete(dcb)));
                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o dcb " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
