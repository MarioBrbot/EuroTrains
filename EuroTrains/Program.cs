using Microsoft.OpenApi.Models;
using EuroTrains.Data;
using EuroTrains.Domain.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// Add db context
builder.Services.AddDbContext<Entities>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EuroTrains")));



builder.Services.AddSwaggerGen( c =>
{
    c.AddServer(new OpenApiServer
    {
        Description = "Development Server",
        Url = "https://localhost:7098"
    });

    c.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["action"] + e.ActionDescriptor.RouteValues["controller"]}");
});

builder.Services.AddScoped<Entities>();

var app = builder.Build();

var entities = app.Services.CreateScope().ServiceProvider.GetService<Entities>();

entities.Database.EnsureCreated();

var random = new Random();
if (!entities.Trains.Any())
{
    Trains[] trainsToSeed = new Trains[]
    {
                new (   Guid.NewGuid(),
                        "Hrvatske Željeznice",
                        random.Next(90, 5000).ToString(),
                        new TimePlace("Zagreb",DateTime.Now.AddHours(random.Next(1, 3))),
                        new TimePlace("Sisak",DateTime.Now.AddHours(random.Next(4, 10))),
                        2),
                new (   Guid.NewGuid(),
                        "Hekurudha Shqiptare",
                        random.Next(90, 5000).ToString(),
                        new TimePlace("Tirana",DateTime.Now.AddHours(random.Next(1, 10))),
                        new TimePlace("Zagreb",DateTime.Now.AddHours(random.Next(4, 15))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Österreichische Bundesbahnen",
                        random.Next(90, 5000).ToString(),
                        new TimePlace("Vienna",DateTime.Now.AddHours(random.Next(1, 15))),
                        new TimePlace("Zagreb",DateTime.Now.AddHours(random.Next(4, 18))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Hrvatske Željeznice",
                        random.Next(90, 5000).ToString(),
                        new TimePlace("Osijek",DateTime.Now.AddHours(random.Next(1, 21))),
                        new TimePlace("Koprivnica",DateTime.Now.AddHours(random.Next(4, 21))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Hekurudha Shqiptare",
                        random.Next(90, 5000).ToString(),
                        new TimePlace("Tirana",DateTime.Now.AddHours(random.Next(1, 23))),
                        new TimePlace("Vienna",DateTime.Now.AddHours(random.Next(4, 25))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Österreichische Bundesbahnen",
                        random.Next(90, 5000).ToString(),
                        new TimePlace("Vienna",DateTime.Now.AddHours(random.Next(1, 15))),
                        new TimePlace("Graz",DateTime.Now.AddHours(random.Next(4, 19))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Österreichische Bundesbahnen",
                        random.Next(90, 5000).ToString(),
                        new TimePlace("Vienna",DateTime.Now.AddHours(random.Next(1, 55))),
                        new TimePlace("Ljubljana",DateTime.Now.AddHours(random.Next(4, 58))),
                        random.Next(1, 853)),
                new (   Guid.NewGuid(),
                        "Österreichische Bundesbahnen",
                        random.Next(90, 5000).ToString(),
                        new TimePlace("Salzburg",DateTime.Now.AddHours(random.Next(1, 58))),
                        new TimePlace("Zagreb",DateTime.Now.AddHours(random.Next(4, 60))),
                        random.Next(1, 853))
};
    entities.Trains.AddRange(trainsToSeed);
    entities.SaveChanges();
}
app.UseCors(builder => builder
    .WithOrigins("*")
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseSwagger().UseSwaggerUI();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
