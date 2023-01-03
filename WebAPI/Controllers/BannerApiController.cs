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
        public async Task<JsonResult> AdicionarBanner([FromBody] Banner Banner)
        {
            try
            {
                if (Banner.Posicao < 0)
                    return Json(BadRequest(ModelState));

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
        public async Task<JsonResult> EditarBanner([FromBody] Banner Banner)
        {
            try
            {
                if (Banner.Posicao < 0)
                    return Json(BadRequest(ModelState));

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
