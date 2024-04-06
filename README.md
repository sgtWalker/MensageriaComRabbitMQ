# MensageriaComRabbitMQ
Projeto utilizado para fidelizar o conhecimento adquirido durante as aulas do curso de RabbitMQ com .Net do professor Luis Dev.

# Documentação do RabbitMQ
https://www.rabbitmq.com/tutorials

# Informações Adicionais
Foi implementado o pattern publisher/subscriber utilizando exchange do tipo topic no RabbitMQ.

# Instalação do RabbitMQ (Podman)
podman run -d --hostname rmq --name rabbit-server -p 8080:15672 -p 5672:5672 rabbitmq:3-management

# Instalação do RabbitMQ (Docker)
docker run -d --hostname rmq --name rabbit-server -p 8080:15672 -p 5672:5672 rabbitmq:3-management

# Estrutura criada no RabbitMQ
Exchange: publisher-customers (topic)
Queue: customer-created
Binding: customer-created

# Como utilizar o projeto?
1 - Deixe o projeto Publisher.Customers.API como startup project e inicie-o;    
2 - No swagger, abra a rota POST da controller Customers;    
3 - Clique no botão Try it out e insira o body abaixo:    
    {
      "id": 1,
      "name": "Custumer Name",
      "birthDate": "2024-04-05T00:00:00.000Z"
    }    
4 - Clique no botão Execute para enviar a requisição;    
5 - Acesse o painel do RabbitMQ (localhost:8080);    
6 - Verifique se a estrutura citada no tópico anterior está criada e com a mensagem enviada pelo POST na fila;    
7 - Se a mensagem estiver na fila, pare a execução do projeto;    
8 - Execute o projeto Subscriber.Marketing.API e verifique o console, pois, quando a mensagem for consumida o consumidor logará a mensagem no console do projeto;    

