using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GTec.Nucleo.Negocio;
using GTec.API.Models;
using GTec.Nucleo.Repositorios;
using GTec.Nucleo.Utilidades;

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
            
            var mapeadorLogin = new RepositorioDeUsuario();
            mapeadorLogin.UsuarioEhValido(usuario.Nome, usuario.Senha);

            //var hashSenha = Criptografia.ObtenhaHashSha256(usuario.Senha);
            //var hashSenha = Utilidades.ObtenhaHashSha256(discente.senha);
            //discente.senha = hashSenha;

            //if (mapeadorLogin.UsuarioEhValido(discente.email, discente.senha))
            //{
            //    var retorno = RetornoPadrao.CrieSucessoLogin();
            //    retorno.Result = mapeadorDiscente.ObtenhaDiscente(discente.email, discente.senha);
            //    return retorno;
            //}

            //return RetornoPadrao.CrieFalhaLogin();

            return new RetornoAutenticacao();

        }

        ////Realize Login
        //[HttpPost]
        //[Route("registrarusuario")]
        //public RetornoPadrao RegistrarUsuario([FromBody] Discente discente)
        //{
        //    var mapeadorDiscente = new MapeamentoDiscente();
        //    var retorno = new RetornoPadrao();

        //    var hashSenha = Utilidades.ObtenhaHashSha256(discente.senha);
        //    discente.senha = hashSenha;

        //    try
        //    {
        //        mapeadorDiscente.RegistreUsuario(discente);
        //        retorno.Codigo = 0;
        //        retorno.Mensagem = "Usuário registrado com sucesso!";
        //    }
        //    catch (Exception erro)
        //    {
        //        retorno.Codigo = 1;
        //        retorno.Mensagem = $"Falha ao criar usuário";
        //    }

        //    return retorno;
        //}
    }
}
