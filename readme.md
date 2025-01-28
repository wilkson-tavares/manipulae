# Desafio Back-End Manipulaê 💊 💖

O Objetivo deste teste é construir uma API para a consulta, edição, inserção e exclusão sobre um conjunto de dados obtidos a partir da API de Dados do YouTube. Você deverá criar um projeto em **.net Core** utilizando a linguagem de programação **C#**. Também será necessário utilizar um banco de dados para persistir as informações coletadas da API. Para isso crie um banco **SQLite** vinculado ao projeto.

Ao final, você deverá enviar o código criado para um repositório de código, como o GitHub ou Bitbucket, por exemplo. Além do banco de dados SQLite, seu projeto não deverá possuir nenhuma dependência externa.
> **Chave da API do YouTube**: [Adquira uma chave gratuitamente do YouTube Data API](https://developers.google.com/youtube/v3/getting-started). Lembre-se, a chave de API é um dado sensível e não deve estar presente no código-fonte. Use uma variável de ambiente para armazená-la.

> **Documentação da API do YouTube**: [Link](https://developers.google.com/youtube/v3/docs/search/list)

## 1- Preencher um banco de dados a partir da api de vídeos do YouTube 🎬.

Utilizando a api do YouTube insira dados em um banco de dados do seu projeto de acordo com os seguintes parâmetros de consulta à api do YouTube:

-   Pesquisar por vídeos brasileiros
    
-   Os vídeos devem estar relacionados à manipulação de medicamentos
    
-   Todos os vídeos devem ser de 2022

> **Importante:** Ao consumir os serviços da api do YouTube, você não deve utilizar nenhum pacote ou biblioteca. Construa métodos para requisitar as Urls das APIs e interpretar a resposta no formato Json (REST).
    

## 2- Crie um conjunto de endpoints que possibilitem a execução das seguintes ações:

### 2.1 Filtrar

Crie um endpoint para filtrar os dados coletados e exibi-los em json, permitindo os seguintes parâmetros opcionais de busca:

-   Título
    
-   Duração
    

-   Autor
    
-   Vídeos criados após determinada data
    
-   Um parâmetro “q” que permita filtrar por título, descrição e nome do canal
    

### 2.2 Inserir

Crie um endpoint que permita inserir dados no banco de dados seguindo a mesma estrutura que você definiu no item 1.

### 2.3 Atualizar

Crie um endpoint que permita atualizar os dados de qualquer um dos vídeos inseridos no banco de dados.

### 2.4 – Excluir

Você também deve disponibilizar um endpoint para excluir registros. Porém, neste endpoint, os registros não poderão ser de fato excluídos. Utilize um campo booleano para indicar que o registro foi excluído.

## 3- Opcionais

### 3.1 – Autenticação

Você poderá implementar opcionalmente a autenticação JWT nos endpoints em que for aplicável.

### 3.2 – Código de Resposta

Tente sempre retornar o código de resposta HTTP adequado para cada uma das ocasiões.

### 3.3 – Tratamento de Erros

Quando for aplicável, faça o devido tratamento dos erros para que a API não lance exceções.

### 3.4 – Conhecimentos

Vamos considerar quaisquer conhecimentos além dos exigidos neste teste que você queira demonstrar em sua implementação. Fique à vontade para usar todo o seu repertório de conhecimento 😉.

## Considerações Finais
* O desafio deve ser realizado em **48 horas** a partir da data de envio do desafio. O gerenciamento do tempo e também sera um fator de análise.
* Ao término do teste você deverá enviar um e-mail contendo o link para o repositório criado e as instruções para compilar/executar seu projeto. Você também poderá encaminhar quaisquer informações que julgar úteis acerca de seu projeto.

**Boa Sorte!!**
