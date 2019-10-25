
# Rebus e Azure Service Bus 
https://github.com/rebus-org/Rebus/wiki/Getting-started

A solu��o permite enviar mensagens � um t�pico do azure service bus atrav�s da bibliteca do rebus e sem a mesma.

## Rebus.Consumer

Worker que recebe todas as mensagens do t�pico

## Rebus.Producer

Console que envia mensagens para o t�pico utilizando as bibliotecas do rebus

## ServiceBus.Procuder

Console que envia mensagens para o t�pico utilizando as bibliotecas do azure service bus

OBS: 
- � necess�rio seguir o envelopamento do rebus para o consumidor conseguir interpretar a mensagem
https://github.com/rebus-org/Rebus/blob/master/Rebus/Messages/Headers.cs

## Importante

- Em todas os casos � necess�rio respeitar o rbs2-msg-type que deve corresponder ao namespace da interface que representa a mensagem:
Para isso, foi utilizada uma biblioteca compartilhada de contratos


- � necess�rio que a conta presente na connection string do azure service bus tenha permiss�o de adminstrador porque o rebus cria os recursos necess�rios para seu funcionamento.
- Ou � poss�vel criar os recursos previamente: Fila rebus-consumer, Fila de erro topicolokoerro, T�pico topicoloko

## Execu��o

Preencher a connection string do Azure Service Bus nos projetos

Em seguida � poss�vel iniciar todos os projetos.
