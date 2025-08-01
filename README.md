
# CNPJConsultaAPI

Uma API desenvolvida em ASP.NET Core para consultar e cadastrar empresas a partir de seu CNPJ, utilizando os dados fornecidos pela ReceitaWS.

## 📦 Funcionalidades

- 🔍 Consulta automática de dados da ReceitaWS pelo CNPJ.
- 📝 Cadastro de empresas com dados oficiais.
- ✅ Validação de CNPJ com limpeza de formatação.
- 👤 Controle de usuário com autenticação.
- 🔐 Proteção de endpoints com token JWT.

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- AutoMapper
- SQL Server
- JWT Authentication
- ReceitaWS (API pública)

## ⚙️ Como Usar

### 1. Clone o repositório

```bash
git clone https://github.com/clayton-oly/CNPJConsultaAPI.git
cd CNPJConsultaAPI
```
### 2. Execute as migrations e rode a aplicação

```bash
dotnet ef database update
dotnet run
```

## 🧪 Testes

Você pode usar ferramentas como Postman, Insomnia ou Swagger para testar os endpoints.

## 📄 Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

---

Desenvolvido com 💻 por [Clayton](https://github.com/clayton-oly)
