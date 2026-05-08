# plateformes-de-gestion-Nutrition-Carnet-de-Recettes

## Objectif
Développer une application de gestion de recettes basée sur une base d'ingrédients contenant leur valeur énergétique (calories par unité).

## Architecture du Projet

### Structure globale
```
plateformes-de-gestion-Nutrition-Carnet-de-Recettes/
├── README.md                    # Documentation du projet
└── SmartNutrition/              # Application principale
    ├── Components/              # Composants Blazor
    │   ├── App.razor           # Point d'entrée de l'application
    │   ├── Layout/             # Composants de mise en page
    │   ├── Pages/              # Pages de l'application
    │   ├── UI/                 # Composants UI réutilisables
    │   ├── Routes.razor        # Configuration des routes
    │   └── _Imports.razor      # Imports globaux
    ├── Data/                   # Accès aux données
    │   └── AppDbContext.cs     # Contexte Entity Framework
    ├── Models/                 # Modèles de données
    │   ├── Location.cs         # Modèle des localisations
    │   ├── SensorData.cs       # Modèle des capteurs
    │   ├── SensorValueHistory.cs # Historique des valeurs
    │   └── Tag.cs              # Modèle des étiquettes
    ├── Services/               # Logique métier
    │   ├── ISensorService.cs   # Interface du service capteurs
    │   └── SensorService.cs    # Implémentation du service
    ├── Migrations/             # Migrations EF Core
    ├── wwwroot/               # Fichiers statiques
    ├── Program.cs             # Configuration et démarrage
    ├── SmartNutrition.csproj  # Fichier de projet .NET
    └── app.db                 # Base de données SQLite
```

### Technologie
- **Framework**: .NET 10.0 avec Blazor Server
- **Base de données**: SQLite avec Entity Framework Core
- **UI**: Radzen Blazor Components
- **Architecture**: MVC (Model-View-Controller) avec Services

### Composants principaux

#### 1. Models (Modèles de données)
- **SensorData**: Représente les capteurs avec leurs valeurs
- **Location**: Gestion des localisations des capteurs
- **Tag**: Système d'étiquetage pour les capteurs
- **SensorValueHistory**: Historique des valeurs des capteurs

#### 2. Data (Accès aux données)
- **AppDbContext**: Contexte Entity Framework Core
  - DbSet<SensorData> Sensors
  - DbSet<Location> Locations  
  - DbSet<Tag> Tags

#### 3. Services (Logique métier)
- **ISensorService**: Interface pour la gestion des capteurs
- **SensorService**: Implémentation avec opérations CRUD

#### 4. Components (Interface utilisateur)
- **App.razor**: Point d'entrée HTML de l'application
- **Pages**: Pages spécifiques de l'application
- **Layout**: Composants de mise en page réutilisables
- **UI**: Composants UI personnalisés

### Configuration
- **Program.cs**: Configuration des services, middleware et pipeline HTTP
- **appsettings.json**: Configuration de l'application
- **SmartNutrition.csproj**: Dépendances et configuration de build

### Base de données
- SQLite pour le développement
- Migrations automatiques avec EF Core
- Données de test générées au démarrage

### Dépendances principales
- Microsoft.EntityFrameworkCore.Sqlite (v10.0.3)
- Microsoft.EntityFrameworkCore.Design (v10.0.3)
- Radzen.Blazor (v10.3.0)

### Fonctionnalités
- Gestion des capteurs (CRUD)
- Suivi des valeurs en temps réel
- Historique des mesures
- Gestion des localisations
- Système d'étiquetage
- Interface utilisateur réactive
