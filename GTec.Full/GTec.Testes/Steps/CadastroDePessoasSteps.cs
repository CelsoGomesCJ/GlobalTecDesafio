using GTec.Nucleo.Negocio;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace GTec.Testes.Steps
{
    [Binding]
    public sealed class CadastroDePessoasSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private readonly ScenarioContext context;
        private TestDelegate _resultado;

        public CadastroDePessoasSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }
               
        [When(@"crio uma pessoa sem informar um CPF Válido")]
        public void QuandoCrioUmaPessoaSemInformarUmCPFValido()
        {
            _resultado = () => new Pessoa("Celso","7019735916", "1997-05-22", 4);
        }

        [Then(@"vejo que é obrigatório informar um CPF Válido")]
        public void EntaoVejoQueEObrigatorioInformarUmCPFValido()
        {
            Assert.That(_resultado, Throws.Exception.With.Message.EqualTo("Cpf inválido"));
        }

        [When(@"crio uma pessoa sem informar uma Data de Nascimento Válida")]
        public void QuandoCrioUmaPessoaSemInformarUmaDataDeNascimentoValida()
        {
            _resultado = () => new Pessoa("Celso", "7019735916", "2020-05-28", 4);
        }

        [Then(@"vejo que é obrigatório informar uma Data de Nascimento Válida")]
        public void EntaoVejoQueEObrigatorioInformarUmaDataDeNascimentoValida()
        {
            Assert.That(_resultado, Throws.Exception);
        }

        [When(@"crio uma pessoa sem informar um nome")]
        public void QuandoCrioUmaPessoaSemInformarUmNome()
        {
            _resultado = () => new Pessoa("", "7019735916", "1997-05-22", 4);
        }

        [Then(@"vejo que é obrigatório informar um nome")]
        public void EntaoVejoQueEObrigatorioInformarUmNome()
        {
            Assert.That(_resultado, Throws.Exception);
        }


    }
}
