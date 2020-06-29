### Projeto
- **Desenvolvido por:** Fernando José
- **Descrição:**
Criação de um CRUD de usuário

### Padrões e Tecnologias utilizadas
#### FrontEnd
- React
- react-router-dom
- Axios
- Bootstrap

#### BackEnd
- Net Core 3.1
- DDD
- CQRS
- API Rest
- XUnit
- Swagger
- Dapper
- IoC
- Moq
- Bogus (faker)
- C#
- RequestResponseMiddleware: Responsável por logar e tratar tudo que entre e sai da API no mongoDB
- ExceptionMiddleware: Responsável por pegar e tratar todos os erros inesperados da aplicação

#### Banco de dados
- SQL Server
- MongoDB

### Configuração

#### Pré requisitos
- nodeJS
- React
- Net Core 3.1

#### FrontEnd
- Abrir Terminal
- Acessar a pasta onde está o projeto
- Acessar a pasta .\Src\Fgj.Cqrs.React\web
- npm install
- npm start

#### BackEnd
- Abrir Terminal
- Acessar a pasta onde está o projeto
- Acessar a pasta .\Src\Fgj.Cqrs.Api
- dotnet restore
- dotnet build
- dotnet run

### ToDo
Melhorias para serem feitas 

#### FrontEnd
- Criar um componente para tratar erros
- Criar um componente para fazer upload de arquivos
- Criar um component de modal

#### BackEnd
- Separar os Commands das Queries em projetos diferentes e criar um banco de dados para cada
- Publicar em um message bus quando um command for executado para o projeto da query consumir e atualizar a sua base de dados
- Criar politica de CircuitBreaker
- Criar HealthCheck
- Criar política de retry com Polly

### Ambientes

#### Desenvolvimento
- **Swagger:** https://localhost:44306/swagger
- **WebPage:** http://localhost:3000

#### Homologação
- **Swagger:** https://fgj-cqrs-backend.azurewebsites.net/swagger
- **WebPage:** https://fgj-cqrs-front.azurewebsites.net