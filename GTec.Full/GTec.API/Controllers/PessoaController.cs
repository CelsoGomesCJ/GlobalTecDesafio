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

        [HttpGet]
        [Route("obtenhapessoaspelocodigoUF")]
        public RetornoAbstrato ObtenhaPessoasPeloCodigoUF([FromBody] DTOParametrosPessoa parametros)
        {
            var requisicaoValida = ValideRequisicao(parametros);

            if (requisicaoValida)
            {
                var repositorioDePessoas = new RepositorioDePessoas();

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
        public RetornoAbstrato ObtenhaPessoasPeloCodigo([FromBody] DTOParametrosPessoa parametros)
        {
            var requisicaoValida = ValideRequisicao(parametros);

            if (requisicaoValida)
            {
                var repositorioDePessoas = new RepositorioDePessoas();

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
        public RetornoAbstrato ObtenhaTodasPublicacoesDoRepositorio([FromBody] DTOParametrosPessoa parametros)
        {
            var requisicaoValida = ValideRequisicao(parametros);

            if (requisicaoValida)
            {
                var repositorioDePessoas = new RepositorioDePessoas();

                try
                {
                    var pessoas = repositorioDePessoas.ObtenhaTodasPessoasDoRepositorio();
                    return RetornoPessoa.CrieRetornoConsultaListaDePessoas(pessoas);
                }
                catch (Exception erro)
                {
                    return RetornoPessoa.CrieFalhaRetornoConsultaDePessoas();
                }
            }

            return RetornoAutenticacao.CrieFalhaAutenticacao();
        }

        [HttpPut]
        [Route("atualizar")]
        public RetornoAbstrato atualizarPessoa([FromBody] DTOParametrosPessoa parametros)
        {
            var requisicaoValida = ValideRequisicao(parametros);
           
            if (requisicaoValida)
            {
                var repositorioDePessoas = new RepositorioDePessoas();

                try
                {
                    var pessoa = new Pessoa(parametros.Nome, parametros.CPF, parametros.DataDeNascimento, parametros.CodigoCidade);
                    pessoa.Codigo = parametros.Codigo;
                    repositorioDePessoas.atualizarPessoa(pessoa);
                    return RetornoPessoa.CrieSucessoRetornoRegistroDePessoas(pessoa);
                }
                catch (Exception erro)
                {
                    return RetornoPessoa.CrieFalhaRetornoRegistroDePessoas(erro);
                }
            }

            return RetornoAutenticacao.CrieFalhaAutenticacao();
        }

        //Excluir Pessoa
        [HttpDelete]
        [Route("excluir")]
        public RetornoAbstrato excluirPessoa([FromBody] DTOParametrosPessoa parametros)
        {
            var requisicaoValida = ValideRequisicao(parametros);

            if (requisicaoValida)
            {
                var repositorioDePessoas = new RepositorioDePessoas();

                try
                {
                    repositorioDePessoas.ExcluirPessoaPeloId(parametros.Codigo);
                    return RetornoPessoa.CrieSucessoRetornoExclusaoDePessoa();
                }
                catch (Exception erro)
                {
                    return RetornoPessoa.CrieFalhaRetornoExclusaoDePessoa();
                }
            }

            return RetornoAutenticacao.CrieFalhaAutenticacao();
        }

        //Registrar Pessoa
        [HttpPost]
        [Route("registrar")]
        public RetornoAbstrato registrePessoa([FromBody] DTOParametrosPessoa parametros)
        {
            var requisicaoValida = ValideRequisicao(parametros);

            if (requisicaoValida)
            {
                var repositorioDePessoas = new RepositorioDePessoas();

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

        private bool ValideRequisicao(DTOParametrosPessoa parametros)
        {
            var usuarioAutenticado = (parametros != null) || !string.IsNullOrEmpty(parametros.Token);
            var tokenValido = ValideToken(parametros.Token);

            return usuarioAutenticado && tokenValido;
        }


        public bool ValideToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                return false;

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