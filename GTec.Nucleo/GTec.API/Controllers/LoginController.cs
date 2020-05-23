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
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };

            //var teste = new Usuario();

            
        }

        [HttpPost]
        [Route("autentique")]
        public RetornoAutenticacao Autentique([FromBody] Usuario usuario)
        {
            
            var mapeadorDeUsuario = new RepositorioDeUsuario();
            mapeadorDeUsuario.UsuarioEhValido(usuario.Nome, usuario.Senha);

            

            return new RetornoAutenticacao();

        }

        //Registrar Usuario
        [HttpPost]
        [Route("registrarusuario")]
        public RetornoAutenticacao RegistrarUsuario([FromBody] Usuario usuario)
        {
            var mapeadorDeUsuario = new RepositorioDeUsuario();
            var retornoAutenticacao = new RetornoAutenticacao();
            var hashSenha = Criptografia.ObtenhaHashSha256(usuario.Senha);
            usuario.Senha = hashSenha;

            try
            {
                mapeadorDeUsuario.RegistreUsuario(usuario);
                retornoAutenticacao.Codigo = 0;
                retornoAutenticacao.Mensagem = "Usuário registrado com sucesso!";
                /*Estou criando o Token juntando a informação do usuário e senha mas só por exemplo mesmo 
                 * não estou pensando na segurança em estar retornando a senha como token mesmo estando como Hash*/
                retornoAutenticacao.Token = $"{usuario.Nome}|{usuario.Senha}";
            }
            catch (Exception erro)
            {
                retornoAutenticacao.Codigo = 1;
                retornoAutenticacao.Mensagem = $"Falha ao criar usuário";
                retornoAutenticacao.Token = string.Empty;
            }

            return retornoAutenticacao;
        }
    }
}
