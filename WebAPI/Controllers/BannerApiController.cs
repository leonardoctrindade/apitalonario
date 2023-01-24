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
    public class BannerApiController : Controller
    {
        private readonly IBanner IBanner;

        public BannerApiController(IBanner IBanner)
        {
            this.IBanner = IBanner;
        }

        [HttpGet("/api/ListaPaginacaoBanner/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var banners = await this.IBanner.List();

                var total = Convert.ToDouble(banners.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IBanner.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : banners);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os banners " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaBanner")]
        public async Task<JsonResult> ListaBanner()
        {
            try
            {
                return Json(await this.IBanner.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os banner " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarBanner")]
        public async Task<IActionResult> AdicionarBanner([FromBody] Banner Banner)
        {
            try
            {
                if (Banner.Posicao < 0)
                    return BadRequest("Campo de posição não pode ser menor que 0");
                if (string.IsNullOrEmpty(Banner.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (string.IsNullOrEmpty(Banner.Link.Trim()))
                    return BadRequest("Campo de link é obrigatório");
                if (Banner.AcaoLink < 0)
                    return BadRequest("Campo de Ação Link não pode ser menor que 0");
                if (!Banner.DataInicio.HasValue)
                    return BadRequest("Campo de data inicio é obrigatório");
                if (!Banner.DataFim.HasValue)
                    return BadRequest("Campo de data fim é obrigatório");

                if (!string.IsNullOrEmpty(Banner.Imagem))
                {
                    Banner.ImagemBanner = Convert.FromBase64String(Banner.Imagem);
                    Banner.Imagem = string.Empty;
                }

                Json(await Task.FromResult(this.IBanner.Add(Banner)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o banner " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaBannerPorId/{id}")]
        public async Task<JsonResult> RetornaBannerPorId(int id)
        {
            try
            {
                var banner = await this.IBanner.GetEntityById(id);

                if (banner.ImagemBanner != null)
                    banner.Imagem = Convert.ToBase64String(banner.ImagemBanner);

                return Json(banner);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o banner " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarBanner")]
        public async Task<IActionResult> EditarBanner([FromBody] Banner Banner)
        {
            try
            {
                if (Banner.Posicao < 0)
                    return BadRequest("Campo de posição não pode ser menor que 0");
                if (string.IsNullOrEmpty(Banner.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (string.IsNullOrEmpty(Banner.Link.Trim()))
                    return BadRequest("Campo de link é obrigatório");
                if (Banner.AcaoLink < 0)
                    return BadRequest("Campo de Ação Link não pode ser menor que 0");
                if (!Banner.DataInicio.HasValue)
                    return BadRequest("Campo de data inicio é obrigatório");
                if (!Banner.DataFim.HasValue)
                    return BadRequest("Campo de data fim é obrigatório");

                if (!string.IsNullOrEmpty(Banner.Imagem))
                {
                    Banner.ImagemBanner = Convert.FromBase64String(Banner.Imagem);
                    Banner.Imagem = string.Empty;
                }

                Json(await Task.FromResult(this.IBanner.Update(Banner)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o banner " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirBanner")]
        public async Task<JsonResult> ExcluirBanner([FromBody] Banner Banner)
        {
            try
            {
                Json(await Task.FromResult(this.IBanner.Delete(Banner)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o banner " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
