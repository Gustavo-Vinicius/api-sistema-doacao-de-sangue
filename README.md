<h1 align="center" style="font-weight: bold;">Blood Donation System 💻</h1>

<p align="center">
 <a href="#tech">Technologies</a> • 
 <a href="#started">Getting Started</a> • 
  <a href="#routes">API Endpoints</a> •
 <a href="#colab">Collaborators</a> •
 <a href="#contribute">Contribute</a>
</p>

<p align="center">
    <b>Simple description of what your project do or how to use it.</b>
</p>

<h2 id="technologies">💻 Technologies</h2>

- C#
- .NET 8
- SQL SERVER

<h2 id="started">🚀 Getting started</h2>

Here you describe how to run your project locally

<h3>Prerequisites</h3>

  To run the project locally, you first need to install the .NET SDK. Make sure it is installed, otherwise you can download it directly from the official .NET website. Also, make sure SQL Server is installed and running on your machine.
Next, you must clone the project repository. Use the git clone command https://github.com/Gustavo-Vinicius/api-sistema-doacao-de-sangue.git to clone the repository to your local environment.
After cloning the repository, open the appsettings.json file located in the project directory. Edit the connection string in this file to point to your SQL Server instance.	
Be sure to replace localhost, YourDatabase, your-username, and your-password with the correct values ​​for your configuration.
With the settings adjusted, go to the terminal, navigate to the project directory and run the dotnet run command. This command will start the server, allowing you to access the application in the browser. Typically, the application will be available at http://localhost:5000 or http://localhost:5001 if you are using HTTPS.
By following these steps, you will be able to run the project locally without any problems.

- [NodeJS](https://github.com/)
- [Git 2](https://github.com)

<h3>Cloning</h3>

How to clone your project

```bash
git clone https://github.com/Gustavo-Vinicius/api-sistema-doacao-de-sangue.git
```

<h3>Starting</h3>

How to start your project

```bash
1º cd api-sistema-doacao-de-sangue
2º dotnet restore
3º dotnet ef database update
4º dotnet run
```

<h2 id="routes">📍 API Endpoints</h2>

Here you can list the main routes of your API, and what are their expected request bodies.
​
| route               | description                                          
|----------------------|-----------------------------------------------------
| <kbd>GET /authenticate</kbd>     | retrieves user info see [response details](#get-auth-detail)
| <kbd>POST /authenticate</kbd>     | authenticate user into the api see [request details](#post-auth-detail)
| <kbd>POST /api/Doacao/cadastrar-doacaoes</kbd>     | registers donor donations [request details](#post-register-donations)
| <kbd>GET /api/Doacao/obter-doacoes-por-id</kbd>     | search for donations by donation id [response details](#get-donation-by-id)
| <kbd>GET /api/Doador/obter-doador-por-id</kbd>     | search for donor by id [response details](#get-donor-by-id)
| <kbd>GET /api/Doador/obter-listagem-de-doadores</kbd>     | get donor list [response details](#get-donor)
| <kbd>GET /api/Doador/obter-doacoes-por-doador</kbd>     | search for donations by donor [response details](#get-search-donations-by-donor)
| <kbd>POST /api/Doador/cadastrar-doador</kbd>     | register donor [response details](#post-register-donor)
| <kbd>PUT /api/Doador/editar-doador</kbd>     | edit donor [response details](#put-edit-donor)
<h3 id="get-auth-detail">GET /authenticate</h3>

**RESPONSE**
```json
{
  "name": "Fernanda Kipper",
  "age": 20,
  "email": "her-email@gmail.com"
}
```

<h3 id="post-auth-detail">POST /authenticate</h3>

**REQUEST**
```json
{
  "username": "fernandakipper",
  "password": "4444444"
}
```

**RESPONSE**
```json
{
  "token": "OwoMRHsaQwyAgVoc3OXmL1JhMVUYXGGBbCTK0GBgiYitwQwjf0gVoBmkbuyy0pSi"
}
```
<h3 id="post-register-donations">POST /api/Doacao/cadastrar-doacaoes</h3>

**REQUEST**
```json
{
  "cadastrarDoacao": {
    "doadorId": 0,
    "dataDoacao": "2024-06-26T11:53:37.657Z",
    "quantidadeML": 0
  }
}
```

<h3 id="get-auth-detail">GET /api/Doacao/obter-doacoes-por-id</h3>

**RESPONSE**
```json
{
  "id": 1,
  "doadorId": 1,
  "dataDoacao": "2024-05-28T00:00:00",
  "quantidadeML": 420,
  "doador": null
}
```

<h3 id="get-donor-by-id">GET /api/Doador/obter-doador-por-id</h3>

**RESPONSE**
```json
{
  "nomeCompleto": "string",
  "email": "string",
  "dataNascimento": "2000-09-25T00:00:00",
  "genero": "string",
  "peso": 0,
  "tipoSanguineo": "string",
  "fatorRh": "string"
}
```

<h3 id="get-donor">GET /api/Doador/obter-listagem-de-doadores</h3>

**RESPONSE**
```json
[
 {
  "nomeCompleto": "string",
  "email": "string",
  "dataNascimento": "2000-09-25T00:00:00",
  "genero": "string",
  "peso": 0,
  "tipoSanguineo": "string",
  "fatorRh": "string"
 }
]
```

<h3 id="get-search-donations-by-donor">GET /api/Doador/obter-doacoes-por-doador</h3>

**RESPONSE**
```json
[
  {
    "doadorId": 0,
    "dataDoacao": "2024-07-01T00:00:00",
    "quantidadeML": 0
  }
]
```
<h3 id="post-register-donor">POST /api/Doador/cadastrar-doador</h3>

**RESPONSE**
```json
  "cadastrarDoador": {
    "nomeCompleto": "string",
    "email": "string",
    "dataNascimento": "2024-06-27T20:55:59.560Z",
    "genero": "string",
    "peso": 0,
    "tipoSanguineo": "string",
    "fatorRh": "string"
  }
```
<h3 id="put-edit-donor">PUT /api/Doador/cadastrar-doador</h3>

**RESPONSE**
```json
"id": 0,
  "doadorDTO": {
    "nomeCompleto": "string",
    "email": "string",
    "dataNascimento": "2024-06-27T21:08:01.816Z",
    "genero": "string",
    "peso": 0,
    "tipoSanguineo": "string",
    "fatorRh": "string"
  }
```

<h2 id="contribute">📫 Contribute</h2>

Here you will explain how other developers can contribute to your project. For example, explaining how can create their branches, which patterns to follow and how to open an pull request

1. `git clone https://github.com/Fernanda-Kipper/text-editor.git`
2. `git checkout -b feature/NAME`
3. Follow commit patterns
4. Open a Pull Request explaining the problem solved or feature made, if exists, append screenshot of visual modifications and wait for the review!

<h3>Documentations that might help</h3>

[📝 How to create a Pull Request](https://www.atlassian.com/br/git/tutorials/making-a-pull-request)

[💾 Commit pattern](https://gist.github.com/joshbuchea/6f47e86d2510bce28f8e7f42ae84c716)
