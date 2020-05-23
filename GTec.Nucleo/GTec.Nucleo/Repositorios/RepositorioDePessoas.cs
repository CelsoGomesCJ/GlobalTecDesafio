using GTec.Nucleo.Negocio;
using GTec.Nucleo.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace GTec.Nucleo.Repositorios
{
    public class RepositorioDePessoas
    {
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

        private Pessoa MapeiePessoa(DbDataReader dr)
        {
            var pessoa = new Pessoa();
            pessoa.Codigo = dr.GetInt64(0);
            pessoa.Nome = dr.GetString(1);
            pessoa.CPF = new CPF(dr.GetString(2));
            pessoa.DataDeNascimento = dr.GetDateTime(3);

            return pessoa;
        }
    }
}
