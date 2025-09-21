using Server;
using Server.Database;


var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorizationCore();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Map API controllers
app.MapControllers();

// Run the seeding (from Hunter's Seed.cs + Seed.json)
Seed.SeedData(app);

app.MapHub<ObserverHub>("/observerhub");

app.Run();