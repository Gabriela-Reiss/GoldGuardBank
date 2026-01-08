# 🏦 Gold Guard Bank

Sistema bancário desenvolvido em **ASP.NET Core MVC**, seguindo boas práticas de arquitetura em camadas, separação de responsabilidades e um DDD simplificado.  
O projeto simula funcionalidades essenciais de um banco digital, como **cadastro de usuários, autenticação, contas, transações e investimentos**.

---

## Funcionalidades

### Autenticação e Usuários
- Cadastro de usuários com validações
- Login com CPF e senha
- Criptografia de senha com **BCrypt**
- Geração de token **JWT**
- Logout seguro com exclusão de cookie

### Contas Bancárias
- Criação automática de conta no cadastro
- Depósito inicial opcional
- Controle de saldo
- Registro de transações (depósito, saque, etc.)

### Investimentos
- Cadastro de ativos financeiros
- Listagem de ativos diretamente do banco de dados
- Compra de ativos pelo usuário
- Exibição dos investimentos adquiridos
- Simulação de rendimento com valores estáticos
- Feedback visual de sucesso após a compra

### Transações
- Histórico completo de movimentações
- Tipos de transação controlados por `enum`
- Regras de negócio encapsuladas no domínio

---

## Tecnologias Utilizadas

- **.NET 8**
- **ASP.NET Core MVC**
- **Entity Framework Core**
- **SQL Server / Oracle** (configurável)
- **JWT (JSON Web Token)**
- **BCrypt.Net**
- **Razor Views**
- **Bootstrap**

---

 ## Segurança

- Senhas criptografadas com BCrypt
- Autenticação baseada em JWT

---

### Princípios aplicados
- Separação de responsabilidades em camadas
- Repository Pattern
- Unit of Work
- Mappings para mapeamento de entidades
- DTOs para comunicação entre camadas


