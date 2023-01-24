using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Data.Config;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Repositorio
{
    public class RepositoryConvenio : RepositoryGenerics<Convenio>, IConvenio
    {
        public async Task<List<Convenio>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<Convenio>();

                try
                {
                    result = await context.Convenio
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

        public async Task<Convenio> GetConvenio(int id)
        {
            var result = new Convenio();
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                result = await context.Convenio
                    .Include(c => c.Bairro)
                    .Include(c => c.Cidade)
                    .Include(c => c.Estado)
                    .Include(c => c.Visitador)
                    .Include(c => c.ConvenioGrupos)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
