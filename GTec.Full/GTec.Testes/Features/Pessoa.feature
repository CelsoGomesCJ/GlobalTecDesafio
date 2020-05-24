#language: pt-BR

Funcionalidade: Cadastro de Pessoas
	Como operador do sistema
	Quero cadastrar novas pessoas 
	Para termos as informações destas pessoas na base de dados

	* Deve ser obrigatório informar um CPF válido;
	* Deve ser obrigatório informar uma Data de Nascimento Válida;
	* Deve ser obrigatório informar um nome;


Cenário: Obrigatoriedade de informar um CPF válido
	Quando crio uma pessoa sem informar um CPF Válido
	Então vejo que é obrigatório informar um CPF Válido 

Cenário: Obrigatoriedade de informar uma Data de Nascimento válida
	Quando crio uma pessoa sem informar uma Data de Nascimento Válida
	Então vejo que é obrigatório informar uma Data de Nascimento Válida 

Cenário: Obrigatoriedade de informar um nome
	Quando crio uma pessoa sem informar um nome
	Então vejo que é obrigatório informar um nome