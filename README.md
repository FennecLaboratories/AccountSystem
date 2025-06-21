<div align="center" id="madewithlua">
  <img
    src="icon.png"
    width="300",
    height="350"
  />
</div>
<h1 align="center">FennecLabs - OrderSystem</h1>

<p align="center">
    <a href="https://t.me/FennecLabs"><img src="https://img.shields.io/badge/Telegram-2CA5E0?style=for-the-badge&logo=telegram&logoColor=white"></a>
    <a><img src ="https://img.shields.io/badge/ASP.NET%20CORE-%23EE4C2C.svg?style=for-the-badge&logo=ASP.NETCore&logoColor=white" ></a>
</p>


# Features 🌟
- Perfect Accaount Control and  EF Core based system
- Good UI & UX
- Secure

# Backend 🌘
- ORM based
- powered by Postgres
- made by N-tier architecture

# Frontend ☀️
- ???
- ???
- ???


```mermaid
graph TD
  A[📦 Root Directory]
  
  subgraph Client
    AC[AwesomeClient/Readme.txt]
  end
  
  A --> AC
  A --> IG[.gitignore]
  A --> LIC[LICENSE]
  A --> RM[README.md]
  A --> ICON[icon.png]
  
  subgraph Source [source/]
    subgraph API [OrderSystem.API/]
      API1[Controllers/]
      API2[Program.cs]
      API3[OrderSystem.API.csproj]
      API4[OrderSystem.API.http]
      API5[WeatherForecast.cs]
      API6[appsettings.json]
      API7[appsettings.Development.json]
      API8[Properties/launchSettings.json]
      API1 --> WC[WeatherForecastController.cs]
    end
    
    subgraph BLL [OrderSystem.BLL/]
      BLL1[OrderSystem.BLL.csproj]
    end
    
    subgraph DAL [OrderSystem.DataAccess/]
      subgraph Configs [Configurations/]
        CFG1[CategoryConfiguration.cs]
        CFG2[OrderConfiguration.cs]
        CFG3[UserConfigurations.cs]
        CFG4[Wishlist.cs]
      end
      subgraph Entities [Entities/]
        ENT1[Category.cs]
        ENT2[Order.cs]
        ENT3[User.cs]
        ENT4[Wishlist.cs]
      end
      DAL1[OrderSystem.DataAccess.csproj]
    end
    
    subgraph Repo [OrderSystem.Repository/]
      REPO1[MainContext.cs]
      REPO2[OrderSystem.Repository.csproj]
    end
  end

  A --> Source
  Source --> API
  Source --> BLL
  Source --> DAL
  Source --> Repo
