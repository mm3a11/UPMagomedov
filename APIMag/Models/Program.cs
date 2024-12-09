using Microsoft.EntityFrameworkCore;
using APIMag.Models;

var builder = WebApplication.CreateBuilder(args);

// Регистрация контекста базы данных
builder.Services.AddDbContext<EnvironmentalMonitoringContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрация контроллеров и других сервисов
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Настройка маршрутизации и Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
