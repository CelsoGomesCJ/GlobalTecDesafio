using GTec.API.Models;
using GTec.Nucleo.Negocio;
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
        //Registrar Pessoa
        [HttpPost]
        [Route("registrarpessoa")]
        public RetornoAbstrato registrePessoa([FromBody] ParametrosPessoas parametros)
        {
            var repositorioDePessoas = new RepositorioDePessoas();
            var usuarioAutenticado = (parametros != null) || !string.IsNullOrEmpty(parametros.Token);
            var tokenValido = ValideToken(parametros.Token);

            if (usuarioAutenticado && tokenValido)
            {
                try
                {
                    var pessoa = new Pessoa(parametros.Nome, parametros.CPF, parametros.DataDeNascimento, parametros.CodigoCidade);
                    repositorioDePessoas.registrePessoa(pessoa);
                    return RetornoPessoa.CrieSucessoRetornoRegistroDePessoas(pessoa);
                }
                catch (Exception erro)
                {
                    return RetornoPessoa.CrieFalhaRetornoRegistroDePessoas(erro);
                }
            }

            return RetornoAutenticacao.CrieFalhaAutenticacao();

        }

        [HttpGet]
        [Route("obtenhapessoaspelocodigoUF")]
        public RetornoAbstrato ObtenhaPessoasPeloCodigoUF([FromBody] ParametrosPessoas parametros)
        {
            var repositorioDePessoas = new RepositorioDePessoas();
            var usuarioAutenticado = (parametros != null) || !string.IsNullOrEmpty(parametros.Token);
            var tokenValido = ValideToken(parametros.Token);

            if (usuarioAutenticado && tokenValido)
            {
                try
                {
                    var pessoa = repositorioDePessoas.ObtenhaPessoasPorCodigoUF(parametros.CodigoCidade);
                    return RetornoPessoa.CrieRetornoConsultaListaDePessoas(pessoa);
                }
                catch (Exception erro)
                {
                    return RetornoPessoa.CrieFalhaRetornoConsultaDePessoas();
                }
            }

            return RetornoAutenticacao.CrieFalhaAutenticacao();
        }

        [HttpGet]
        [Route("obtenhapessoapelocodigo")]
        public RetornoAbstrato ObtenhaPessoasPeloCodigo([FromBody] ParametrosPessoas parametros)
        {
            var repositorioDePessoas = new RepositorioDePessoas();
            var usuarioAutenticado = (parametros != null) || !string.IsNullOrEmpty(parametros.Token);
            var tokenValido = ValideToken(parametros.Token);

            if (usuarioAutenticado && tokenValido)
            {
                try
                {
                    var pessoa = repositorioDePessoas.ObtenhaPessoaPorCodigo(parametros.Codigo);
                    return RetornoPessoa.CrieRetornoConsultaPessoa(pessoa);
                }
                catch (Exception erro)
                {
                    return RetornoPessoa.CrieFalhaRetornoConsultaDePessoas();
                }
            }

            return RetornoAutenticacao.CrieFalhaAutenticacao();
        }


        [HttpGet]
        [Route("obtenhatodaspessoasdorepositorio")]
        public RetornoAbstrato ObtenhaTodasPublicacoesDoRepositorio([FromBody] ParametrosPessoas parametros)
        {
            var usuarioAutenticado = (parametros != null) || !string.IsNullOrEmpty(parametros.Token);
            var tokenValido = ValideToken(parametros.Token);
            var repositorioPessoas = new RepositorioDePessoas();

            if (usuarioAutenticado && tokenValido)
            {
                try
                {
                    var pessoas = repositorioPessoas.ObtenhaTodasPessoasDoRepositorio();
                    return RetornoPessoa.CrieRetornoConsultaListaDePessoas(pessoas);
                }
                catch (Exception erro)
                {
                    return RetornoPessoa.CrieFalhaRetornoConsultaDePessoas();
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