# 🏥 CLINICAINOVA

Sistema de gerenciamento de clínica médica desenvolvido em **ASP.NET Core 8** com banco de dados **MySQL**. Permite cadastro e autenticação de pacientes, profissionais de saúde e administradores, além de agendamento de consultas, prontuários e serviços.

---

## 📋 Pré-requisitos

Antes de rodar o projeto, certifique-se de ter instalado:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) (porta padrão `3306`)
- [Git](https://git-scm.com/)

---

## ⚙️ Configuração do Banco de Dados

### 1. Inicie o servidor MySQL

> ⚠️ **IMPORTANTE: o MySQL precisa estar rodando antes de iniciar a aplicação!**

**Windows (via Services ou MySQL Workbench):**
```bash
net start MySQL80
```

**Linux/macOS:**
```bash
sudo service mysql start
# ou
sudo systemctl start mysql
```

**XAMPP / WAMP:**
Abra o painel e clique em **Start** no MySQL.

---

### 2. Configure a connection string

Abra o arquivo `appsettings.json` e ajuste as credenciais conforme o seu ambiente:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=Inova;user=root;password=SUA_SENHA_AQUI"
  }
}
```

> Por padrão o projeto usa `user=root` e `password=123451`. Altere conforme necessário.

---

## 🚀 Como rodar o projeto

### 1. Clone o repositório

```bash
git clone <URL_DO_REPOSITORIO>
cd CLINICAINOVA
```

### 2. Restaure os pacotes NuGet

```bash
dotnet restore
```

### 3. Aplique as migrations (cria o banco automaticamente)

```bash
dotnet ef database update
```

> Isso cria o banco `Inova` e todas as tabelas automaticamente no MySQL.

### 4. (Opcional) Popule os profissionais de saúde iniciais

Execute o script SQL localizado em `Scripts/seed_medicos.sql` no seu MySQL Workbench, DBeaver ou via terminal:

```bash
mysql -u root -p < Scripts/seed_medicos.sql
```

Esse script cria dois profissionais de saúde para teste:

| Nome | E-mail | Senha |
|---|---|---|
| Dr. Roberto Mendes | roberto@inova.pt | 123456 |
| Dra. Amanda (sobrenome no script) | amanda@inova.pt | 123456 |

### 5. Inicie o servidor

```bash
dotnet run
```

A API ficará disponível em:

- **HTTP:** `http://localhost:5007`
- **HTTPS:** `https://localhost:7169`

---

## 📖 Documentação da API (Swagger)

Com o servidor rodando, acesse a interface do Swagger para testar todos os endpoints:

```
http://localhost:5007/swagger
```

---

## 🖥️ Interface Web

O projeto inclui páginas HTML prontas na pasta `web/`. Abra-as diretamente no navegador ou sirva com qualquer servidor HTTP estático:

| Arquivo | Descrição |
|---|---|
| `web/login.html` | Tela de login |
| `web/index.html` | Página inicial |
| `web/marcar_consulta.html` | Agendamento de consultas |
| `web/meus_agendamentos.html` | Lista de agendamentos do paciente |
| `web/historico_paciente.html` | Histórico / prontuário do paciente |
| `web/painel_admin.html` | Painel do administrador |
| `web/painel_profissional.html` | Painel do profissional de saúde |

---

## 📡 Endpoints da API

### Autenticação (`/api/Auth`)
| Método | Rota | Descrição |
|---|---|---|
| POST | `/api/Auth/cadastro` | Cadastra novo usuário (paciente, profissional ou admin) |
| POST | `/api/Auth/login` | Realiza login e retorna dados do usuário |

### Pacientes (`/api/Paciente`)
| Método | Rota | Descrição |
|---|---|---|
| GET | `/api/Paciente` | Lista todos os pacientes |
| GET | `/api/Paciente/{id}` | Busca paciente por ID |

### Profissionais (`/api/Profissional`)
| Método | Rota | Descrição |
|---|---|---|
| GET | `/api/Profissional` | Lista todos os profissionais de saúde |

### Agendamentos (`/api/Agendamento`)
| Método | Rota | Descrição |
|---|---|---|
| GET | `/api/Agendamento` | Lista todos os agendamentos |
| POST | `/api/Agendamento` | Cria novo agendamento |

### Prontuários (`/api/Prontuario`)
| Método | Rota | Descrição |
|---|---|---|
| GET | `/api/Prontuario` | Lista prontuários |
| POST | `/api/Prontuario` | Cria novo prontuário |

### Serviços (`/api/Servico`)
| Método | Rota | Descrição |
|---|---|---|
| GET | `/api/Servico` | Lista serviços disponíveis |

### Administrador (`/api/Administrador`)
| Método | Rota | Descrição |
|---|---|---|
| GET | `/api/Administrador` | Funções administrativas |

---

## 🗂️ Estrutura do Projeto

```
CLINICAINOVA/
├── Controlls/              # Controllers da API (rotas HTTP)
│   ├── AuthController.cs
│   ├── AgendamentoController.cs
│   ├── PacienteController.cs
│   ├── ProfissionalController.cs
│   ├── ProntuarioController.cs
│   ├── ServicoController.cs
│   └── AdministradorController.cs
├── Models/                 # Entidades do banco de dados
│   ├── Usuario.cs
│   ├── Paciente.cs
│   ├── ProfissionalSaude.cs
│   ├── Administrador.cs
│   ├── Agendamento.cs
│   ├── Prontuario.cs
│   └── Servico.cs
├── DTOs/                   # Objetos de transferência de dados
│   ├── LoginDTO.cs
│   ├── CadastroDTO.cs
│   ├── AgendamentoDTO.cs
│   └── ProntuarioDTO.cs
├── Data/
│   └── AppDbContext.cs     # Contexto do Entity Framework
├── Migrations/             # Histórico de migrations do banco
├── Scripts/
│   ├── seed_medicos.sql              # Script para popular profissionais
│   └── swagger_cadastro_medicos.md  # Guia de cadastro via Swagger
├── web/                    # Páginas HTML do frontend
├── appsettings.json        # Configurações (connection string, etc.)
└── Program.cs              # Ponto de entrada da aplicação
```

---

## 🛠️ Tecnologias Utilizadas

- **ASP.NET Core 8** — framework backend
- **Entity Framework Core 8** — ORM para acesso ao banco
- **Pomelo.EntityFrameworkCore.MySql** — driver MySQL para EF Core
- **MySQL** — banco de dados relacional
- **Swagger / Swashbuckle** — documentação e teste da API
- **HTML/CSS/JS** — frontend estático

---

## ❗ Problemas comuns

**Erro de conexão com o banco:**
Verifique se o MySQL está rodando e se a senha no `appsettings.json` está correta.

**Porta já em uso:**
Mude a porta em `Properties/launchSettings.json` ou encerre o processo que está usando a porta 5007.

**Migration falhou:**
Certifique-se de que o banco `Inova` pode ser criado pelo usuário configurado, ou crie-o manualmente:
```sql
CREATE DATABASE Inova;
```
