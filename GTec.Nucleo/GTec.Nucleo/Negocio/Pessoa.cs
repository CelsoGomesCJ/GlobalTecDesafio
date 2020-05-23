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
        public CPF CPF { get; set; }
        public DateTime DataDeNascimento { get; set; }
    }
}
