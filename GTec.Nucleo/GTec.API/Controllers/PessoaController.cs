using GTec.API.Models;
using GTec.Nucleo.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GTec.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet]
        [Route("obtenhatodaspessoasdorepositorio")]
        public RetornoAbstrato ObtenhaTodasPublicacoesDoRepositorio([FromBody] DTOParametrosConsultaPessoas parametros)
        {
            var usuarioAutenticado = (parametros != null) || !string.IsNullOrEmpty(parametros.Token);
            var tokenValido = ValideToken(parametros.Token);
            var repositorioPessoas = new RepositorioDePessoas();

            if (usuarioAutenticado && tokenValido)
            {
                try
                {
                    var pessoas = repositorioPessoas.ObtenhaTodasPessoasDoRepositorio();
                    return RetornoPessoa.CrieRetornoListaDePessoas(pessoas);
                }
                catch (Exception erro)
                {
                    return RetornoPessoa.CrieFalhaRetornoListaDePessoas();
                }
            }

            return RetornoAutenticacao.CrieFalhaAutenticacao();
        }

        public bool ValideToken(string token)
        {
            var tokensPart = token.Split('|');
            var repositorioUsuario = new RepositorioDeUsuario();
                        
            if (repositorioUsuario.UsuarioEhValido(tokensPart[0], tokensPart[1]))
            {
                return true;
            }

            return false;
        }
    }
}