
# Rebus e Azure Service Bus 
https://github.com/rebus-org/Rebus/wiki/Getting-started

A solução permite enviar mensagens à um tópico do azure service bus através da bibliteca do rebus e sem a mesma.

## Rebus.Consumer

Worker que recebe todas as mensagens do tópico

## Rebus.Producer

Console que envia mensagens para o tópico utilizando as bibliotecas do rebus

## ServiceBus.Procuder

Console que envia mensagens para o tópico utilizando as bibliotecas do azure service bus

OBS: 
- É necessário seguir o envelopamento do rebus para o consumidor conseguir interpretar a mensagem
https://github.com/rebus-org/Rebus/blob/master/Rebus/Messages/Headers.cs

## Importante

- Em todas os casos é necessário respeitar o rbs2-msg-type que deve corresponder ao namespace da interface que representa a mensagem:
Para isso, foi utilizada uma biblioteca compartilhada de contratos


- É necessário que a conta presente na connection string do azure service bus tenha permissão de adminstrador porque o rebus cria os recursos necessários para seu funcionamento.
- Ou é possível criar os recursos previamente: Fila rebus-consumer, Fila de erro topicolokoerro, Tópico topicoloko

## Execução

Preencher a connection string do Azure Service Bus nos projetos

Em seguida é possível iniciar todos os projetos.
