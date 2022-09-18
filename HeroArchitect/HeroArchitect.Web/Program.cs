using HeroArchitect.Web.ClientCommunication;
using HeroArchitect.Web.Domain.State;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;    
});

builder.Services.AddScoped<ISessionContainer, SessionContainer>();
builder.Services.AddSingleton<IStateContainer, StateContainer>();

var corsOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsOrigins, policy =>
    {
        policy.WithOrigins("https://localhost:5173").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(corsOrigins);

app.MapHub<OverviewHub>("/overview");
app.MapHub<LobbyHub>("/lobby");

app.Run();