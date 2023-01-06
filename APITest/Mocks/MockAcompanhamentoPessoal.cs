using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public class MockAcompanhamentoPessoal
    {
        public static AcompanhamentoPessoal MontaObjetoUnico()
        {
            return new AcompanhamentoPessoal { Id = 1, Data = DateTime.Now.Date, Peso = 1, PressaoArterial = 1, InformacoesLaboratoriais = "Teste Mock 1", OutrasInformacoes = "Teste Mock 1", TipoSanguineo = "Teste 1", ClienteId = 1 };
        }

        public static AcompanhamentoPessoal MontaObjetoDataVazia()
        {
            return new AcompanhamentoPessoal { Id = 1, Data = null, Peso = 1, PressaoArterial = 1, InformacoesLaboratoriais = "Teste Mock 1", OutrasInformacoes = "Teste Mock 1", TipoSanguineo = "Teste 1", ClienteId = 1 };
        }

        public static AcompanhamentoPessoal MontaObjetoClienteIdInvalido()
        {
            return new AcompanhamentoPessoal { Id = 1, Data = DateTime.Now.Date, Peso = 1, PressaoArterial = 1, InformacoesLaboratoriais = "Teste Mock 1", OutrasInformacoes = "Teste Mock 1", TipoSanguineo = "Teste 1", ClienteId = 0 };
        }

        public static List<AcompanhamentoPessoal> MontaListaItems()
        {
            return new List<AcompanhamentoPessoal>()
            {
                new AcompanhamentoPessoal() { Id = 1, Data = DateTime.Now.Date, Peso = 1, PressaoArterial = 1, InformacoesLaboratoriais = "Teste Mock 1", OutrasInformacoes = "Teste Mock 1", TipoSanguineo = "Teste 1", ClienteId = 1 },
                new AcompanhamentoPessoal() { Id = 2, Data = DateTime.Now.Date, Peso = 2, PressaoArterial = 2, InformacoesLaboratoriais = "Teste Mock 2", OutrasInformacoes = "Teste Mock 2", TipoSanguineo = "Teste 2", ClienteId = 2 },
                new AcompanhamentoPessoal() { Id = 3, Data = DateTime.Now.Date, Peso = 3, PressaoArterial = 3, InformacoesLaboratoriais = "Teste Mock 3", OutrasInformacoes = "Teste Mock 3", TipoSanguineo = "Teste 3", ClienteId = 3 },
            };
        }
    }
}
