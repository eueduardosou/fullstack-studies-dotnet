# Weather Forecast API

API RESTful desenvolvida em ASP.NET Core 8.0 para fornecer previsões meteorológicas.

## 📋 Sobre o Projeto

Esta é uma API educacional que demonstra boas práticas de desenvolvimento em .NET, incluindo:
- Arquitetura em camadas (Controllers, Services, Models)
- Injeção de Dependência (DI)
- Documentação com Swagger/OpenAPI
- Padrão Repository/Service

## 🚀 Tecnologias

- **.NET 8.0**
- **ASP.NET Core Web API**
- **Swashbuckle (Swagger)**
- **C# 12**

## 📁 Estrutura do Projeto

```
WebApplication1/
├── Controllers/         # Endpoints da API
│   ├── WeatherForecastController.cs
│   └── HelloWorldController.cs
├── Services/           # Lógica de negócio
│   ├── IWeatherForecastService.cs
│   └── WeatherForecastService.cs
├── Models/            # Modelos de dados
│   └── WeatherForecast.cs
├── Program.cs         # Configuração e inicialização
└── appsettings.json   # Configurações da aplicação
```

## 🔧 Como Executar

### Pré-requisitos
- .NET 8.0 SDK instalado
- IDE (Visual Studio, VS Code, ou JetBrains Rider)

### Passos

1. Clone o repositório
```bash
git clone <seu-repositorio>
cd WebApplication1
```

2. Restaure as dependências
```bash
dotnet restore
```

3. Execute a aplicação
```bash
dotnet run --project WebApplication1/WebApplication1.csproj
```

4. Acesse a documentação Swagger
```
https://localhost:7073/swagger
```

## 📡 Endpoints

### Weather Forecast

#### GET /api/weatherforecast
Obtém previsões do tempo para os próximos dias.

**Parâmetros de Query:**
- `days` (opcional): Número de dias (1-30, padrão: 5)

**Exemplo:**
```bash
GET https://localhost:7073/api/weatherforecast?days=7
```

**Resposta:**
```json
[
  {
    "date": "2025-11-24",
    "temperatureC": 25,
    "temperatureF": 77,
    "summary": "Warm"
  }
]
```

#### GET /api/weatherforecast/by-date
Obtém previsão para uma data específica.

**Parâmetros de Query:**
- `date`: Data no formato yyyy-MM-dd

**Exemplo:**
```bash
GET https://localhost:7073/api/weatherforecast/by-date?date=2025-11-30
```

### Hello World

#### GET /helloworld/eduardo
Endpoint de teste simples.

**Resposta:**
```
"Hello World!"
```

## 🧪 Testando com Insomnia/Postman

1. **Importe a URL base:** `https://localhost:7073`
2. **Crie requisições GET** para os endpoints acima
3. **Importante:** Configure para aceitar certificados SSL auto-assinados (desenvolvimento)

### Exemplo de Requisição no Insomnia:

```
GET https://localhost:7073/api/weatherforecast?days=5
```

## 🏗️ Arquitetura

### Controllers
Responsáveis por receber requisições HTTP e retornar respostas. Validam dados de entrada e delegam lógica para os Services.

### Services
Contêm toda a lógica de negócio. Isolam a lógica dos Controllers, facilitando testes e manutenção.

### Models
Definem a estrutura dos dados da aplicação. Usam `record` types para imutabilidade.

### Injeção de Dependência
O ASP.NET Core gerencia automaticamente a criação e ciclo de vida dos Services através do container DI.

## 📝 Configurações

### appsettings.json
Configurações gerais da aplicação.

### launchSettings.json
Configurações de execução e portas:
- HTTPS: `https://localhost:7073`
- HTTP: `http://localhost:5037`

## 🤝 Contribuindo

1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto é open source e está disponível para fins educacionais.

## ✨ Autor

Desenvolvido como projeto educacional para aprendizado de ASP.NET Core Web APIs.

