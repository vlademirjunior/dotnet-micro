O Padrão repository ele separa a lógica de acesso a dados e mapeia essa lógica para entidades na lógica de negócio.
No padrão repository as entidades de domínio e lógica de acesso a dados se comunicam utilizando as interfaces e isso esconde os detalhes de acesso a dados da camada de negócio.

Podemos dizer que o repository é um serviço do domínio que abstrai a camada de persistencia da sua aplicação com a tua api para os serviço da sua aplicação "Controladores".

Implementamos um repository especifico e não genérico.

____________________________
dotnet new webapi --no-https true -f net5.0 -n Catalog.API
dotnet new webapi --no-https true -f net5.0 -n Basket.API


docker pull mongo
docker run -d -p 27017:27017 --name catalog-mongo mongo
docker exec -it catalog-mongo /bin/bash
mongo
show dbs;
use ProductDb;
db.createCollection('Products');
db.Products.insert({"name":"vlademir"});
db.Products.find({}).pretty();
db.Products.remove({});


____________

docker run --name local-redis -p 6379:6379 -d redis
docker exec -it local-redis bash
redis-cli
set name bem-vindo
get name
ping
incr contador
incr contador
get contador

_______________________________________________

gRPC
Formato de mensagem = Protobuf
Versão HTTP = HTTP 2
Geração de código nativo em vez de usar ferramentas de terceiros
Implementação mais lenta que REST

O gRPC ainda não foi amplamente adotado  e a maioria das ferramentas de terceiros continua sem recursos integrados para compatibilidade do gRPC.

______________________

A integração do gRPC com a plataforma .NET foi feita na versão 3.0 do .NET core SDK
o SDK inclui ferramentas para roteamento de endpoint, IoC interno e registro em log
O servidor Web Kestrel de código aberto dá suporte a conexões HTTP/2
- Visual Studio 19 v16.3 ou superior
- VSCode
- CLI do dotnet

Ser mais rápido que o REST, usa uma LINGUAGEM DE DEFINIÇÂO DE INTERFACES (IDL) conhecida como PROTOCOL BUFFERS (PROTOBUF) pode ser usado em diversas linguagens ao mesmo tempo.

Protocol Buffers ou protobuf são métodos de serialização/deserialização de dados que funcionam através da IDL:
- É agnóstico de plataforma
- Permite fazer especificação e m uma linguagem neutra (o próprio proto)
- Permite compilar o contrato em vários outros serviços
- Sendo apenas um descritivo de um serviço

O serviço gRPC é um conjunto de métodos (classe) que podem ser descrito com seus parâmetros de ntradas e saídas.

As mensagens serializadas com protobuf são enviadas no formato binário (mais rápida e menor uso de CPU).

Uma classe DiscountService é equivalente ao DiscountController do REST.

________________________________________________________________________________________________

O Recurso connected services ou serviços conectados do visual studio permite conectar uma aplicação a provedores de serviços que são executados na nuvem ou localmente automatizando várias etapas necessárias para conectar um projeto do visual studio a um serviço.

O Visual Studio Connected Services usa NSwag para gerar clientes fortemente tipados a partir de documentos especifação OpenAPI e cliente ou servidores gRPC a partir de arquivos proto.

Vamos usar este recurso para usar os serviços gRPC definidos no microsserviço Discount.Grpc para gerar um Client para API Restful definida no microsserviço Basket.API
_________________________________________________________________________________________________



