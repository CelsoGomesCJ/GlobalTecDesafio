
using System.Linq;

namespace GTec.Nucleo.Utilidades
{
    public class CPF
    {
        public string Numero { get; }

        public CPF(string cpf)
        {
            Numero = cpf;

            if (!string.IsNullOrEmpty(cpf))
                Numero = SomenteNumeros(cpf).PadLeft(11, '0');
        }
        public bool Valido => EhValido(Numero);
        public override string ToString() => string.IsNullOrEmpty(Numero) ? string.Empty : Numero.Length == 14 ? Numero : Numero.Insert(9, "-").Insert(6, ".").Insert(3, ".");
        public string SomenteNumeros(string valor)
        {
            return new string((from c in valor ?? string.Empty where char.IsDigit(c) select c).ToArray());
        }

        //http://www.macoratti.net/11/09/c_val1.htm
        public static bool EhValido(string cpf)
        {
            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11) return false;

            var tempCpf = cpf.Substring(0, 9);
            var soma = 0;

            for (int i = 0; i < 9; i++) soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            var resto = soma % 11;
            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            var digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (int i = 0; i < 10; i++) soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }

    }
}
