# 📊 Cadastro de Funcionários - Web API com .NET + Vue.js

Este projeto consiste em uma aplicação **full stack** para cadastro e listagem de funcionários, utilizando uma **API REST em ASP.NET Core** e uma **interface em Vue.js**.

---

## 🚀 Funcionalidades

- ✅ Autenticação simples (usuário/senha fixos)
- ✅ Cadastro de funcionários
- ✅ Listagem de funcionários cadastrados
- ✅ Interface limpa e intuitiva com Vue.js
- ✅ Comunicação via API REST com JWT

---

## 🧰 Tecnologias utilizadas

**Back-end (API):**
- ASP.NET Core Web API
- Entity Framework Core
- JWT (para autenticação)

**Front-end (SPA):**
- Vue.js 3
- Axios (requisições HTTP)

---

## ⚙️ Como executar o projeto localmente

### 1. Clone este repositório

```bash
git clone https://github.com/joaomendes27/webapi-funcionarios.git
```

## 2. Execute a API (.NET)

1. Navegue até a pasta da API:

    ```bash
    cd PrimeiraAPI
    ```

2. Restaure os pacotes e execute o projeto:

    ```bash
    dotnet restore
    dotnet run
    ```

3. A API estará rodando, mas se precisar confirmar a porta onde ela está sendo executada, consulte a URL no terminal após rodar o comando `dotnet run`. O terminal exibirá algo como:

    ```
    Now listening on: https://localhost:5001
    ```

    Caso não veja a URL imediatamente, procure por uma linha que contenha `Now listening on` para saber qual porta está sendo usada.

---

## 3. Execute o Front-end (Vue.js)

1. **Certifique-se de que a API esteja rodando** antes de iniciar o front-end, pois ele depende dela para funcionar corretamente.

2. Navegue até a pasta do front-end:

    ```bash
    cd web-api-js
    ```

3. Instale as dependências:

    ```bash
    npm install
    ```

4. Execute o front-end:

    ```bash
    npm run serve
    ```

---

## 4. Autenticação (Apenas para Fins Educacionais)

⚠️ Este projeto utiliza **autenticação básica** com um usuário fixo e senha em texto puro, apenas para fins de estudo.

### Credenciais:

- **Usuário**: joao
- **Senha**: senhateste

🔐 Em produção, é recomendada a utilização de **hashing de senhas** (como BCrypt) e banco de dados para autenticação real.

