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
            var senhaCriptografada = Encryptor.MD5Encryption(senha);

            using (var context = new ContextBase(this._OptionsBuilder))
            {
                return await context.Agente.Where(x => x.Matricula == matricula && x.Senha == senhaCriptografada).FirstOrDefaultAsync();
            }
        }
    }
}
