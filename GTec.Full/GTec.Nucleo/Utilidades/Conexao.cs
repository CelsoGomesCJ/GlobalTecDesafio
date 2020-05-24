using Npgsql;
using System;
using System.Data.Common;

namespace GTec.Nucleo.Utilidades
{
    public class Conexao
    {
        public static Conexao Instancia = new Conexao();
        private readonly string _stringConexao;

        public Conexao()
        {
            _stringConexao = CrieStringConexao();
        }

        //String de conexão banco de dados Local
        //private string CrieStringConexao()
        //{

        //    var sbConnectionString = new NpgsqlConnectionStringBuilder()
        //    {
        //        Host = "localhost",
        //        Port = 5432,
        //        Username = "postgres",
        //        Password = "root",
        //        Database = "globaltec",
        //    };
        //    return sbConnectionString.ToString();
        //}
            
        //String de conexão base de dados na nuvem Heroku
        private string CrieStringConexao()
        {
            var sbConnectionString = new NpgsqlConnectionStringBuilder()
            {
                Host = "ec2-35-169-254-43.compute-1.amazonaws.com",
                Port = 5432,
                Username = "plusagiidsboue",
                Password = "a17f09f3748137a1924aa2ad07caf6f8f0a4e26f96049ca835e0afe749190c52",
                Database = "dd5dh6iucquukh",
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };

            return sbConnectionString.ToString();
        }

        public DbConnection CrieConexao()
        {
            try
            {
                var connection = new NpgsqlConnection(_stringConexao);
                connection.Open();
                return connection;
            }
            catch (Exception message)
            {
                throw new Exception($"Falha ao abrir conexão com banco de dados. {message}");
            }
        }
    }
}
