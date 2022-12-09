using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class ViewPlanoDeContas
    {
        public List<PlanoDeContas> Nivel1 { get; set; } = new List<PlanoDeContas>();
        public List<PlanoDeContas> Nivel2 { get; set; } = new List<PlanoDeContas>();
        public List<PlanoDeContas> Nivel3 { get; set; } = new List<PlanoDeContas>();
    }
}
