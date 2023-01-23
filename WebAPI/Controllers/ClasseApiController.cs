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
    public class ClasseApiController : Controller
    {
        private readonly IClasse IClasse;

        public ClasseApiController(IClasse iclasse)
        {
            IClasse = iclasse;
        }

        [HttpGet("/api/ListaPaginacaoPbm/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var classes = await this.IClasse.List();

                var total = Convert.ToDouble(classes.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IClasse.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : classes);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os pbms " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaClasse")]
        public async Task<JsonResult> ListaClasse()
        {
            try
            {
                return Json(await this.IClasse.List());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listas as classes " + ex.Message }) { StatusCode = 400 };
            }
            
        }

        [HttpPost("/api/AdicionarClasse")]
        public async Task<IActionResult> AdicionarClasse([FromBody] Classe classe)
        {
            try
            {
                if (string.IsNullOrEmpty(classe.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.IClasse.Add(classe)));

                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a classe " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornarClassePorId/{id}")]
        public async Task<JsonResult> RetornarClassePorId(int id)
        {
            try
            {
                if (id == 0)
                    return Json(BadRequest(ModelState));
                return Json(await this.IClasse.GetEntityById(id));
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao retornar a classe " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarClasse")]
        public async Task<IActionResult> EditarClasse([FromBody] Classe classe)
        {
            try
            {
                if (string.IsNullOrEmpty(classe.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.IClasse.Update(classe)));

                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar a classe " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirClasse")]
        public async Task<JsonResult> ExcluirClasse([FromBody] Classe classe)
        {
            try
            {
                Json(await Task.FromResult(this.IClasse.Delete(classe)));
                return Json(Ok());
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a classe " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
