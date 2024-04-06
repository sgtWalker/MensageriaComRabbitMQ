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

# Body de exemplo para o post do publisher customer
{
  "id": 1,
  "name": "Custumer Name",
  "birthDate": "2024-04-05T00:00:00.000Z"
}

# Estrutura criada no RabbitMQ
Exchange: publisher-customers (topic)
Queue: customer-created
Binding: customer-created

