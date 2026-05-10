# SmartNutrition 🍳

Une application web moderne de gestion de recettes et d'ingrédients développée avec Blazor Server et Entity Framework Core.

## 📋 Table des matières

- [🎯 Fonctionnalités](#-fonctionnalités)
- [🛠️ Technologies utilisées](#️-technologies-utilisées)
- [📁 Structure du projet](#-structure-du-projet)
- [🚀 Démarrage rapide](#-démarrage-rapide)
- [📚 Documentation](#-documentation)
- [🎨 Interface utilisateur](#-interface-utilisateur)
- [🔧 Configuration](#-configuration)

## 🎯 Fonctionnalités

### 📊 Tableau de bord
- **Statistiques en temps réel** : Recettes, ingrédients, catégories, types de cuisine, unités
- **Actions rapides** : Accès direct aux formulaires d'ajout
- **Dernières recettes** : Vue des 5 dernières recettes ajoutées
- **Navigation rapide** : Accès rapide à toutes les sections

### 🍽 Gestion des recettes
- **CRUD complet** : Créer, lire, mettre à jour, supprimer des recettes
- **Recherche avancée** : Recherche par nom de recette
- **Détails enrichis** : Affichage des ingrédients, catégories, types de cuisine
- **Associations** : Gestion des liens recettes-ingrédients avec quantités

### 🥬 Gestion des ingrédients  
- **CRUD complet** : Gestion des ingrédients avec leurs propriétés
- **Informations nutritionnelles** : Calories, protéines, glucides, lipides
- **Unités** : Association automatique avec les unités de mesure
- **Recherche** : Recherche par nom d'ingrédient

### 🏷️ Gestion des catégories
- **CRUD complet** : Gestion des catégories de recettes
- **Icônes** : Support des icônes pour chaque catégorie
- **Recherche** : Recherche par libellé ou icône

### 🌍 Gestion des types de cuisine
- **CRUD complet** : Gestion des types de cuisine
- **Origine** : Support des pays d'origine
- **Recherche** : Recherche par libellé ou pays

### 📏 Gestion des unités
- **CRUD complet** : Gestion des unités de mesure
- **Symboles** : Support des symboles (kg, g, ml, etc.)
- **Recherche** : Recherche par libellé ou symbole

### 🔗 Gestion des associations
- **Liens recettes-ingrédients** : Gestion des quantités par recette
- **Visualisation** : Affichage clair des associations
- **Recherche** : Recherche par recette ou ingrédient

## 🛠️ Technologies utilisées

### Frontend
- **Blazor Server** : Framework web .NET pour UI interactive
- **Bootstrap 5** : Framework CSS pour design responsive
- **Bootstrap Icons** : Icônes modernes et cohérentes
- **HTML5/CSS3** : Standards web modernes

### Backend
- **ASP.NET Core 10** : Framework web performant
- **Entity Framework Core** : ORM pour accès aux données
- **SQLite** : Base de données légère et portable
- **C# 10** : Langage de programmation moderne

### Architecture
- **Pattern Repository/Service** : Séparation des responsabilités
- **Dependency Injection** : Injection de dépendances
- **Code-First Approach** : Génération de base de données depuis les modèles

## 📁 Structure du projet

```
SmartNutrition/
├── Components/
│   ├── Layout/              # Mise en page principale
│   │   ├── MainLayout.razor
│   │   └── NavMenu.razor
│   ├── Pages/               # Pages de l'application
│   │   ├── Index.razor      # Tableau de bord
│   │   ├── Categories/       # Gestion des catégories
│   │   ├── Ingredients/      # Gestion des ingrédients
│   │   ├── Recettes/         # Gestion des recettes
│   │   ├── TypesCuisine/    # Gestion des types de cuisine
│   │   ├── Unites/          # Gestion des unités
│   │   └── RecetteIngredients/ # Gestion des associations
│   └── UI/                 # Composants réutilisables
│       ├── ConfirmationModal.razor
│       ├── DetailsModal.razor
│       └── FormModal.razor
├── Data/
│   └── AppDbContext.cs      # Contexte Entity Framework
├── Models/                 # Modèles de données
│   ├── Categorie.cs
│   ├── Ingredient.cs
│   ├── Recette.cs
│   ├── RecetteIngredient.cs
│   ├── TypeCuisine.cs
│   └── Unite.cs
├── Services/               # Services métier
│   ├── ICategorieService.cs
│   ├── IIngredientService.cs
│   ├── IRecetteService.cs
│   ├── ITypeCuisineService.cs
│   ├── IUniteService.cs
│   └── Implémentations...
├── Migrations/             # Migrations Entity Framework
├── Extensions/              # Méthodes d'extension
│   └── DateTimeExtensions.cs
├── wwwroot/               # Fichiers statiques
│   ├── lib/
│   │   └── bootstrap/
│   └── app.css
├── Program.cs              # Point d'entrée
└── SmartNutrition.csproj   # Fichier de projet
```

## 🚀 Démarrage rapide

### Prérequis
- **.NET 10 SDK** ou plus récent
- **Visual Studio 2022** ou **VS Code** avec extension C#
- **Git** (optionnel)

### Installation
1. **Cloner le repository**
   ```bash
   git clone <repository-url>
   cd SmartNutrition
   ```

2. **Restaurer les dépendances**
   ```bash
   dotnet restore
   ```

3. **Créer la base de données**
   ```bash
   dotnet ef database update
   ```

4. **Lancer l'application**
   ```bash
   dotnet run
   ```

5. **Accéder à l'application**
   ```
   http://localhost:5000
   ```

### Développement
- **Mode développement** : `dotnet watch` pour rechargement automatique
- **Hot Reload** : Supporté pour modifications CSS et Razor
- **Debug** : Support complet du debugging

## 📚 Documentation

### Pages principales
- **`/`** : Tableau de bord avec statistiques et navigation rapide
- **`/gestion-recettes`** : Gestion des recettes
- **`/gestion-ingredients`** : Gestion des ingrédients
- **`/gestion-categories`** : Gestion des catégories
- **`/gestion-types-cuisine`** : Gestion des types de cuisine
- **`/gestion-unites`** : Gestion des unités
- **`/gestion-recette-ingredients`** : Gestion des associations

### Fonctionnalités CRUD
Chaque entité supporte les opérations :
- **Create** : `.../ajouter`
- **Read** : `.../detail/{id}`
- **Update** : `.../modifier/{id}`
- **Delete** : Bouton de suppression avec confirmation

### Recherche
Toutes les pages de gestion incluent :
- **Recherche en temps réel** : Résultats instantanés
- **Multi-champs** : Recherche dans plusieurs propriétés
- **Case-insensitive** : Non sensible à la casse

## 🎨 Interface utilisateur

### Design moderne
- **Responsive Design** : Adapté mobile, tablette, desktop
- **Material Design** : Cartes avec ombres et animations
- **Color Cohérent** : Palette de couleurs harmonieuse
- **Icons Intégrés** : Icônes Bootstrap cohérentes

### Animations et interactions
- **Hover Effects** : Survol des cartes et boutons
- **Loading States** : Spinners et messages de chargement
- **Empty States** : Messages clairs quand aucune donnée
- **Micro-interactions** : Transitions fluides et feedback

### Accessibilité
- **Contraste élevé** : Textes lisibles
- **Navigation clavier** : Support complet au clavier
- **Screen Reader** : Compatible avec lecteurs d'écran
- **Semantic HTML** : Structure sémantique correcte

## 🔧 Configuration

### Base de données
- **SQLite par défaut** : Fichier `app.db` local
- **Entity Framework** : Migrations automatiques
- **Seed Data** : Données initiales optionnelles

### Services
- **Dependency Injection** : Services configurés dans `Program.cs`
- **Scoped Lifetime** : Instances par requête HTTP
- **Error Handling** : Gestion centralisée des erreurs

### Logging
- **Console Logging** : Logs de développement
- **Error Tracking** : Traçage des exceptions
- **Performance Monitoring** : Temps de réponse

## 🚀 Fonctionnalités avancées

### Recherche intelligente
- **Fuzzy Search** : Recherche approximative
- **Auto-complete** : Suggestions de recherche
- **Filters** : Filtres multiples combinés
- **History** : Historique des recherches

### Performance
- **Lazy Loading** : Chargement progressif des données
- **Caching** : Mise en cache des requêtes fréquentes
- **Pagination** : Navigation par pages pour grands volumes
- **Optimized Queries** : Requêtes SQL optimisées

### Sécurité
- **Input Validation** : Validation côté serveur
- **CSRF Protection** : Protection contre CSRF
- **SQL Injection** : Protection via Entity Framework
- **XSS Prevention** : Encodage automatique

## 📈 Évolutions futures

### Fonctionnalités prévues
- **Import/Export** : Importation CSV, exportation PDF
- **Images** : Support des photos de recettes
- **Partage** : Partage social des recettes
- **Mode Offline** : Application progressive web
- **API REST** : API pour applications mobiles

### Améliorations techniques
- **Tests Unitaires** : Couverture de tests complète
- **CI/CD** : Intégration et déploiement automatique
- **Monitoring** : Surveillance performance et erreurs
- **Docker** : Conteneurisation de l'application

## 🤝 Contribuer

### Comment contribuer
1. **Forker** le projet
2. **Créer une branche** : `git checkout -b feature/nouvelle-fonctionnalite`
3. **Commiter** les changements : `git commit -am "Ajout de fonctionnalité"`
4. **Pusher** la branche : `git push origin feature/nouvelle-fonctionnalite`
5. **Pull Request** : Soumettre pour review

### Standards de code
- **C# Style** : Suivre les conventions Microsoft
- **Comments** : Code documenté en XML
- **Naming** : Noms clairs et descriptifs
- **Clean Code** : Code simple et maintenable

## 📄 Licence

Ce projet est sous licence **MIT** - voir le fichier `LICENSE` pour plus de détails.

## 👨‍💻 Auteur

**SmartNutrition** - Application de gestion de recettes moderne

*Développé avec ❤️ en C# et Blazor*

---

**Pour plus d'informations** :
- 📧 Contact : [contact@example.com]
- 🌐 Site web : [https://example.com]
- 📚 Documentation : [https://docs.example.com]
