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