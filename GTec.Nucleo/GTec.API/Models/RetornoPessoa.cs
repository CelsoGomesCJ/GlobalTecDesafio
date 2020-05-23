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

        public static RetornoPessoa CrieRetornoListaDePessoas(List<Pessoa> pessoas)
        {
            return new RetornoPessoa
            {
                Codigo = 0,
                Mensagem = "Itens obtidos!",
                Resultado = pessoas
            };
        }

        public static RetornoPessoa CrieFalhaRetornoListaDePessoas()
        {
            return new RetornoPessoa
            {
                Codigo = 1,
                Mensagem = "Aconteceu algum problema ao obter a lista de pessoas!",
            };
        }


    }
}
