using Server;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

/// Servers database
List<string> Servers = new List<string>()
{
    // Empty for now, but the semicolon is required after list initialization.
};

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Add dev/test‑only features here if needed
}

app.UseHttpsRedirection();

app.MapHub<LogHub>("/logHub");

app.Run();