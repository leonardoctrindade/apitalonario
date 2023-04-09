using Data.Entidades;
using Data.Helper;
using Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MultasApiController : Controller
    {
        private readonly IMultas iMultas;
        public MultasApiController(IMultas iMultas)
        {
            this.iMultas = iMultas;
        }


        [HttpGet("/api/ListaMultas")]
        public async Task<JsonResult> ListaMultas()
        {

            return Json(await this.iMultas.List());
        }

        [HttpPost("/api/BuscarMultas/{matricula}/{placa}/{data}/{hora}/{infracao}")]
        public async Task<Multas> BuscarMulta(int matricula, string placa, DateTime data, string hora, string infracao)
        {
            var ret = await this.iMultas.BuscarMulta(matricula, placa, data, hora, infracao);
            return ret;

        }

        [HttpPost("/api/AdicionarMultas")]
        public async Task<JsonResult> AdicionarMultas([FromBody] Multas multas)
        {
            if (multas == null)
                return Json(BadRequest(ModelState));

            DateTime agora = DateTime.Now.Date;
            string horaAtual = DateTime.Now.ToString("HH:mm");

            var retMulta = await BuscarMulta(multas.idMatricula, multas.Placa, agora, horaAtual, multas.Infracao);

            if (retMulta != null)
            {
                return Json(BadRequest());
            }
            else
            {
                multas.Hora = horaAtual;
                multas.Data = DateTime.Parse(agora.ToString("dd/MM/yyyy"));
                multas.DataInclusao = agora;

                Json(await Task.FromResult(this.iMultas.Add(multas)));
            }
            return Json(Ok());
        }


        [HttpGet("/api/RetornaMultasPorId/{id}")]
        public async Task<JsonResult> RetornaMultasPorId(int id)
        {
            return Json(await this.iMultas.GetEntityById(id));
        }

        [HttpPost("/api/EditarMultas")]
        public async Task<JsonResult> EditarMultas([FromBody] Multas multas)
        {
            if (multas == null)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.iMultas.Update(multas)));
            return Json(Ok());

        }

        [HttpPost("/api/ExcluirMultas")]
        public async Task ExcluirMultas([FromBody] Multas multas)
        {
            await Task.FromResult(this.iMultas.Delete(multas));
        }

    }
}