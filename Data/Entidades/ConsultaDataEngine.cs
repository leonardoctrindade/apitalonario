using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class ConsultaDataEngine
    {
        public string plate { get; set; }
        public string chassis { get; set; }
        public string uf { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string brand_model { get; set; }
        public string yaer { get; set; }
        public string specie { get; set; }
        public string country { get; set; }
        public string type { get; set; }
        public string renavam { get; set; }
        public string engine_number { get; set; }
        public string fuel { get; set; }
        public string potency { get; set; }
        public string color { get; set; }
        public string axis_number { get; set; }
        public string type_bodywork { get; set; }
        public string seal_number { get; set; }
        public string weight { get; set; }
        public string passenger_number { get; set; }
        public string owner_name { get; set; }
        public string owner_document_type { get; set; }
        public string owner_document_number { get; set; }
        public string last_owner { get; set; }
        public string last_licensing { get; set; }
        public string situation { get; set; }
        public string theft { get; set; }
        public string park_retention { get; set; }

    }

    public class TokenEngine
    {
        public object accessToken { get; set; }
        public object refreshToken { get; set; }
        public string apiToken { get; set; }
        public string userIdEncripted { get; set; }
    }

    public class ConsultaResponseEngine
    {
        public ConsultaDataEngine data { get; set; }
        public bool isSucess { get; set; }
        public string message { get; set; }
        public object pdf { get; set; }
        public object parameter { get; set; }
        public Token token { get; set; }
        public object created { get; set; }
        public bool messageCript { get; set; }
        public object errors { get; set; }
    }

    public class ConsultaApiResponseEngine
    {
        public string MARCA { get; set; }
        public string SUBMODELO { get; set; }
        public string VERSAO { get; set; }
        public string ano { get; set; }
        public string anoModelo { get; set; }
        public string chassi { get; set; }

        public string logo { get; set; }
        public string marcaModelo { get; set; }
        public string modelo { get; set; }
        public string municipio { get; set; }
        public string origem { get; set; }
        public string placa { get; set; }

        public string placa_alternativa { get; set; }
        public string segmento { get; set; }
        public string situacao { get; set; }
        public string sub_segmento { get; set; }
        public string token { get; set; }
        public string uf { get; set; }
        public string cor { get; set; }
    }

}
