using HeroArchitect.Web.Domain;
using HeroArchitect.Web.Domain.Events;
using HeroArchitect.Web.Domain.State;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<Session>();
builder.Services.AddSingleton<IStateContainer, StateContainer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

var game = new Game(Guid.NewGuid(), new List<Player>() { new Player(Guid.NewGuid(), "imre") });
game.HandleEvent(new TurnEndEvent(Guid.NewGuid(), 1));

app.Run();