using GTec.Nucleo.Negocio;
using GTec.Nucleo.Utilidades;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace GTec.Nucleo.Repositorios
{
    public class RepositorioDePessoas
    {
        public Pessoa registrePessoa(Pessoa pessoa)
        {
            using (var conexao = Conexao.Instancia.CrieConexao())
            {
                using (var comando = conexao.CreateCommand())
                {
                    comando.CommandText = @"INSERT INTO public.pessoas(NOME, CPF, DATADENASCIMENTO, CIDADE) VALUES (@NOME, @CPF, @DATADENASCIMENTO, @CIDADE);";

                    comando.Parameters.Add(CrieParametro("@NOME", NpgsqlDbType.Varchar));
                    comando.Parameters.Add(CrieParametro("@CPF", NpgsqlDbType.Varchar));
                    comando.Parameters.Add(CrieParametro("@DATADENASCIMENTO", NpgsqlDbType.Date));
                    comando.Parameters.Add(CrieParametro("@CIDADE", NpgsqlDbType.Integer));
                    comando.Prepare();
                    comando.Parameters["@NOME"].Value = pessoa.Nome;
                    comando.Parameters["@CPF"].Value = pessoa.CPF.Numero;
                    comando.Parameters["@DATADENASCIMENTO"].Value = pessoa.DataDeNascimento;
                    comando.Parameters["@CIDADE"].Value = pessoa.Cidade.Id;
                    comando.ExecuteNonQuery();
                }
            }

            return pessoa;
        }

        public List<Pessoa> ObtenhaTodasPessoasDoRepositorio()
        {
            var pessoasDoRepositorio = new List<Pessoa>();

            using (var conexao = Conexao.Instancia.CrieConexao())
            {
                using (var comando = conexao.CreateCommand())
                {
                    comando.CommandText = @"SELECT * FROM PESSOAS";

                    using (var dr = comando.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var pessoa = MapeiePessoa(dr);
                            pessoasDoRepositorio.Add(pessoa);
                        }
                    }
                }
            }

            return pessoasDoRepositorio;
        }

        public List<Pessoa> ObtenhaPessoasPorCodigoUF(int codUF)
        {
            var pessoasDoRepositorio = new List<Pessoa>();

            using (var conexao = Conexao.Instancia.CrieConexao())
            {
                using (var comando = conexao.CreateCommand())
                {
                    comando.CommandText = $"SELECT * FROM PESSOAS WHERE CIDADE = '{codUF}'";

                    using (var dr = comando.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var pessoa = MapeiePessoa(dr);
                            pessoasDoRepositorio.Add(pessoa);
                        }
                    }
                }
            }

            return pessoasDoRepositorio;
        }

        public Pessoa ObtenhaPessoaPorCodigo(long codigoUsuario)
        {
            using (var conexao = Conexao.Instancia.CrieConexao())
            {
                using (var comando = conexao.CreateCommand())
                {
                    comando.CommandText = $"SELECT * FROM PESSOAS WHERE CODIGO = '{codigoUsuario}'";

                    using (DbDataReader dataReader = comando.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            return MapeiePessoa(dataReader);
                        }
                    }
                }
            }
            return null;
        }

        private Pessoa MapeiePessoa(DbDataReader dr)
        {
            var pessoa = new Pessoa();
            pessoa.Codigo = dr.GetInt64(0);
            pessoa.Nome = dr.GetString(1);
            pessoa.CPF = new CPF(dr.GetString(2));
            pessoa.DataDeNascimento = dr.GetDateTime(3);
            pessoa.Cidade = EnumeradorSeguroDeUF.ObtenhaCidadePorId(dr.GetInt32(4));

            return pessoa;
        }

        private NpgsqlParameter CrieParametro(string campo, NpgsqlDbType tipo)
        {
            return new NpgsqlParameter(campo, tipo);
        }
    }
}
