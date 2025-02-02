# Manipulaê API💊 💖

O Objetivo é construir uma API para a consulta, edição, inserção e exclusão sobre um conjunto de dados obtidos a partir da API de Dados do YouTube.

## Arquitetura

Optei por uma arquitetura simples e de rápido desenvolvimento, mas que atende os princípios do SOLID, DDD e Clean Architecture. A estrutura do projeto está organizada em camadas que separam as responsabilidades de forma clara e coesa.

## Passo a Passo para Executar a API

1. Clone o repositório:
    ```sh
    git clone <link-do-repositorio>
    cd manipulae
    ```

2. Configure a chave da API do YouTube como uma variável de ambiente:
    ```sh
    export YOUTUBE_API_KEY=<sua-chave-da-api-do-youtube>
    ```

3. Restaure as dependências do projeto:
    ```sh
    dotnet restore
    ```

4. Execute as migrações para criar o banco de dados SQLite:
    ```sh
    dotnet ef database update --project src/Manipulae.Infrastructure
    ```

5. Execute a aplicação:
    ```sh
    dotnet run --project src/Manipulae.Api
    ```

6. A API estará disponível em `http://localhost:5000`.

> **Nota:** Normalmente, eu crio um Docker Compose e com apenas um comando `docker-compose up` consigo executar a API. No entanto, um dos requisitos era não utilizar nenhuma dependência externa.

## Endpoint principal

**Nota:** Utilizei o Swagger para documentar cada endpoints, no entanto abaixo segue algumas informações acerca do principal endpoint da API.

### 1- GET: api/Youtube 
- Preencher um banco de dados a partir da api de vídeos do YouTube 🎬.
- Este é o principal endpoint da api.

> **Importante:** Ao consumir os serviços da api do YouTube, você não deve utilizar nenhum pacote ou biblioteca. Construa métodos para requisitar as Urls das APIs e interpretar a resposta no formato Json (REST).

## Autenticação

### Após cadastrar um usuário utilizando o endpoint `/api/user`, você poderá solicitar um token JWT através do endpoint `/api/login`.

**Importante:** Somente os endpoints `/api/video` estão protegidos por autenticação e requerem um token JWT.

## Testes Unitários

Como este é um projeto de um teste técnico e não era um requisito obrigatório, não desenvolvi testes unitários. No entanto, caso fosse obrigatório, eu utilizaria o xUnit para a implementação dos testes, mas vou deixar abaixo um exemplo de teste unitário para o endpoint `/api/video/{id}`.

### Cenário em que o video ja existe:

```c#
[Fact]
public async Task GetVideoById_ReturnsVideo_WhenVideoExists()
{
    // Arrange
    var videoId = 1;
    var mockVideoService = new Mock<IVideoService>();

    mockVideoService.Setup(service => service.GetVideoByIdAsync(videoId))
        .ReturnsAsync(new Video { Id = videoId, Title = "Test Video" })
    
    var controller = new VideoController(mockVideoService.Object)
    
    // Act
    var result = await controller.GetVideoById(videoId)
    
    // Assert
    var okResult = Assert.IsType<OkObjectResult>(result);
    var video = Assert.IsType<Video>(okResult.Value);
    Assert.Equal(videoId, video.Id);
}
```

Dependências necessárias:

```c#
<PackageReference Include="xunit" Version="2.4.1" />
<PackageReference Include="xunit.runner.visualstudio" Version="2.4.1" />
<PackageReference Include="Moq" Version="4.16.1" />
```

## Pré-requisitos

* NET 9 SDK: Certifique-se de ter o SDK do .NET 9 instalado. Você pode baixá-lo aqui.
* SQLite: Certifique-se de ter o SQLite instalado. Você pode baixá-lo aqui.