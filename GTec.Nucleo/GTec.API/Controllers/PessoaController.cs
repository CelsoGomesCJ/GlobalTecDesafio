using GTec.API.Models;
using GTec.Nucleo.Negocio;
using GTec.Nucleo.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GTec.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        [HttpGet]
        [Route("obtenhapessoapelocodigo")]
        public RetornoAbstrato ObtenhaPessoasPeloCodigo([FromBody] DTOParametrosConsultaPessoas parametros)
        {
            var repositorioDePessoas = new RepositorioDePessoas();
            var usuarioAutenticado = (parametros != null) || !string.IsNullOrEmpty(parametros.Token);
            var tokenValido = ValideToken(parametros.Token);

            if (usuarioAutenticado && tokenValido)
            {
                try
                {
                    var pessoa = repositorioDePessoas.ObtenhaPessoaPorCodigo(parametros.Codigo);
                    return RetornoPessoa.CrieRetornoPessoa(pessoa);
                }
                catch (Exception erro)
                {
                    return RetornoPessoa.CrieFalhaRetornoDePessoas();
                }
            }

            return RetornoAutenticacao.CrieFalhaAutenticacao();
        }


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
                    return RetornoPessoa.CrieFalhaRetornoDePessoas();
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