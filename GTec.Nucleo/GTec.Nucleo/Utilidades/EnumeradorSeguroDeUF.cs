using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GTec.Nucleo.Utilidades
{
    public class EnumeradorSeguroDeUF
    {
        public static EnumeradorSeguroDeUF Acre = new EnumeradorSeguroDeUF(1, "AC", "Acre", 12);
        public static EnumeradorSeguroDeUF Alagoas = new EnumeradorSeguroDeUF(2, "AL", "Alagoas", 27);
        public static EnumeradorSeguroDeUF Amazonas = new EnumeradorSeguroDeUF(3, "AM", "Amazonas", 13);
        public static EnumeradorSeguroDeUF Amapa = new EnumeradorSeguroDeUF(4, "AP", "Amapá", 16);
        public static EnumeradorSeguroDeUF Bahia = new EnumeradorSeguroDeUF(5, "BA", "Bahia", 29);
        public static EnumeradorSeguroDeUF Ceara = new EnumeradorSeguroDeUF(6, "CE", "Ceará", 23);
        public static EnumeradorSeguroDeUF DistritoFederal = new EnumeradorSeguroDeUF(7, "DF", "Distrito Federal", 53);
        public static EnumeradorSeguroDeUF EspiritoSanto = new EnumeradorSeguroDeUF(8, "ES", "Espirito Santo", 32);
        public static EnumeradorSeguroDeUF Goias = new EnumeradorSeguroDeUF(9, "GO", "Goiás", 52);
        public static EnumeradorSeguroDeUF Maranhao = new EnumeradorSeguroDeUF(10, "MA", "Maranhão", 21);
        public static EnumeradorSeguroDeUF MinasGerais = new EnumeradorSeguroDeUF(11, "MG", "Minas Gerais", 31);
        public static EnumeradorSeguroDeUF MatoGrossoDoSul = new EnumeradorSeguroDeUF(12, "MS", "Mato Grosso do Sul", 50);
        public static EnumeradorSeguroDeUF MatoGrosso = new EnumeradorSeguroDeUF(13, "MT", "Mato Grosso", 51);
        public static EnumeradorSeguroDeUF Para = new EnumeradorSeguroDeUF(14, "PA", "Pará", 15);
        public static EnumeradorSeguroDeUF Paraiba = new EnumeradorSeguroDeUF(15, "PB", "Paraíba", 25);
        public static EnumeradorSeguroDeUF Pernambuco = new EnumeradorSeguroDeUF(16, "PE", "Pernambuco", 26);
        public static EnumeradorSeguroDeUF Piaui = new EnumeradorSeguroDeUF(17, "PI", "Piauí", 22);
        public static EnumeradorSeguroDeUF Parana = new EnumeradorSeguroDeUF(18, "PR", "Paraná", 41);
        public static EnumeradorSeguroDeUF RioDeJaneiro = new EnumeradorSeguroDeUF(19, "RJ", "Rio de Janeiro", 33);
        public static EnumeradorSeguroDeUF RioGrandeDoNorte = new EnumeradorSeguroDeUF(20, "RN", "Rio Grande do Norte", 24);
        public static EnumeradorSeguroDeUF Rondonia = new EnumeradorSeguroDeUF(21, "RO", "Rondônia", 11);
        public static EnumeradorSeguroDeUF Roraima = new EnumeradorSeguroDeUF(22, "RR", "Roraima", 14);
        public static EnumeradorSeguroDeUF RioGrandeDoSul = new EnumeradorSeguroDeUF(23, "RS", "Rio Grande do Sul", 43);
        public static EnumeradorSeguroDeUF SantaCatarina = new EnumeradorSeguroDeUF(24, "SC", "Santa Catarina", 42);
        public static EnumeradorSeguroDeUF Sergipe = new EnumeradorSeguroDeUF(25, "SE", "Sergipe", 28);
        public static EnumeradorSeguroDeUF SaoPaulo = new EnumeradorSeguroDeUF(26, "SP", "São Paulo", 35);
        public static EnumeradorSeguroDeUF Tocantins = new EnumeradorSeguroDeUF(27, "TO", "Tocantins", 17);
        public static EnumeradorSeguroDeUF Estrangeiro = new EnumeradorSeguroDeUF(28, "ET", "Estrangeiro", 0);

        public string Descricao { get; set; }
        public string Sigla { get; private set; }
        public int CodigoIBGE { get; private set; }
        public int Id { get; set; }

        private EnumeradorSeguroDeUF(int id, string sigla, string descricao, int codigoIBGE)
        {
            Sigla = sigla;
            CodigoIBGE = codigoIBGE;
            Id = id;
            Descricao = descricao;
        }

        public static EnumeradorSeguroDeUF ObtenhaCidadePorId(int id)
        {
            var todos = ObtenhaTodos();

            foreach (var item in todos)
            {
                if (item.Id.Equals(id)) 
                    return item;
            }

            return null;
        }

        public static List<EnumeradorSeguroDeUF> ObtenhaTodos()
        {
            var tipo = typeof(EnumeradorSeguroDeUF);
            return tipo.GetFields(BindingFlags.Static | BindingFlags.Public).Select(campo => (EnumeradorSeguroDeUF)campo.GetValue(null)).ToList();
        }
    }
}
