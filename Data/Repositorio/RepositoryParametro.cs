using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data.Config;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositorio
{
    public class RepositoryParametro : RepositoryGenerics<Parametro>, IParametro
    {
        public Task<List<Parametro>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }

        public async Task AdicionarParametro(Farmacia farmacia, Endereco endereco, Contato contato, Farmaceutico farmaceutico, 
            Impressao impressao, CupomFiscal cupomFiscal, ConvenioParametro convenioParametro, 
            CartoesTEF cartoesTEF, NfeSped nfeSped, Nfe nfe, GeralFarmacia geralFarmacia,
            PrismaSync prismaSync, Sipro sipro, GestaoEntrega gestaoEntrega, 
            GeralManipulacao geralManipulacao, OpcoesManipulacao opcoesManipulacao, 
            ImpressaoManipulacao impressaoManipulacao, DrogariaAcabado drogariaAcabado)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                try
                {
                    using (var transaction = data.Database.BeginTransaction())
                    {
                        try
                        {
                            //Endereco
                            await data.Set<Endereco>().AddAsync(endereco);
                            await data.SaveChangesAsync();

                            //Contato
                            await data.Set<Contato>().AddAsync(contato);
                            await data.SaveChangesAsync();

                            //Farmaceutico
                            await data.Set<Farmaceutico>().AddAsync(farmaceutico);
                            await data.SaveChangesAsync();

                            //Ids
                            var idEndereco = endereco.Id;
                            var idContato = contato.Id;
                            var idFarmaceutico = farmaceutico.Id;

                            //Farmacia
                            farmacia.Ativo = 1;
                            farmacia.EnderecoId = idEndereco;
                            farmacia.ContatoId = idContato;
                            farmacia.FarmaceuticoId = idFarmaceutico;
                            await data.Set<Farmacia>().AddAsync(farmacia);
                            await data.SaveChangesAsync();

                            //Impressao
                            await data.Set<Impressao>().AddAsync(impressao);
                            await data.SaveChangesAsync();

                            //Cupom Fiscal
                            await data.Set<CupomFiscal>().AddAsync(cupomFiscal);
                            await data.SaveChangesAsync();

                            //Convenio
                            await data.Set<ConvenioParametro>().AddAsync(convenioParametro);
                            await data.SaveChangesAsync();

                            //Cartoes TEF
                            await data.Set<CartoesTEF>().AddAsync(cartoesTEF);
                            await data.SaveChangesAsync();

                            //NfeSped
                            await data.Set<NfeSped>().AddAsync(nfeSped);
                            await data.SaveChangesAsync();

                            //Nfe
                            await data.Set<Nfe>().AddAsync(nfe);
                            await data.SaveChangesAsync();

                            //Geral Farmacia
                            await data.Set<GeralFarmacia>().AddAsync(geralFarmacia);
                            await data.SaveChangesAsync();

                            //PrismaSync
                            await data.Set<PrismaSync>().AddAsync(prismaSync);
                            await data.SaveChangesAsync();

                            //Sipro
                            await data.Set<Sipro>().AddAsync(sipro);
                            await data.SaveChangesAsync();

                            //Gestão Entrega
                            await data.Set<GestaoEntrega>().AddAsync(gestaoEntrega);
                            await data.SaveChangesAsync();

                            //Geral Manipulação
                            await data.Set<GeralManipulacao>().AddAsync(geralManipulacao);
                            await data.SaveChangesAsync();

                            //Opcoes Manipulação
                            await data.Set<OpcoesManipulacao>().AddAsync(opcoesManipulacao);
                            await data.SaveChangesAsync();

                            //Impressão Manipulação
                            await data.Set<ImpressaoManipulacao>().AddAsync(impressaoManipulacao);
                            await data.SaveChangesAsync();

                            //Drogaria Acabado
                            await data.Set<DrogariaAcabado>().AddAsync(drogariaAcabado);
                            await data.SaveChangesAsync();

                            //Nao esquecer de criar e inserir na tabela parametro todos os ids
                            //IDs Para Parametro
                            //var idFarmacia = farmacia.Id;
                            //var idImpressao = impressao.Id;
                            //var idCupomFiscal = cupomFiscal.Id;
                            //var idConvenio = convenioParametro.Id;
                            //var idCartoesTEF = cartoesTEF.Id;
                            //var idNfeSped = nfeSped.Id;
                            //var idNfe = nfe.Id;
                            //var idGeralFarmacia = geralFarmacia.Id;
                            //var idPrismaSync = prismaSync.Id;
                            //var idGestaoEntrega = gestaoEntrega.Id;
                            //var idGeralManipulacao = geralManipulacao.Id;
                            //var idOpcoesManipulacao = opcoesManipulacao.Id;
                            //var idImpressaoManipulacao = impressaoManipulacao.Id;
                            //var idDrogariaAcabado = drogariaAcabado.Id;

                            await transaction.CommitAsync();


                        }
                        catch (Exception)
                        {
                            await transaction.RollbackAsync();
                            throw;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw;
                }

            }
        }


    }
}
