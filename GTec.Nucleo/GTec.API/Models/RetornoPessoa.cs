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


        public static RetornoPessoa CrieRetornoPessoa(Pessoa pessoa)
        {
            return new RetornoPessoa
            {
                Codigo = 0,
                Mensagem = "Item obtidos!",
                Resultado = pessoa
            };
        }


        public static RetornoPessoa CrieRetornoListaDePessoas(List<Pessoa> pessoas)
        {
            return new RetornoPessoa
            {
                Codigo = 0,
                Mensagem = "Itens obtidos!",
                Resultado = pessoas
            };
        }

        public static RetornoPessoa CrieFalhaRetornoDePessoas()
        {
            return new RetornoPessoa
            {
                Codigo = 1,
                Mensagem = "Aconteceu algum problema ao obter a consulta de pessoas!",
            };
        }


    }
}
