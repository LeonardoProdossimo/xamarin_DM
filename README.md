# PessoasApp (.NET MAUI Blazor)

CRUD completo para cadastro de pessoas utilizando .NET MAUI + Blazor + SQLite com interface moderna baseada em Bootstrap.

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download) com o workload `maui`:  
  `dotnet workload install maui`
- Visual Studio 2022 (17.8+) com o componente `.NET Multi-platform App UI`

## Como executar

```bash
cd PessoasApp
dotnet restore
dotnet build -t:Run -f net8.0-windows10.0.19041.0
```

Alvos Android/iOS podem ser executados via Visual Studio selecionando o dispositivo desejado.

## Destaques

- UI responsiva em Blazor com Bootstrap 5.3 + Glassmorphism customizado.
- Repositório SQLite local (`sqlite-net-pcl`) com pesquisa por nome/e-mail/documento.
- Serviços injetados via DI (`PersonService` / `PersonRepository`).
- Estrutura pronta para Android, iOS, MacCatalyst e Windows.