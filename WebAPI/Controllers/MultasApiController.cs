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
using System.Net.Http;
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
        public async Task<Multas> BuscarMulta(int matricula, string placa, string data, string hora, string infracao)
        {
            var ret = await this.iMultas.BuscarMulta(matricula, placa, data, hora, infracao);
            return ret;

        }


        [HttpGet("/api/BuscarMultasTotal/{matricula}/{dataInicial}/{dataFinal}")]
        public async Task<List<TotalMultas>> BuscarMultasTotal(int matricula, DateTime dataInicial, DateTime dataFinal)
        {
            var ret = await this.iMultas.BuscarMultasTotal(matricula, dataInicial, dataFinal);
            return ret;

        }


        [HttpGet("/api/ArrecadacaoPorData/{dataInicial}/{dataFinal}")]
        public async Task<List<ValoresMultas>> ArrecadacaoPorData(DateTime dataInicial, DateTime dataFinal)
        {
            var ret = await this.iMultas.ArrecadacaoPorData(dataInicial, dataFinal);
            return ret;

        }


        [HttpGet("/api/BuscarMultasData/{matricula}/{dataInicial}/{dataFinal}")]
        public async Task<List<Multas>> BuscarMultasData(int matricula, DateTime dataInicial, DateTime dataFinal)
        {
            var ret = await this.iMultas.BuscarMultasData(matricula, dataInicial, dataFinal);
            return ret;

        }

        [HttpPost("/api/AdicionarMultas")]
        public async Task<JsonResult> AdicionarMultas([FromBody] Multas multas)
        {
            try
            {
                if (multas == null)
                    return Json(BadRequest(ModelState));

                //TimeZoneInfo brTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
                //DateTime dataAtualBrasil = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, brTimeZone);

                //DateTime agora = dataAtualBrasil.Date;
                System.Globalization.CultureInfo brasil = new System.Globalization.CultureInfo("pt-BR");

                string horaAtual = DateTime.Now.AddHours(2).ToString("HH:mm", brasil);

                String dataBr = DateTime.Now.AddHours(2).ToString(brasil);
                String dataBr2 = DateTime.Now.AddHours(2).ToString("yyyy-MM-dd");

                var retMulta = await BuscarMulta(multas.idMatricula, multas.Placa, dataBr2.ToString(), horaAtual, multas.Infracao);

                if (retMulta != null)
                {
                    return Json(NoContent());
                }
                else
                {
                    multas.Hora = horaAtual;
                    multas.Data = DateTime.Parse(dataBr, brasil);
                    multas.DataInclusao = DateTime.Parse(dataBr, brasil);
                    Guid g = Guid.NewGuid();
                    multas.Guid = g.ToString();
                    multas.DataString = dataBr2;
                    //Setando Orgao SJM
                    multas.OrgaoAutuador = 259010;
                    multas.Id = g.ToString();

                    Json(await Task.FromResult(this.iMultas.Add(multas)));
                }
                return Json(Ok());
            }
            catch (Exception e)
            {
                return Json(BadRequest());
            }
        }


        [HttpGet("/api/BuscaMultaAgente/{idMatricula}")]
        public async Task<JsonResult> BuscaMultaAgente(int idMatricula)
        {

            TimeZoneInfo brTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            var ret = await this.iMultas.BuscaMultaAgente(idMatricula);

            System.Globalization.CultureInfo brasil = new System.Globalization.CultureInfo("pt-BR");
            String dataBr = DateTime.Now.AddHours(2).ToString(brasil);

            string dia = DateTime.Now.AddHours(2).Day.ToString(brasil);
            string mes = DateTime.Now.AddHours(2).Month.ToString(brasil);
            string ano = DateTime.Now.AddHours(2).Year.ToString(brasil);
            string dataFormatada = dia + "/" + mes + "/" + ano;

            foreach (var item in ret)
            {

                //  item.NomeEmbarcador = DateTime.Parse(dataBr, brasil).ToString();
                item.NomeEmbarcador = dataFormatada;
            }

            return Json(ret);
        }


        [HttpGet("/api/BuscaMultaTalao/{numeroTalao}")]
        public async Task<JsonResult> BuscaMultaTalao(int numeroTalao)
        {
            System.Globalization.CultureInfo brasil = new System.Globalization.CultureInfo("pt-BR");
            String dataBr = DateTime.Now.AddHours(2).ToString(brasil);

            string dia = DateTime.Now.AddHours(2).Day.ToString(brasil);
            string mes = DateTime.Now.AddHours(2).Month.ToString(brasil);
            string ano = DateTime.Now.AddHours(2).Year.ToString(brasil);
            string dataFormatada = dia + "/" + mes + "/" + ano;

            var ret = await this.iMultas.BuscaMultaTalao(numeroTalao);
            ret.NomeEmbarcador = dataFormatada;

            return Json(ret);
        }


        [HttpGet("/api/BuscaPlaca/{placa}")]
        public async Task<JsonResult> BuscaPlaca(string placa)
        {
            try
            {

                if (placa.Length > 7)
                {
                    var ret = await this.iMultas.BuscaChassi(placa);

                    ConsultaResponse consultaResponse = new ConsultaResponse();
                    if (ret.isSucess)
                    {
                        consultaResponse.isSucess = ret.isSucess;

                        if (ret.data != null)
                        {
                            foreach (var item in ret.data)
                            {
                                consultaResponse.data = new ConsultaData();
                                consultaResponse.data.placa = item.placa;
                                consultaResponse.data.ocorrencia = item.ocorrencia;
                                consultaResponse.data.cor = item.cor;
                                consultaResponse.data.ano = item.ano;
                                consultaResponse.data.marcaModelo = item.marcaModelo;
                                consultaResponse.data.municipioUf = item.municipioUf;
                                consultaResponse.data.chassi = item.chassi;
                                consultaResponse.data.dataEmissaoCrv = item.dataEmissaoCrv;
                                consultaResponse.data.possuidorNome = item.proprietario;
                                consultaResponse.data.possuidorDocumento = item.docProprietario;
                                consultaResponse.data.renavam = item.renavam;
                                consultaResponse.data.especie = item.especie;
                            }
                        }
                    }else
                    {
                        consultaResponse.isSucess = false;
                    }

                    return Json(consultaResponse);
                }
                else
                {
                    return Json(await this.iMultas.BuscaPlaca(placa));
                }

            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpGet("/api/BuscaChassi/{chassi}")]
        public async Task<JsonResult> BuscaChassi(string chassi)
        {
            return Json(await this.iMultas.BuscaChassi(chassi));
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