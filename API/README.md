# API - IA

API que simula um chat de Inteligência Artificial, armazenando histórico de mensagens, prompts e usuários.  

---

##  Estrutura do Projeto

- **Controllers**: definem os endpoints da API.
- **Domain**: contém as entidades do sistema (User, Chat, Message, Prompt).
- **Infrastructure**: responsável pela conexão com o banco de dados e repositórios.
- **Services**: lógica de negócio e regras de validação.
- **Program.cs**: configuração da aplicação e injeção de dependência.

---

## Funcionalidades

- **Gerenciamento de usuários**: cadastro e listagem.
- **Chats**: criação de conversas vinculadas a usuários.
- **Mensagens**: envio e registro de mensagens, tanto do usuário quanto da IA.
- **Prompts**: criação de prompts vinculados às conversas e mensagens.
- **Histórico completo**: mantém registro de todas as interações.

---

## Endpoints

- **Usuários**: listar, buscar por ID e criar novos.
- **Chats**: listar, buscar por ID e criar novas conversas.
- **Mensagens**: listar mensagens de um chat e enviar novas.
- **Prompts**: listar, buscar por ID e criar novos prompts.
  
---

##  Como Executar o Projeto

### 1. Clonar

git clone https://github.com/AlanaCarolayne/API-GS

### 2. Configurar conexão

Edite o appsettings.json

### 3. Restaurar pacotes

dotnet restore

### 4. Executar

dotnet run

### 5. Abrir Swagger

http://localhost:5001/swagger

------------------------------------------------------------------------
## Autoras
Alana Carolayne Moreira Siqueira RM: 552261

Ana Júlia Henriques Neves RM: 98263

FIAP - 3SIS - 2025

