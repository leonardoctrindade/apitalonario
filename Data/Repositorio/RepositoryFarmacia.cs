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
    public class RepositoryFarmacia : RepositoryGenerics<Farmacia>, IFarmacia
    {
        public Task<List<Farmacia>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
