using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IParametroDto : IGeneric<ParametroDto>
    {
        Task<List<ParametroDto>> ListagemCustomizada();
        Task AdicionarParametro(Farmacia farmacia, Endereco endereco,
            Contato contato, Farmaceutico farmaceutico, Impressao impressao,
            CupomFiscal cupomFiscal, ConvenioParametro convenioParametro, 
            CartoesTEF cartoesTEF, NfeSped nfeSped, Nfe nfe, GeralFarmacia geralFarmacia,
            PrismaSync prismaSync, Sipro sipro, GestaoEntrega gestaoEntrega, 
            GeralManipulacao geralManipulacao, OpcoesManipulacao opcoesManipulacao,
            ImpressaoManipulacao impressaoManipulacao, DrogariaAcabado drogariaAcabado);
    }
}
