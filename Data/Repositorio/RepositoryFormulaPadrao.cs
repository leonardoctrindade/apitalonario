﻿using System;
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
    public class RepositoryFormulaPadrao: RepositoryGenerics<FormulaPadrao>, IFormulaPadrao
    {
        public async Task<List<FormulaPadrao>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<FormulaPadrao>();

                try
                {
                    result = await context.FormulaPadrao
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

        public async Task<FormulaPadrao> GetFormulaPadrao(int id)
        {
            var result = new FormulaPadrao();
            using (var context = new ContextBase(this._OptionsBuilder)) 
            {
                result = await context.FormulaPadrao
                    .Include(c => c.Unidade)
                    .Include(c => c.UnidadeDose)
                    .Include(c => c.UnidadeDosePadrao)
                    .Include(c => c.Produto)
                    .Include(c => c.Posologia)
                    .Include(c => c.Grupo)
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();
            }

            return result;
        }
    }
}
