using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class BancoApiController : Controller
    {
        private readonly IBanco IBanco;

        public BancoApiController(IBanco IBanco)
        {
            this.IBanco = IBanco;
        }

        [HttpGet("/api/ListaPaginacaoBanco/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var bancos = await this.IBanco.List();

                var total = Convert.ToDouble(bancos.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IBanco.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : bancos);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os bancos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaBanco")]
        public async Task<JsonResult> ListaBanco()
        {
            try
            {
                return Json(await this.IBanco.List());
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os bancos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarBanco")]
        public async Task<IActionResult> AdicionarBanco([FromBody] Banco Banco)
        {
            try
            {
                if (String.IsNullOrEmpty(Banco.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");
                if (Banco.CodigoBanco.Count() == 0 || Banco.CodigoBanco.Count() > 3)
                    return BadRequest("Campo de Codigo do Banco está vazio ou invalido");

                Json(await Task.FromResult(this.IBanco.Add(Banco)));

                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o banco " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaBancoPorId/{id}")]
        public async Task<JsonResult> RetornaBancoPorId(int id)
        {
            try
            {
                return Json(await this.IBanco.GetEntityById(id));
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o banco " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarBanco")]
        public async Task<IActionResult> EditarBanco([FromBody] Banco Banco)
        {
            try
            {
                if (String.IsNullOrEmpty(Banco.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");
                if (Banco.CodigoBanco.Count() == 0 || Banco.CodigoBanco.Count() > 3)
                    return BadRequest("Campo de Codigo do Banco está vazio ou invalido");

                Json(await Task.FromResult(this.IBanco.Update(Banco)));
                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar o banco " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirBanco")]
        public async Task<JsonResult> ExcluirBanco([FromBody] Banco Banco)
        {
            try
            {
                Json(await Task.FromResult(this.IBanco.Delete(Banco)));
                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o banco " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
