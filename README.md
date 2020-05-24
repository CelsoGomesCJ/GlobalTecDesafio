# GlobalTecDesafio
Desafio para GlobalTec

**# Resposta desafio parte 2, consulta SQL**

Coloquei apenas a consulta SQL os comandos DDL das tabelas se vocês quiserem também eu envio

> SELECT Nome, CP.Numero, CP.CodigoFornecedor, CP.DataVencimento, CP.DataPagamento, CP.Valor, 'Conta Paga' as Identificador
FROM ContasPagas CP
JOIN Pessoas ON Codigo = CodigoFornecedor
UNION ALL
SELECT Nome, CA.Numero, CA.CodigoFornecedor, CA.DataVencimento, null, CA.Valor, 'Conta A Pagar' as Identificador 
FROM ContasAPagar CA
JOIN Pessoas ON Codigo = CodigoFornecedor
ORDER BY NUMERO
