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
- .NET
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

<h2 id="colab">🤝 Collaborators</h2>

Special thank you for all people that contributed for this project.

<table>
  <tr>
    <td align="center">
      <a href="#">
        <img src="https://avatars.githubusercontent.com/u/61896274?v=4" width="100px;" alt="Fernanda Kipper Profile Picture"/><br>
        <sub>
          <b>Fernanda Kipper</b>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="#">
        <img src="https://t.ctcdn.com.br/n7eZ74KAcU3iYwnQ89-ul9txVxc=/400x400/smart/filters:format(webp)/i490769.jpeg" width="100px;" alt="Elon Musk Picture"/><br>
        <sub>
          <b>Elon Musk</b>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="#">
        <img src="https://miro.medium.com/max/360/0*1SkS3mSorArvY9kS.jpg" width="100px;" alt="Foto do Steve Jobs"/><br>
        <sub>
          <b>Steve Jobs</b>
        </sub>
      </a>
    </td>
  </tr>
</table>

<h2 id="contribute">📫 Contribute</h2>

Here you will explain how other developers can contribute to your project. For example, explaining how can create their branches, which patterns to follow and how to open an pull request

1. `git clone https://github.com/Fernanda-Kipper/text-editor.git`
2. `git checkout -b feature/NAME`
3. Follow commit patterns
4. Open a Pull Request explaining the problem solved or feature made, if exists, append screenshot of visual modifications and wait for the review!

<h3>Documentations that might help</h3>

[📝 How to create a Pull Request](https://www.atlassian.com/br/git/tutorials/making-a-pull-request)

[💾 Commit pattern](https://gist.github.com/joshbuchea/6f47e86d2510bce28f8e7f42ae84c716)
