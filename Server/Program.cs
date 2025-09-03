var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

/////// Servers database
List<string> Servers = new List<string>()
{
    
}

List<string> PipeNames = new List<string>()
{
    "HunterPipes_API",
    "HunterPipes_Core",
    "HunterPipes_CoreServices",
    "HunterPipes_DataModels",
    "HunterPipes_FinSvcsPlugin",
    "HunterPipes_IdentityDomain",
    "HunterPipes_PluginInfrastructure",
    "HunterPipes_Shared",
    "HunterPipes_SolutionTools"
};

app.UseHttpsRedirection();

/// look for server(s) signalR here

app.Run();
