[![N|Logo Uniplac](https://uniplaclages.edu.br/assets/img/logo.png)](https://github.com/GabrielSchenato/)
------------

<p align="center">Schenato Carros</p>


------------


#### - Estórias de Usuário

#### ID:001
> Como recepcionista da Schenato Carros eu gostaria de um sistema de auxiliasse nas locações dos automóveis.

------------


**Dado:** Informações obrigatórias e válidas para locação.</br>
**Quando:** Recepcionista da Schenato Carros for alugar automóveis.</br>
**Então:** O recepcionista vai saber quanto os alugueis vão custar e se o cliente tem uma renda.</br>

------------


#### ID:002
> Como recepcionista da Schenato Carros eu gostaria de poder manter os dados do meu cliente físico.

------------


**Dado:** Nome completo, telefone, endereço, CPF, data nascimento e renda.</br>
-Todos os campos acima devem ser validados, principalmente o CPF e a renda.</br>
**Quando:** Recepcionista da Schenato Carros for manter os dados do cliente físico.</br>
**Então:** Dados do cliente físico atuais.</br>

------------


#### ID:003
> Como recepcionista da Schenato Carros eu gostaria de poder manter os dados do cliente jurídico.

------------


**Dado:** Nome completo, telefone, endereço, CNPJ.</br>
-Todos os dados acima devem ser validados, principalmente o CNPJ da empresa para verificar antecedências. </br>
**Quando:** Recepcionista da Schenato Carros for manter os dados do cliente jurídico.</br>
**Então:** Dados do cliente jurídico atuais.</br>

------------


#### ID:004
> Como recepcionista da Schenato Carros eu gostaria de poder manter os dados de um automóvel.

------------


**Dado:** Nome, potência, placa, km e valor do aluguel por dia.</br>
-Todos os dados acima devem ser validados, a potência não pode ter valores negativos, a placa do automóvel deve ser validade juntamente ao órgão regulamentador, e o valor do aluguel por dia deve ser um valor calculado com base no ano do veículo, na km e modelo. </br>
**Quando:** Recepcionista da Schenato Carros for manter os dados do automóvel.</br>
**Então:** Dados do automóvel atuais.</br>

------------


#### ID:005
> Como recepcionista da Schenato Carros eu gostaria de poder manter o cadastro de um aluguel.

------------


**Dado:** Cliente seja ele físico ou jurídico, dados do automóvel escolhido, data de início e data de fim.</br>
-Todos os dados acima devem ser validados antes de prosseguir com a locação. A data início não pode ser maior que a data final. O sistema deve emitir um alerta quando a data de fim estiver próxima. </br>
**Quando:** Recepcionista da Schenato Carros for manter dados de um aluguel.</br>
**Então:** O recepcionista da Schenato Carros vai saber o valor final da locação do veículo e para quem vai ser locado, e os documentos para assinaturas devem estar prontos logo em seguida.</br>