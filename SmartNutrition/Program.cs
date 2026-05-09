using SmartNutrition.Components;
using SmartNutrition.Data;
using SmartNutrition.Models;
using SmartNutrition.Services;
using Microsoft.EntityFrameworkCore;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//===== Configure Entity Framework Core with SQLite ======

// Configure the DbContext to use SQLite with app.db file
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));
//================================================================================

// Register services as scoped services
builder.Services.AddScoped<IRecetteService, RecetteService>();
builder.Services.AddScoped<IUniteService, UniteService>();
builder.Services.AddScoped<ITypeCuisineService, TypeCuisineService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<ICategorieService, CategorieService>();
builder.Services.AddRadzenComponents();

var app = builder.Build();

//===== Create database and apply migrations ======
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate(); // Applique les migrations en attente
}
//================================================================================

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
