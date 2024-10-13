# Projeto Ambiental - Monitoramento da Qualidade do Ar

Este projeto tem como objetivo o monitoramento da qualidade do ar, desenvolvido em **C# com .NET**, utilizando **Oracle** como banco de dados. O projeto está containerizado com Docker e implementa um pipeline de CI/CD usando Azure DevOps para automação do build e deploy em ambientes de staging e produção.

## Funcionalidades

- Operações CRUD (Create, Read, Update, Delete) sobre dados de qualidade do ar
- API RESTful
- Integração com banco de dados Oracle
- Containerização com Docker
- Pipeline de CI/CD com Azure DevOps
- Deploy em múltiplos ambientes (staging e produção)

## Tecnologias Utilizadas

- **C# .NET 6.0**
- **Oracle Database** 
- **Docker** para containerização
- **Azure DevOps** para CI/CD
- **MongoDB** (caso tenha substituições ou coleções Mongo em uso)
- **Visual Studio 2022** ou superior
- **Kubernetes** (opcional para orquestração)

## Requisitos

Antes de iniciar, você precisará dos seguintes componentes instalados:

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Docker](https://www.docker.com/get-started)
- [Oracle Database](https://www.oracle.com/database/) ou [Oracle Instant Client](https://www.oracle.com/database/technologies/instant-client.html) para a integração com o banco de dados
- [Visual Studio 2022](https://visualstudio.microsoft.com/) com suporte ao .NET
- Conta no [Azure DevOps](https://dev.azure.com/)
- [Oracle Data Provider for .NET (ODP.NET)](https://www.oracle.com/database/technologies/dotnet-odacdeploy-downloads.html) instalado e configurado

## Como Executar o Projeto Localmente

### 1. Clonar o Repositório

Primeiro, clone o repositório do GitHub para o seu ambiente local:

```bash
git clone https://github.com/sofiabarbirato/Ambiental.git
cd Ambiental 

### 2. Restaurar Pacotes
dotnet restore

### 3. Configurar Conexão com o BD
{
  "ConnectionStrings": {
    "OracleDbConnection": "User Id=<seu_usuario>;Password=<sua_senha>;Data Source=<host>:<porta>/<servico>"
  }
}

### 4. Executar a Aplicação
dotnet run --project ./Ambiental/Ambiental.csproj

