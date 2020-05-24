using GTec.Nucleo.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTec.API.Models
{
    public class RetornoPessoa : RetornoAbstrato
    {
        public dynamic Resultado { get; set; }


        public static RetornoPessoa CrieRetornoConsultaPessoa(Pessoa pessoa)
        {
            return new RetornoPessoa
            {
                Codigo = 0,
                Mensagem = "Resultado consulta!",
                Resultado = pessoa
            };
        }


        public static RetornoPessoa CrieRetornoConsultaListaDePessoas(List<Pessoa> pessoas)
        {
            return new RetornoPessoa
            {
                Codigo = 0,
                Mensagem = "Resultado consulta!",
                Resultado = pessoas
            };
        }

        public static RetornoPessoa CrieFalhaRetornoConsultaDePessoas()
        {
            return new RetornoPessoa
            {
                Codigo = 1,
                Mensagem = "Aconteceu algum problema ao obter a consulta de pessoas!",
            };
        }

        public static RetornoPessoa CrieFalhaRetornoRegistroDePessoas(Exception erro)
        {
            return new RetornoPessoa
            {
                Codigo = 1,
                Mensagem = $"{erro.Message}",
            };
        }

        public static RetornoPessoa CrieSucessoRetornoRegistroDePessoas(Pessoa pessoa)
        {
            return new RetornoPessoa
            {
                Codigo = 0,
                Mensagem = "Registrado com sucesso!",
                Resultado = pessoa
            };
        }

        public static RetornoPessoa CrieSucessoRetornoExclusaoDePessoa()
        {
            return new RetornoPessoa
            {
                Codigo = 0,
                Mensagem = "Deletado com sucesso!",
            };
        }

        public static RetornoPessoa CrieFalhaRetornoExclusaoDePessoa()
        {
            return new RetornoPessoa
            {
                Codigo = 1,
                Mensagem = "Ocorreu algum problema na hora de excluir a pessoa!",
            };
        }


    }
}
