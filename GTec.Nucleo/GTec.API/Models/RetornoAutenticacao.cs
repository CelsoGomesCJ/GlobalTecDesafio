using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTec.API.Models
{
    public class RetornoAutenticacao
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
        public string Token { get; set; }
    }
}
