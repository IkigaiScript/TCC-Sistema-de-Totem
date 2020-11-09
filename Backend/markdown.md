# Documentação

Aqui será mostrado a documentação de Rotas do Projeto da IkigaiScript

# Rotas e seus Contemplantes

**Post** Login

http://localhost:5000/Logins

Utilize esta Rota para identificar o login que foi realizado para fazer o pedido

- Request

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Email             	| String            	|
| Senha             	| String            	|

- Response

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Pedido            	| Int               	|
---
**Get** Filmes/Search 

http://localhost:5000/Filmes/Seach/


Utilize essa Rota para retornar todos os filmes que estão em estreia

- Parametros 
  - Esta rota não possui parametros
---
**Get** Clientes/{id}

http://localhost:5000/Clientes/{id}

Utilize esta rota para retornar o cliente que foi responsavel pelo login

- Parametros

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|

| Id_login          	| Int               	|
---
**Get** Filmes/{id}

http://localhost:5000/Filmes/{id}

Utilize esta rota para retornar as informações do filme

- Parametros

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Id_filme          	| Int               	|

---
**Get** Ingressos

http://localhost:5000/Ingressos

Utilize esta rota para consultar as cadeiras disponiveis

- Parametros

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Id_sessao         	| Int               	|

- Response

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Fileira           	| Char              	|
| Poltrona          	| Int               	|

---

**Get** Sessao

http://localhost:5000/Sessao/

Utilize esta rota para consultar as informações da sessao do filme

- Parametros

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Id_sessao         	| Int               	|

- Response

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Valor             	| Float             	|
| TipoSala          	| String            	|
| Horario           	| Datetime          	|
| Filme             	| Int               	|

| Sala              	| Int               	|
---
**Post** Ingressos

http://localhost:5000/Ingressos

Utilize esta rota para inserir os ingresso ao pedido

- Request

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Sessão            	| int               	|
| Fileira           	| char              	|
| Poltrona          	| int               	|
| Pedido            	| int               	|
| MeiaEntrada       	| bool              	|

- Response

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Fileira           	| Char              	|
| Poltrona          	| Int               	|
---
**Get** SnackBars

http://localhost:5000/SnackBars/ 

Utilize esta rota para consultar todos os itens de um determimado tipo

- Parametros

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
|  Ds_tipo_produto  	| String            	|

- Response

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Id                	| Int               	|
| Nome              	| String            	|
| Peso              	| String            	|
| Sabor             	| String            	|
| Imagem            	| String            	|
| Preco             	| Decimal           	|
---
**Post** Pedidos/SnackBar

http://localhost:5000/Pedidos/SnackBars/

Utilize esta rota para inserir todos os lanches selecionados na tela

- Request

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Pedido            	| Int               	|
| Qtd               	| int               	|
| SnackBar          	| Int               	|

- Response

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Id                	| Int               	|
---
**Get** Combos

http://localhost:5000/Combos/

Utilize esta rota para consultar todos os combos oferecidos pelo cinema

- Parametros
   - Nao Possui parametros

- Response

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Id                	| Int               	|
| Imagem            	| String            	|
| First             	| String            	|
| Secondary         	| String            	|
| Third             	| String            	|
| Nome              	| String            	|
| Preco             	| Float             	|
---
**Post** Pedidos/Combos

Uilize esta rota para inserir todos os combos selecionados pelo cliente

- Request

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Qtd               	| Int               	|
| Combo             	| Int               	|
| Pedido            	| Int               	|

- Response

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Id                	| Int               	|
---

**Get** SnackBar/Fotos/{nome}

http://localhost:5000/SnackBars/Fotos/{nome}

Utilize esta rota para consultar a imagem do produto 

- Parametro

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Ds_imagem         	| String            	|

- Response

//nao sei o que colocar
---
**Get** Combos/Fotos/{nome}

http://localhost:5000/Combos/Fotos/{nome}

Utilize esta rota para consultar a imagem do combo

- Parametros

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Ds_imagem         	| String            	|

- Response 

//nao sei o que colocar
---
**Get** Filmes/Seach?classificacao=&sala=&genero=/

http://localhost:5000/Filmes/Seach?classificacao=&sala=&genero=/

Utilize esta rota para buscar o filme pela classificacao,  tipo da sala e genero

- Parametros

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Nr_classificacao  	| int               	|
| Ds_genero         	| String            	|
| Ds_tipo_sala      	| String            	|

- Response

//nao sei
---
**Get** Filmes/Seach/{nome}

Utilize esta rota para fazer uma busca parcial pelo nome do filme

- Parametros

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Ds_nome           	| String            	|

- Response

//nao sei 
---
**Put** Pedidos{id}

Utilize esta rota para alterar o pedido

- Parametros 

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Ds_nome           	| String            	|

- Request

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Titular           	| String            	|
| Status            	| String            	|
| FormaPagamento    	| String            	|

- Response

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Login             	| Int               	|
| Id                	| Int               	|
---
**Delete** Pedido/{id}

Utilize esta rota para deletar o pedido junto com todos os itens do pedido como lanches, combo

- Parametros

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Ds_nome           	| String            	|

- Response

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Login             	| Int               	|
| Id                	| Int               	|
---
**Post** Cartoes

http://localhost:5000/Cartoes/

Utilize esta rota para inserir um novo registro de cartão para o pedido

- Request 

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Numero            	| String            	|
| Cvv               	| Int               	|
| Senha             	| Int               	|
| Pedido            	| Int               	|
| Pagamento         	| String            	|

- Response

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Id                	| Int               	|
| Pedido            	| Int               	|
| Numero            	| String            	|
| Gasto             	| Float             	|
---
**Post** Notas/Email/{pedido}

http://localhost:5000/Notas/Email/{pedido}

Utilize esta rota para enviar um email com uma nota fiscal

- Parametros

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Id_pedido         	| Int               	|

-Response

//nao sei
---
**Get** Cupons

Utilize esta rota para validar cupom de desconto e inserir ao pedido

- Parametro

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Ds_codigo         	| String            	|
| Id_pedido         	| Int               	|

- Response

//nao sei
---
**Post** Notas

http://localhost:5000/Notas/

Utilize esta rota para inserir uma nota  fiscal ao pedido

- Request

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Pedido            	| Int               	|
| Email             	| String            	|
| CPF               	| String            	|

- Response

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Pedido            	| Int               	|
---
**Put** Pedidos/Totals/{id}

http://localhost:5000/Pedidos/Totals/{id}

Utilize esta rota para somar todos os gastos do pedido

- Parametros

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Id_pedido         	| Int               	|

-Response

//nao sei
---
**Get** Pedidos{id}

http://localhost:5000/Pedidos/{id}

Utilize esta rota para consultar pedidos

- Parametro

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Id_pedido         	| Int               	|

- Response

//nao sei
---
**Get** Trailers/Videos/{nome}

http://localhost:5000/Trailers/Videos/{nome}

Utilize esta rota para consulta trailers 

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Ds_imagem         	| String            	|

- Response

//nao sei
---
**Get** Filmes/Breve

http://localhost:5000/Filmes/Breve/

Utilize esta rota para retornar os filmes em que estrearam em breve

- Parametros 
    - Esta rota não possui parametros

- Response
//nao sei
---
**Get** Filmes/Foto/{nome}

Utilize esta rota para consultar a imagem do filme

- Parametro

| Nome do Parametro 	| Tipo do Parametro 	|
|-------------------	|-------------------	|
| Ds_imagem         	| String            	|

- Response

//nao sei


