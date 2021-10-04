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