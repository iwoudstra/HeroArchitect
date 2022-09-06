using HeroArchitect.App.Domain.State;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
{
    services.AddSingleton<IStateContainer, StateContainer>();
    services.AddSignalRCore();    
});

var app = builder.Build();

//app.MapHub<LobbyHub>("/lobby");
app.Run();