using Data.Config;
using Data.Entidades;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryPrescritor : RepositoryGenerics<Prescritor>, IPrescritor
    {
        public async Task<List<Prescritor>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<Prescritor>();

                try
                {
                    result = await context.Prescritor
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

        public async Task<Prescritor> GetPrescritor(int id)
        {
            var result = new Prescritor();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.Prescritor
                    .Include(c => c.Bairro)
                    .Include(c => c.Cidade)
                    .Include(c => c.Estado)
                    .Include(c => c.Visitador)
                    .Include(c => c.EspecialidadePrescritores)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
