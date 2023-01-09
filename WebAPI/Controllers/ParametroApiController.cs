using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Data.Config;
using System.Transactions;

namespace WebAPI.Controllers
{
    public class ParametroApiController : Controller
    {
        private readonly IParametro IParametro;
        private readonly IEndereco IEndereco;
        private readonly IContato IContato;

        public ParametroApiController(IParametro IParametro, IEndereco IEndereco, IContato IContato)
        {
            this.IParametro = IParametro;
            this.IEndereco = IEndereco;
            this.IContato = IContato;
        }
      
        [HttpPost("/api/AdicionarParametro")]
        public async Task<JsonResult> AdicionarParametro([FromBody] Parametro parametro)
        {
            try
            {
                Json(await Task.FromResult(this.IParametro.AdicionarParametro(parametro.Farmacia, parametro.Farmacia.Endereco, parametro.Farmacia.Contato, parametro.Farmacia.Farmaceutico, parametro.Impressao)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o Parâmetro " + ex.Message }) { StatusCode = 400 };
            }
        }


    }
}
