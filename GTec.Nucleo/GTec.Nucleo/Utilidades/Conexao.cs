﻿using System;
using System.Data.Common;

namespace GTec.Nucleo.Utilidades
{
    public class Conexao
    {
        public static Conexao Instancia = new Conexao();
        //private readonly string _stringConexao;

        //public Conexao()
        //{
        //    _stringConexao = CrieStringConexao();
        //}

        //private string CrieStringConexao()
        //{
        //    var sbConnectionString = new NpgsqlConnectionStringBuilder()
        //    {
        //        Host = "localhost",
        //        Port = 5432,
        //        Username = "postgres",
        //        Password = "root",
        //        Database = "globaltec",
        //        SslMode = SslMode.Require,
        //        TrustServerCertificate = true
        //    };

        //    return sbConnectionString.ToString();

        //}

        //public DbConnection CrieConexao()
        //{
        //    try
        //    {
        //        var connection = new NpgsqlConnection(_stringConexao);
        //        connection.Open();
        //        return connection;
        //    }
        //    catch (Exception message)
        //    {
        //        throw new Exception($"Falha ao abrir conexão com banco de dados. {message}");
        //    }
        //}
    }
}