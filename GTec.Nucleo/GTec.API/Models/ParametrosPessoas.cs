using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTec.API.Models
{
    public class ParametrosPessoas
    {
        public string Token { get; set; }
        public long Codigo { get; set; }
        public int CodigoCidade { get; set; }
        public string Nome { get; set; }
        public string DataDeNascimento { get; set; }
        public string CPF { get; set; }
    }
}
