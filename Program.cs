using Microsoft.EntityFrameworkCore;
using ProjetFileRouge.Data;
using ProjetFileRouge.Services;
using ProjetFileRouge.Services.Impl;



var builder = WebApplication.CreateBuilder(args);
// Configure the database connection string
string connectionString = builder.Configuration.GetConnectionString("MysqlConnection")!;

builder.Services.AddDbContext<ApplicationDbContext>(options =>

            options.UseMySql(connectionString,

            new MySqlServerVersion(new Version(10, 4, 32))));


// Configure the services for the application.
/* 
    AddTransient => Créer à chaque fois
    AddScoped => Créer une instance unique pour la durée de la requête
    AddSingleton => Créer une instance unique pour toute la durée de l'application
 */
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IDetteService, DetteService>();
builder.Services.AddScoped<IPaiementService, PaiementService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
