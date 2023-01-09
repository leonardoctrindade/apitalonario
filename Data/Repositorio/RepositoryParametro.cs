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

        public async Task AdicionarParametro(Farmacia farmacia, Endereco endereco, Contato contato, Farmaceutico farmaceutico, Impressao impressao)
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

                            //Nao esquecer de criar e inserir na tabela parametro todos os ids
                            //IDs Para Parametro
                            //var idFarmacia = farmacia.Id;
                            //var idImpressao = impressao.Id;

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
