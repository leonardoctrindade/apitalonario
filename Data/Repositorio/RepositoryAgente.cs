using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data.Config;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Data.Helper;

namespace Data.Repositorio
{
    public class RepositoryAgente : RepositoryGenerics<Agente>, IAgente
    {
        public async Task<List<Agente>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<Agente>();

                try
                {
                    result = await context.Agente
                   .OrderBy(x => x.Id)
                   .Skip((pagina - 1) * 10)
                   .Take(10)
                   .ToListAsync();
                }
                catch (Exception)
                {

                    throw;
                }


                return result;
            }
        }

        public async Task<Agente> BuscarAgente(int matricula, string senha)
        {
            try
            {
                using (var context = new ContextBase(this._OptionsBuilder))
                {
                    return await context.Agente.Where(x => x.Matricula == matricula && x.Senha == senha).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Agente> BuscarAgente(int matricula)
        {
            try
            {
                using (var context = new ContextBase(this._OptionsBuilder))
                {
                    return await context.Agente.Where(x => x.Matricula == matricula).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task MudarSenhaAgente(int matricula, string senha)
        {
            try
            {
                using (var context = new ContextBase(_OptionsBuilder))
                {

                    var result = await context.Agente.Where(x => x.Matricula == matricula).FirstOrDefaultAsync();
                    if (result != null)
                    {
                        result.Senha = senha;
                        context.SaveChanges();
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
