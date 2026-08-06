using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using DA;
using Flujo;
using Microsoft.EntityFrameworkCore;
using Reglas;
using Servicios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IVideoJuegoDA, VideoJuegoDA>();
builder.Services.AddScoped<IVideoJuegoReglas, VideoJuegoReglas>();
builder.Services.AddScoped<IVideoJuegoFlujo, VideoJuegoFlujo>();
builder.Services.AddScoped<IVideoJuegoServicio, VideoJuegoServicio>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TiendaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirReact", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("PermitirReact");
app.UseAuthorization();
app.MapControllers();

app.Run();