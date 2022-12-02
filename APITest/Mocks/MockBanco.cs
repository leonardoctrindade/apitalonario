using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public static class MockBanco
    {
        public static Banco MontaObjetoUnico()
        {
            return new Banco
            {
                Id = 1,
                Nome = "Teste Mock 1",
                CodigoBanco = 123,
                Carteira = "Teste 1",
                Modalidade = "Teste",
                FormaCobranca = "B",
                Layout = "Teste",
                SequenciaRemessa = 123,
                NomeCedente = "Teste Mock 1",
                CnpjCedente = "15168161468",
                CodigoCedente = "68168",
                CodigoTransmissao = "116168",
                ComplementoTransmissao = "1879",
                Agencia = "1245",
                AgenciaDigito = "A",
                DiasProtesto = 5,
                Juros = 25,
                Multa = 26,
                ContaCorrente = "541981984169",
                ContaCorrenteDigito = "1",
                Convenio = "161",
                Producao = true,
                LocalPagamento = "11161",
                MensagemInstrucao1 = "Teste Mock 1 Mensagem 1",
                MensagemInstrucao2 = "Teste Mock 1 Mensagem 2",
                MensagemInstrucao3 = "Teste Mock 1 Mensagem 3",
                MensagemInstrucao4 = "Teste Mock 1 Mensagem 4",
                MensagemInstrucao5 = "Teste Mock 1 Mensagem 5"
            };
        }
        public static Banco MontaObjetoNomeVazio()
        {
            return new Banco
            {
                Id = 1,
                Nome = null,
                CodigoBanco = 123,
                Carteira = "Teste 1",
                Modalidade = "Teste",
                FormaCobranca = "B",
                Layout = "Teste",
                SequenciaRemessa = 123,
                NomeCedente = "Teste Mock 1",
                CnpjCedente = "15168161468",
                CodigoCedente = "68168",
                CodigoTransmissao = "116168",
                ComplementoTransmissao = "1879",
                Agencia = "1245",
                AgenciaDigito = "A",
                DiasProtesto = 5,
                Juros = 25,
                Multa = 26,
                ContaCorrente = "541981984169",
                ContaCorrenteDigito = "1",
                Convenio = "161",
                Producao = true,
                LocalPagamento = "11161",
                MensagemInstrucao1 = "Teste Mock 1 Mensagem 1",
                MensagemInstrucao2 = "Teste Mock 1 Mensagem 2",
                MensagemInstrucao3 = "Teste Mock 1 Mensagem 3",
                MensagemInstrucao4 = "Teste Mock 1 Mensagem 4",
                MensagemInstrucao5 = "Teste Mock 1 Mensagem 5"
            };
        }
        public static Banco MontaObjetoCodigoBancoVazio()
        {
            return new Banco
            {
                Id = 1,
                Nome = "Teste Mock 1",
                CodigoBanco = 0,
                Carteira = "Teste 1",
                Modalidade = "Teste",
                FormaCobranca = "B",
                Layout = "Teste",
                SequenciaRemessa = 123,
                NomeCedente = "Teste Mock 1",
                CnpjCedente = "15168161468",
                CodigoCedente = "68168",
                CodigoTransmissao = "116168",
                ComplementoTransmissao = "1879",
                Agencia = "1245",
                AgenciaDigito = "A",
                DiasProtesto = 5,
                Juros = 25,
                Multa = 26,
                ContaCorrente = "541981984169",
                ContaCorrenteDigito = "1",
                Convenio = "161",
                Producao = true,
                LocalPagamento = "11161",
                MensagemInstrucao1 = "Teste Mock 1 Mensagem 1",
                MensagemInstrucao2 = "Teste Mock 1 Mensagem 2",
                MensagemInstrucao3 = "Teste Mock 1 Mensagem 3",
                MensagemInstrucao4 = "Teste Mock 1 Mensagem 4",
                MensagemInstrucao5 = "Teste Mock 1 Mensagem 5"
            };
        }

        public static List<Banco> MontaListaItems()
        {
            return new List<Banco>()
            {
                new Banco() 
                {
                    Id = 1,
                    Nome = "Teste Mock 1",
                    CodigoBanco = 123,
                    Carteira = "Teste 1",
                    Modalidade = "Teste",
                    FormaCobranca = "B",
                    Layout = "Teste",
                    SequenciaRemessa = 123,
                    NomeCedente = "Teste Mock 1",
                    CnpjCedente = "15168161468",
                    CodigoCedente = "68168",
                    CodigoTransmissao = "116168",
                    ComplementoTransmissao = "1879",
                    Agencia = "1245",
                    AgenciaDigito = "A",
                    DiasProtesto = 5,
                    Juros = 25,
                    Multa = 26,
                    ContaCorrente = "541981984169",
                    ContaCorrenteDigito = "1",
                    Convenio = "161",
                    Producao = true,
                    LocalPagamento = "11161",
                    MensagemInstrucao1 = "Teste Mock 1 Mensagem 1",
                    MensagemInstrucao2 = "Teste Mock 1 Mensagem 2",
                    MensagemInstrucao3 = "Teste Mock 1 Mensagem 3",
                    MensagemInstrucao4 = "Teste Mock 1 Mensagem 4",
                    MensagemInstrucao5 = "Teste Mock 1 Mensagem 5"
                },
                new Banco() 
                {
                    Id = 1,
                    Nome = "Teste Mock 2",
                    CodigoBanco = 123,
                    Carteira = "Teste 2",
                    Modalidade = "Teste",
                    FormaCobranca = "B",
                    Layout = "Teste",
                    SequenciaRemessa = 123,
                    NomeCedente = "Teste Mock 2",
                    CnpjCedente = "15168161468",
                    CodigoCedente = "68168",
                    CodigoTransmissao = "116168",
                    ComplementoTransmissao = "1879",
                    Agencia = "1245",
                    AgenciaDigito = "A",
                    DiasProtesto = 5,
                    Juros = 25,
                    Multa = 26,
                    ContaCorrente = "541981984169",
                    ContaCorrenteDigito = "2",
                    Convenio = "161",
                    Producao = true,
                    LocalPagamento = "11161",
                    MensagemInstrucao1 = "Teste Mock 2 Mensagem 1",
                    MensagemInstrucao2 = "Teste Mock 2 Mensagem 2",
                    MensagemInstrucao3 = "Teste Mock 2 Mensagem 3",
                    MensagemInstrucao4 = "Teste Mock 2 Mensagem 4",
                    MensagemInstrucao5 = "Teste Mock 2 Mensagem 5"
                },
                new Banco() 
                {
                    Id = 1,
                    Nome = "Teste Mock 3",
                    CodigoBanco = 123,
                    Carteira = "Teste 3",
                    Modalidade = "Teste",
                    FormaCobranca = "B",
                    Layout = "Teste",
                    SequenciaRemessa = 123,
                    NomeCedente = "Teste Mock 3",
                    CnpjCedente = "15168161468",
                    CodigoCedente = "68168",
                    CodigoTransmissao = "116168",
                    ComplementoTransmissao = "1879",
                    Agencia = "1245",
                    AgenciaDigito = "A",
                    DiasProtesto = 5,
                    Juros = 25,
                    Multa = 26,
                    ContaCorrente = "541981984169",
                    ContaCorrenteDigito = "3",
                    Convenio = "161",
                    Producao = true,
                    LocalPagamento = "11161",
                    MensagemInstrucao1 = "Teste Mock 3 Mensagem 1",
                    MensagemInstrucao2 = "Teste Mock 3 Mensagem 2",
                    MensagemInstrucao3 = "Teste Mock 3 Mensagem 3",
                    MensagemInstrucao4 = "Teste Mock 3 Mensagem 4",
                    MensagemInstrucao5 = "Teste Mock 3 Mensagem 5"
                }
            };
        }
    }
}
