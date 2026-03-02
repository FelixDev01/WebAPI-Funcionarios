# Employee Management API 🚀

Esta é uma Web API robusta desenvolvida em **.NET 10** para o gerenciamento de funcionários. O projeto foi construído seguindo as melhores práticas de desenvolvimento, como **Repository Pattern**, **Injeção de Dependência** e a separação clara de responsabilidades através de **DTOs** (Data Transfer Objects).

## 🛠️ Tecnologias Utilizadas

* **Runtime:** .NET 10
* **Linguagem:** C#
* **Banco de Dados:** SQL Server
* **ORM:** Entity Framework Core (com Migrations)
* **Documentação:** Swagger (OpenAPI)
* **Arquitetura:** Layered Architecture (Domain, Application, Data, Controllers)

## 🏗️ Arquitetura e Padrões

O projeto foca na manutenibilidade e escalabilidade, utilizando:
* **Interface-based Service Layer:** Desacoplamento da lógica de negócio.
* **DTOs:** Proteção das entidades de domínio e controle fino dos dados de entrada e saída.
* **Enums:** Padronização de campos como Departamentos e Turnos.
* **Asynchronous Programming:** Operações de I/O (banco de dados) totalmente assíncronas para melhor performance.

## 🚦 Endpoints da API (Documentação Swagger)

A API fornece um CRUD completo para a entidade Funcionário:

| Método | Endpoint | Descrição |
| :--- | :--- | :--- |
| **GET** | `/api/funcionarios` | Lista todos os funcionários. |
| **GET** | `/api/funcionarios/{id}` | Busca um funcionário específico pelo ID. |
| **POST** | `/api/funcionarios` | Cadastra um novo funcionário. |
| **PUT** | `/api/funcionarios/{id}` | Atualiza os dados de um funcionário existente. |
| **PATCH** | `/api/funcionarios/inativar/{id}` | Realiza o "Soft Delete" (inativação lógica). |

## 📸 Demonstração

### Documentação Interativa (Swagger)
A interface do Swagger permite testar todos os endpoints em tempo real, exibindo os esquemas de Request e Response.

### Persistência de Dados (SQL Server)
Integração total com SQL Server via Entity Framework, garantindo a integridade dos dados e o histórico de criação/alteração.

## 🚀 Como Executar o Projeto

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/FelixDev01/WebAPI-Funcionarios.git]
    ```
2.  **Configure a Connection String:**
    No arquivo `appsettings.json`, ajuste a `DefaultConnection` para apontar para o seu servidor SQL Server local.
3.  **Execute as Migrations:**
    No terminal, dentro da pasta do projeto:
    ```bash
    dotnet ef database update
    ```
4.  **Rode a aplicação:**
    ```bash
    dotnet run
    ```
5.  Acesse a documentação em: `http://localhost:5127/swagger/index.html`
