﻿using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data.Config;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositorio
{
    public class RepositoryTabelaFloral: RepositoryGenerics<TabelaFloral>, ITabelaFloral
    {
        public async Task<List<TabelaFloral>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<TabelaFloral>();

                try
                {
                    result = await context.TabelaFloral
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
    }
}
