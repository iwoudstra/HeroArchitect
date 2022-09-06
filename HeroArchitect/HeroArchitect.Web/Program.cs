using HeroArchitect.Web.ClientCommunication;
using HeroArchitect.Web.Domain.State;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddScoped<ISessionContainer, SessionContainer>();
builder.Services.AddSingleton<IStateContainer, StateContainer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapHub<LobbyHub>("/lobby");

app.Run();