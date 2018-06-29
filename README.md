[![N|Logo Uniplac](https://uniplaclages.edu.br/assets/img/logo.png)](https://github.com/GabrielSchenato/)
------------

<p align="center">Schenato Carros</p>


------------


#### - Est�rias de Usu�rio

#### ID:001
> Como recepcionista da Schenato Carros eu gostaria de um sistema de auxiliasse nas loca��es dos autom�veis.

------------


**Dado:** Informa��es obrigat�rias e v�lidas para loca��o.</br>
**Quando:** Recepcionista da Schenato Carros for alugar autom�veis.</br>
**Ent�o:** O recepcionista vai saber quanto os alugueis v�o custar e se o cliente tem uma renda.</br>

------------


#### ID:002
> Como recepcionista da Schenato Carros eu gostaria de poder manter os dados do meu cliente f�sico.

------------


**Dado:** Nome completo, telefone, endere�o, CPF, data nascimento e renda.</br>
-Todos os campos acima devem ser validados, principalmente o CPF e a renda.</br>
**Quando:** Recepcionista da Schenato Carros for manter os dados do cliente f�sico.</br>
**Ent�o:** Dados do cliente f�sico atuais.</br>

------------


#### ID:003
> Como recepcionista da Schenato Carros eu gostaria de poder manter os dados do cliente jur�dico.

------------


**Dado:** Nome completo, telefone, endere�o, CNPJ.</br>
-Todos os dados acima devem ser validados, principalmente o CNPJ da empresa para verificar anteced�ncias. </br>
**Quando:** Recepcionista da Schenato Carros for manter os dados do cliente jur�dico.</br>
**Ent�o:** Dados do cliente jur�dico atuais.</br>

------------


#### ID:004
> Como recepcionista da Schenato Carros eu gostaria de poder manter os dados de um autom�vel.

------------


**Dado:** Nome, pot�ncia, placa, km e valor do aluguel por dia.</br>
-Todos os dados acima devem ser validados, a pot�ncia n�o pode ter valores negativos, a placa do autom�vel deve ser validade juntamente ao �rg�o regulamentador, e o valor do aluguel por dia deve ser um valor calculado com base no ano do ve�culo, na km e modelo. </br>
**Quando:** Recepcionista da Schenato Carros for manter os dados do autom�vel.</br>
**Ent�o:** Dados do autom�vel atuais.</br>

------------


#### ID:005
> Como recepcionista da Schenato Carros eu gostaria de poder manter o cadastro de um aluguel.

------------


**Dado:** Cliente seja ele f�sico ou jur�dico, dados do autom�vel escolhido, data de in�cio e data de fim.</br>
-Todos os dados acima devem ser validados antes de prosseguir com a loca��o. A data in�cio n�o pode ser maior que a data final. O sistema deve emitir um alerta quando a data de fim estiver pr�xima. </br>
**Quando:** Recepcionista da Schenato Carros for manter dados de um aluguel.</br>
**Ent�o:** O recepcionista da Schenato Carros vai saber o valor final da loca��o do ve�culo e para quem vai ser locado, e os documentos para assinaturas devem estar prontos logo em seguida.</br>