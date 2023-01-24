using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data.Config;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Repositorio
{
    public class RepositoryCategoria: RepositoryGenerics<Categoria>, ICategoria 
    {
        public async Task<List<Categoria>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<Categoria>();

                try
                {
                    result = await context.Categoria
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

        public async Task<Categoria> GetCategoria(int id)
        {
            var result = new Categoria();
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                result = await context.Categoria
                    .Include(c => c.CategoriaPai)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
