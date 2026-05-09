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
    │   ├── Tag.cs              # Modèle des étiquettes
    │   ├── Categorie.cs        # Catégories de recettes
    │   ├── TypeCuisine.cs      # Types de cuisine
    │   ├── Unite.cs            # Unités de mesure
    │   ├── Ingredient.cs       # Ingrédients avec valeurs nutritionnelles
    │   ├── Recette.cs          # Recettes avec ingrédients et informations
    │   └── RecetteIngredient.cs # Table de liaison Recette-Ingredient
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
- **Categorie**: Catégories de recettes (Déjeuner, Dîner, etc.) avec icônes
- **TypeCuisine**: Types de cuisine (Tunisienne, Française, etc.) avec pays d'origine
- **Unite**: Unités de mesure (Gramme, Millilitre, etc.) avec symboles
- **Ingredient**: Ingrédients avec valeurs nutritionnelles et macronutriments
- **Recette**: Recettes avec ingrédients, catégories et types de cuisine
- **RecetteIngredient**: Table de liaison many-to-many entre recettes et ingrédients

**Data Annotations utilisées :**
- **[Required]**: Génère une contrainte NOT NULL en base de données
- **[Range]**: Validation côté serveur ET client pour les valeurs numériques
- **[MaxLength]**: Limite la taille des colonnes SQLite selon la valeur spécifiée

**Relations complètes entre les modèles :**
- **Categorie 1→N Recette**: Une catégorie peut contenir plusieurs recettes
- **TypeCuisine 1→N Recette**: Un type de cuisine peut regrouper plusieurs recettes
- **Unite 1→N Ingredient**: Une unité de mesure peut être utilisée par plusieurs ingrédients
- **Recette N→N Ingredient**: Relation many-to-many via la table de liaison RecetteIngredient

**Comportements de suppression (OnDelete) :**
- **Cascade**: Suppression en cascade sur RecetteIngredient (si recette supprimée)
- **Restrict**: Protection des tables de référence (pas de suppression si utilisées)

#### 2. Data (Accès aux données)
- **AppDbContext**: Contexte Entity Framework Core avec configuration complète
  - **Tables principales**: Ingredients, Recettes, RecetteIngredients
  - **Tables de référence**: Categories, TypesCuisine, Unites
  - **Relations configurées** avec comportements de suppression
  - **Seed data**: Données initiales pour les tables de référence

**Configuration SQLite :**
```csharp
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlite("Data Source=app.db"));
```

**Base de données :**
- Fichier SQLite créé à la racine : `app.db`
- 6 tables avec relations et contraintes
- Données de seed automatiques au démarrage

**Migrations EF Core :**
```bash
# Installer les outils EF
dotnet tool install --global dotnet-ef

# Ajouter les packages
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design

# Créer la migration initiale
dotnet ef migrations add InitialCreate

# Appliquer en base
dotnet ef database update
```

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
