# Etapa de construção
FROM mcr.microsoft.com/dotnet/sdk:8.0.101 AS build-env
WORKDIR /app

# Copie o arquivo de solução (se você tiver um) e todos os arquivos .csproj para o diretório de trabalho
COPY *.sln ./
COPY Sistema-de-Doacao-de-Sangue.API/Sistema-de-Doacao-de-Sangue.API.csproj Sistema-de-Doacao-de-Sangue.API/
COPY Sistema-de-Doacao-de-Sangue.Core/Sistema-de-Doacao-de-Sangue.Core.csproj Sistema-de-Doacao-de-Sangue.Core/
COPY Sistema-de-Doacao-de-Sangue.Infrastructure/Sistema-de-Doacao-de-Sangue.Infrastructure.csproj Sistema-de-Doacao-de-Sangue.Infrastructure/
COPY Sistema-de-Doacao-de-Sangue.Application/Sistema-de-Doacao-de-Sangue.Application.csproj Sistema-de-Doacao-de-Sangue.Application/
COPY Sistema-de-Doacao-de-Sangue.Tests/Sistema-de-Doacao-de-Sangue.Tests.csproj Sistema-de-Doacao-de-Sangue.Tests/

# Adicione uma linha para depuração: liste os arquivos no diretório de trabalho
RUN ls -al

# Restaure as dependências do projeto
RUN dotnet restore

# Copie o restante dos arquivos e compile o projeto
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0.1
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_ENVIRONMENT=Docker
ENTRYPOINT ["dotnet", "Sistema-de-Doacao-de-Sangue.API.dll"]
