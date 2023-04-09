using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class Multas
    {
        public long Id { get; set; }
        public int OrgaoAutuador { get; set; }
        public long NumeroTalao { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Especie { get; set; }
        public string NomeCondutor { get; set; }
        public string CNHCondutor { get; set; }
        public string UFCondutor { get; set; }
        public string CPFCondutor { get; set; }
        public string Logradouro { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public string Municipio { get; set; }
        public string Infracao { get; set; }
        public int idMatricula { get; set; }
        public string NomeEmbarcador { get; set; }
        public string CpfEmbarcador { get; set; }
        public string NomeTransportador { get; set; }
        public string CpfTransportador { get; set; }
        public string FotoCNH { get; set; }
        public string FotoVeiculo { get; set; }
        public DateTime DataInclusao { get; set; }
        public string Situacao { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public int? AnoModelo { get; set; }
        public string UF { get; set; }
        public string MunicipioPlaca { get; set; }
        public string Chassi { get; set; }
        public string Guid { get; set; }
        public string Observacao { get; set; }
        public int? Transmitida { get; set; }
        public int? Cancelada { get; set; }
        public int? Ativa { get; set; }
    }

}
