# AnallyzerAPI 🚀

AnallyzerAPI é uma API desenvolvida para gerenciar campanhas de marketing. A API permite a criação, leitura, atualização e exclusão de campanhas.

## Sumário

- [Visão Geral](#visão-geral)
- [Arquitetura](#arquitetura)
- [Desing Patterns](#desing-pattern)
- [Tecnologias](#tecnologias)
- [Configuração](#configuração)
- [Uso](#uso)
- [Endpoints da API](#endpoints-da-api)


## Visão Geral

A API Anallyzer fornece operações CRUD (Create, Read, Update, Delete) para campanhas de marketing. Os principais recursos incluem:

- **Criar**: Adicione novas campanhas.
- **Ler**: Recupere detalhes de campanhas específicas ou todas as campanhas.
- **Atualizar**: Atualize informações de campanhas existentes.
- **Excluir**: Remova campanhas do banco de dados.

## Arquitetura

No nosso projeto, optamos por uma **arquitetura monolítica**, onde tudo está centralizado em um único sistema. Isso facilita o desenvolvimento e a manutenção, especialmente no começo.

Comparado aos **microserviços**, que dividem o sistema em várias partes independentes e permitem escalar mais facilmente, o monolito é mais direto e simples para o que precisamos agora. Por isso, achamos que essa abordagem é a melhor para o momento.

## Desing Pattern

No nosso projeto, usamos o padrão de Design Repository Pattern. Basicamente, ele ajuda a separar a lógica de acesso a dados da lógica de negócios. Isso significa que a gente pode mexer nos dados sem precisar se preocupar com a implementação específica de onde eles vêm, tipo banco de dados ou APIs externas.

Esse padrão torna o código mais organizado e fácil de testar. Podemos trocar a forma como acessamos os dados sem bagunçar o resto da aplicação. É uma forma prática de manter tudo em models e flexível, o que é bom para manutenção a longo prazo.


## Tecnologias

- **.NET 8**: Framework utilizado para o desenvolvimento da API.
- **Entity Framework Core**: ORM utilizado para interagir com o banco de dados.
- **Oracle SQL**: Banco de dados utilizado para armazenar informações das campanhas.
- **xUnit**: Framework para testes unitários.
- **Moq**: Biblioteca para criação de mocks em testes unitários.

## Configuração

### Pré-requisitos

Certifique-se de que você tenha as seguintes ferramentas instaladas:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Oracle SQL Server](https://www.oracle.com/database/technologies/)

### Clonar o Repositório

Clone o repositório para sua máquina local:

```bash
git clone https://github.com/seuusuario/anallyzerapi.git
cd anallyzerapi
```

### Configuração do Banco de Dados

1. **Criar Banco de Dados**: Configure seu banco de dados Oracle SQL conforme a estrutura definida nas models.

2. **Atualizar String de Conexão**: Modifique a string de conexão no arquivo `appsettings.json` para refletir suas configurações de banco de dados.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "User Id=yourusername;Password=yourpassword;Data Source=yourdatasource"
  }
}
```

### Restaurar Pacotes

Restaurar os pacotes NuGet necessários:

```bash
dotnet restore
```

### Aplicar Migrations

Aplique as migrations para criar a estrutura do banco de dados:

```bash
dotnet ef database update
```

## Uso

Para iniciar a aplicação, execute o seguinte comando:

```bash
dotnet run
```

A API estará disponível no endereço padrão: `https://localhost:5001`.

### Exemplos de Requisições

#### Criar uma Campanha

**Request:**

```http
POST /api/Campains
Content-Type: application/json

{
  "Name": "Campanha de Natal",
  "Description": "Campanha especial para o Natal.",
  "Company": "Empresa X",
  "StartDate": "2024-12-01T00:00:00Z",
  "ForecastDate": "2024-12-31T23:59:59Z"
}
```

**Response:**

```http
HTTP/1.1 201 Created
Location: /api/Campains/1

{
  "ID": 1,
  "Name": "Campanha de Natal",
  "Description": "Campanha especial para o Natal.",
  "Company": "Empresa X",
  "StartDate": "2024-12-01T00:00:00Z",
  "ForecastDate": "2024-12-31T23:59:59Z",
  "RegistrationDate": "2024-09-13T00:00:00Z",
  "Status": "True"
}
```

#### Atualizar uma Campanha

**Request:**

```http
PUT /api/Campains/1
Content-Type: application/json

{
  "Name": "Campanha de Ano Novo",
  "Status": "Updated"
}
```

**Response:**

```http
HTTP/1.1 204 No Content
```

#### Excluir uma Campanha

**Request:**

```http
DELETE /api/Campains/1
```

**Response:**

```http
HTTP/1.1 204 No Content
```

## Endpoints da API

### GET /api/Campains

Obtém todas as campanhas.

**Resposta:**

- **200 OK**: Lista de campanhas.

### GET /api/Campains/{id}

Obtém uma campanha pelo ID.

**Parâmetros de URL:**

- `id` (int): O ID da campanha.

**Resposta:**

- **200 OK**: Detalhes da campanha.
- **404 Not Found**: Se a campanha não for encontrada.

### POST /api/Campains

Cria uma nova campanha.

**Request Body:**

- `Name` (string): Nome da campanha.
- `Description` (string): Descrição da campanha.
- `Company` (string): Empresa responsável pela campanha.
- `StartDate` (DateTime): Data de início da campanha.
- `ForecastDate` (DateTime): Data de previsão de término da campanha.

**Resposta:**

- **201 Created**: A campanha criada, com o ID no cabeçalho `Location`.
- **400 Bad Request**: Se os dados da campanha não forem válidos.

### PUT /api/Campains/{id}

Atualiza uma campanha existente.

**Parâmetros de URL:**

- `id` (int): O ID da campanha.

**Request Body:**

- `Name` (string, opcional): Nome da campanha.
- `Description` (string, opcional): Descrição da campanha.
- `Company` (string, opcional): Empresa responsável pela campanha.
- `StartDate` (DateTime, opcional): Data de início da campanha.
- `ForecastDate` (DateTime, opcional): Data de previsão de término da campanha.
- `Status` (string, opcional): Status da campanha.

**Resposta:**

- **204 No Content**: Atualização bem-sucedida.
- **404 Not Found**: Se a campanha não for encontrada.

### DELETE /api/Campains/{id}

Remove uma campanha pelo ID.

**Parâmetros de URL:**

- `id` (int): O ID da campanha.

**Resposta:**

- **204 No Content**: Exclusão bem-sucedida.
- **404 Not Found**: Se a campanha não for encontrada.

##🤝 Integrantes
<table>
  <tr>
    <td align="center">
      <a href="https://github.com/nichol6s">
        <img src="https://avatars.githubusercontent.com/u/105325313?v=4" width="115px;" alt="Foto do Nicholas no GitHub"/><br>
        <sub>
          <strong>Nicholas Santos</strong>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="https://github.com/VitorKubica">
        <img src="https://avatars.githubusercontent.com/u/107961081?v=4" width="115px;" alt="Foto do Vitor no GitHub"/><br>
        <sub>
          <strong>Vitor Kubica</strong>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="https://github.com/DuduViolante">
        <img src="https://avatars.githubusercontent.com/u/126472870?v=4" width="115px;" alt="Foto do Violante no GitHub"/><br>
        <sub>
          <strong>Eduardo Violante</strong>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="https://github.com/pedrocpacheco">
        <img src="https://avatars.githubusercontent.com/u/112909829?v=4" width="115px;" alt="Foto do Pedro no Github"/><br>
        <sub>
          <strong>Pedro Pacheco</strong>
        </sub>
      </a>
    </td>
    <td align="center">
        <a href="https://github.com/biasvestka">
        <img src="https://avatars.githubusercontent.com/u/126726456?v=4" width="115px;" alt="Foto da Beatriz GitHub"/><br>
        <sub>
            <strong>Beatriz Svestka</strong>
        </sub>
      </a>
    </td>
  </tr>
</table>
