using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GTec.Nucleo.Negocio;
using GTec.API.Models;
using GTec.Nucleo.Repositorios;
using GTec.Nucleo.Utilidades;
using System;

namespace GTec.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //Autenticar Usuário 
        [HttpPost]
        [Route("autentique")]
        public RetornoAutenticacao Autentique([FromBody] Usuario usuario)
        {
            var repositorioDeUsuario = new RepositorioDeUsuario();
            var hashSenha = Criptografia.ObtenhaHashSha256(usuario.Senha);
            usuario.Senha = hashSenha;

            if (repositorioDeUsuario.UsuarioEhValido(usuario.Nome, usuario.Senha))
            {
                var token = $"{usuario.Nome}|{usuario.Senha}";
                return RetornoAutenticacao.CrieSucessoAutenticacao(token);
            }

            return RetornoAutenticacao.CrieFalhaAutenticacao();

        }

        //Registrar Usuario
        [HttpPost]
        [Route("registrarusuario")]
        public RetornoRegistroUsuario RegistrarUsuario([FromBody] Usuario usuario)
        {
            var repositorioDeUsuario = new RepositorioDeUsuario();
            var hashSenha = Criptografia.ObtenhaHashSha256(usuario.Senha);
            usuario.Senha = hashSenha;

            try
            {
                repositorioDeUsuario.RegistreUsuario(usuario);
                var token = $"{usuario.Nome}|{usuario.Senha}";
                return RetornoRegistroUsuario.CrieSucessoRegistro(token);
            }
            catch (Exception erro)
            {
                return RetornoRegistroUsuario.CrieFalhaNoRegistro();
            }

        }
    }
}
