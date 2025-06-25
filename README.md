# 🎬 FilmManager API

**FilmManager** é uma **API RESTful** desenvolvida com **ASP.NET Core**, com o objetivo de gerenciar um catálogo de filmes. A aplicação permite operações completas de CRUD (Create, Read, Update, Delete), utilizando **DTOs** para segurança e padronização das requisições/respostas, além de estar integrada a um banco de dados **MySQL** com mapeamento via **Entity Framework Core**.

A API segue uma arquitetura em camadas, com organização clara de responsabilidades, e conta com **documentação interativa via Swagger** para facilitar testes e integração.

---

## 🚀 Funcionalidades

- ✅ **Cadastrar filmes**
- 🔍 **Listar todos os filmes**
- 🎞️ **Consultar filme por ID**
- ✏️ **Atualizar informações de um filme**
- ❌ **Remover filme do sistema**

---

## 🧰 Tecnologias utilizadas

- [ASP.NET Core](https://learn.microsoft.com/aspnet/core/)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [MySQL](https://www.mysql.com/)
- [AutoMapper](https://automapper.org/)
- [Swagger / Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)

---

## 🗂️ Estrutura do Projeto

```plaintext
FilmManagerAPI/
│
├── Controllers/     # Endpoints da API
├── Data/            # DbContext e acesso ao banco
├── Dtos/            # Objetos de Transferência de Dados (DTOs)
├── Models/          # Modelos da aplicação (entidades)
├── Profiles/        # Mapeamento entre Models e DTOs (AutoMapper)
├── Migrations/      # Histórico de migrações do EF Core
└── Program.cs       # Configuração e startup do projeto
```
## 🧱 Arquitetura da Aplicação

A FilmManager API foi construída seguindo o padrão de **arquitetura em camadas**, separando bem as responsabilidades para garantir escalabilidade, manutenibilidade e facilidade de testes. As principais camadas e suas funções são:

### 🔹 Controller
- Responsável por expor os endpoints HTTP da API.
- Recebe as requisições, aciona a lógica apropriada e retorna as respostas.

### 🔹 DTOs (Data Transfer Objects)
- Utilizados para transferir dados de forma segura entre a API e o cliente.
- Evitam o vazamento direto de entidades do banco e permitem validações.

### 🔹 Models
- Representam as entidades do domínio, como `Filme`.
- São usados pelo Entity Framework para mapear o banco de dados.

### 🔹 Profiles (AutoMapper)
- Realizam o mapeamento entre `Models` e `DTOs`, automatizando a conversão de dados.

### 🔹 Data
- Contém o `DbContext`, que atua como a ponte entre a aplicação e o banco de dados.
- Centraliza o acesso ao repositório de dados via Entity Framework Core.

---

### 🧭 Fluxo de execução típico

1. O cliente envia uma requisição HTTP para a API.
2. O **Controller** recebe a requisição e chama os métodos apropriados.
3. A requisição é tratada usando **DTOs**, mapeados via **AutoMapper**.
4. O **DbContext** interage com o **MySQL** usando os **Models**.
5. A resposta é convertida novamente em DTO (se necessário) e devolvida ao cliente.

## ⚙️ Como rodar o projeto localmente

- **.NET 7 SDK**
- **MySQL Server**
- **Visual Studio ou VS Code**
- **Ferramenta de gerenciamento de banco (opcional): MySQL Workbench, DBeaver, etc.**
---
## 📥 Passos para execução
- **1. Clone o repositório**
```plaintext
git clone https://github.com/LeandroHenks/FilmManagerAPI.git
cd FilmManagerAPI
```
- **2. Configure a string de conexão com o MySQL ( appsettings.json )**
```plaintext
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=FilmManagerDb;User Id=seu_usuario;Password=sua_senha;"
}
```
- **3. Rode as migrações para criar o banco:**
```plaintext
dotnet ef database update
```
- **Caso necessário, instale a CLI do EF Core:**
```plaintext
dotnet tool install --global dotnet-ef
```
- **4.Execute o projeto::**
```plaintext
dotnet run
```
- **5.Acesse o Swagger para testar os endpoints:**
```plaintext
https://localhost:5001/swagger
```
---
## 📄 Endpoints principais

| Método | Rota                | Descrição                          |
|--------|---------------------|------------------------------------|
| GET    | /api/filmes         | Lista todos os filmes              |
| GET    | /api/filmes/{id}    | Busca um filme por ID              |
| POST   | /api/filmes         | Cadastra um novo filme (via DTO)   |
| PUT    | /api/filmes/{id}    | Atualiza dados de um filme         |
| DELETE | /api/filmes/{id}    | Remove um filme do catálogo        |
----
## 🧪 Testes via Swagger
Após rodar o projeto, acesse https://localhost:5001/swagger para testar os endpoints diretamente na interface interativa gerada automaticamente com Swashbuckle.
---
# 📦Sobre os DTOs

##### O uso de DTOs (Data Transfer Objects) garante que apenas os dados necessários sejam expostos ou aceitos via API, evitando problemas de segurança e facilitando a validação das requisições. Os DTOs são mapeados para os Models com o auxílio do AutoMapper, o que simplifica a transformação dos dados internamente.
---
# 🧱 Migrations


##### As Migrations são usadas para versionar o esquema do banco de dados com o EF Core. Toda vez que o modelo mudar, você pode criar uma nova migration com:
```plaintext
dotnet ef migrations add NomeDaMigration
```
- **E aplicar com:**
```plaintext
dotnet ef database update
```
---
## 🤝 Contribuições
Contribuições são bem-vindas!
Abra uma issue ou envie um pull request com sugestões, correções ou melhorias.
