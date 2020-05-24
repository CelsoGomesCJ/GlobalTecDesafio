using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTec.API.Models
{
    public class RetornoAutenticacao : RetornoAbstrato
    {
        public static RetornoAutenticacao CrieFalhaAutenticacao()
        {
            return new RetornoAutenticacao
            {
                Codigo = 1,
                Mensagem = "Nao autorizado"
            };
        }

        public static RetornoAutenticacao CrieSucessoAutenticacao(string token)
        {
            return new RetornoAutenticacao
            {
                Codigo = 0,
                Mensagem = "Autenticado com sucesso!",
                Token = token
            };
        }
    }
}
