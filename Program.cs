// Program.cs
using Microsoft.EntityFrameworkCore; // Añade esta directiva using
using vinyls.Data; // Añade esta directiva using

var builder = WebApplication.CreateBuilder(args);

// --- Configuración de Servicios ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// **************************************************************************
// ** Nuevo: Configuración de la base de datos con PostgreSQL y EF Core **
// **************************************************************************
builder.Services.AddDbContext<VinylsDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// **************************************************************************
// ** Actualización: Cambiamos la inyección del repositorio para usar el DbContext **
// **************************************************************************
builder.Services.AddScoped<vinyls.Interfaces.IVinylRepository, vinyls.Repositories.VinylRepository>();

// --- Fin de configuración de Servicios ---

var app = builder.Build();

// --- Configuración del Pipeline de Solicitudes HTTP (Middleware) ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // PARA RESOLVER EL PROBLEMA "Failed to fetch" EN DESARROLLO:
    // Comenta o elimina la siguiente línea durante el desarrollo
    // si no tienes HTTPS configurado o si te está dando problemas.
    // app.UseHttpsRedirection();
}
else
{
    // Mantén la redirección HTTPS para producción si la necesitas
    app.UseHttpsRedirection();
}


app.MapControllers();


// **************************************************************************
// ** Opcional: Puedes eliminar o mantener el código de WeatherForecast **
// **************************************************************************
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

// **************************************************************************
// ** Fin de código opcional de WeatherForecast **
// **************************************************************************


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}