using GTec.Nucleo.Utilidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTec.Nucleo.Negocio
{
    public class Pessoa
    {
        public long Codigo { get; set; }
        public string Nome { get; set; }
        public EnumeradorSeguroDeUF Cidade { get; set; }
        public CPF CPF { get; set; }
        public DateTime DataDeNascimento { get; set; }

        
        public Pessoa()
        {

        }

        public Pessoa(string nome, string cpf, string dataDeNascimento, int codigoCidade)
        {
            var partesData = dataDeNascimento.Split('-');
            var data = new DateTime(Convert.ToInt32(partesData[0]), Convert.ToInt32(partesData[1]), Convert.ToInt32(partesData[2]));

            if (!CPF.EhValido(cpf))
                throw new Exception("Cpf inválido");

            if (DateTime.Now < data)
                throw new Exception("Data de nascimento inválida");
            
            Nome = nome;
            Cidade = EnumeradorSeguroDeUF.ObtenhaCidadePorId(codigoCidade);
            CPF = new CPF(cpf);
            DataDeNascimento = data;

        }
    }
}
