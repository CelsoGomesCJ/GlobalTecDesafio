using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTec.API.Models
{
    public class RetornoRegistroUsuario : RetornoAbstrato
    {
        public static RetornoRegistroUsuario CrieFalhaNoRegistro()
        {
            return new RetornoRegistroUsuario
            {
                Codigo = 1,
                Mensagem = "Falha ao criar usuário!"
            };
        }

        public static RetornoRegistroUsuario CrieSucessoRegistro(string token)
        {
            return new RetornoRegistroUsuario
            {
                Codigo = 0,
                Mensagem = "Usuário registrado com sucesso!",
                Token = token
            };
        }
    }
}
