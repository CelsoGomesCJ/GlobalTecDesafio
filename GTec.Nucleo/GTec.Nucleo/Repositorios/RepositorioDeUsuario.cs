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
    public class RepositorioDeUsuario
    {
        public bool UsuarioEhValido(Usuario usuario)
        {
            using (var conexao = Conexao.Instancia.CrieConexao())
            {
                using (var comando = conexao.CreateCommand())
                {
                    comando.CommandText = $"SELECT * FROM USUARIOS WHERE NOME = '{usuario.Nome}' AND SENHA = '{usuario.Senha}'";

                    using (DbDataReader dataReader = comando.ExecuteReader())
                    {
                        return dataReader.Read();
                    }
                }
            }
        }

        public void RegistreUsuario(Usuario usuario)
        {
            using (var conexao = Conexao.Instancia.CrieConexao())
            {
                using (var comando = conexao.CreateCommand())
                {
                    comando.CommandText = @"INSERT INTO USUARIOS (NOME, SENHA) VALUES(@NOME, @SENHA)";

                    comando.Parameters.Add(CrieParametro("@NOME", NpgsqlDbType.Varchar, 250));
                    comando.Parameters.Add(CrieParametro("@SENHA", NpgsqlDbType.Varchar, 250));
                    comando.Prepare();
                    comando.Parameters["@NOME"].Value = usuario.Nome;
                    comando.Parameters["@SENHA"].Value = usuario.Senha;
                    comando.ExecuteNonQuery();
                }
            }
        }

        private NpgsqlParameter CrieParametro(string campo, NpgsqlDbType tipo, int size)
        {
            return new NpgsqlParameter(campo, tipo, size);
        }
    }
}
