API do FilmManager é uma API RESTful desenvolvida com ASP.NET Core, com o objetivo de gerenciar um catálogo de filmes. A aplicação permite operações completas de CRUD (Create, Read, Update, Delete) e está integrada a um banco de dados MySQL.

🚀 Funcionalidades
✅ Cadastrar filmes
🔍 Listar todos os filmes
🎞️ Consultar filme por ID
✏️ Atualizar informações de um filme
❌ Remover filme do sistema

🛠️ Tecnologias utilizadas
ASP.NET Core
Entity Framework Core
MySQL
AutoMapper
Swagger (para documentação da API)

🗂️ Estrutura do projeto
O projeto segue uma arquitetura em camadas, com separação entre:
Controllers/: controladores HTTP
Models/: modelos da aplicação
Data/: acesso ao banco (DbContext)
Profiles/: configurações do AutoMapper
Migrations/: histórico de migrações EF Core

📄 Documentação
A API conta com documentação interativa via Swagger, acessível ao rodar o projeto em ambiente local.
