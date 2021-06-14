# DesafioFramework

Para conseguir o token de acesso a todas as rotas da API é necessário primeiro
realizar um "post" em "/user/login" informando o usuário e senha 
(Exemplo: "{"username":"admin","password":"admin"}").
Um token de acesso será retornado, o mesmo deve ser utilizado no Header passando como Key: "Authorization" e 
como Value: "Bearer <TokenRetornado>" 
Caso os dados não sejam informados corretamente o status "401 Unauthorized" será retornado.

