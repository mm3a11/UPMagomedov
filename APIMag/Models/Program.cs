using Microsoft.EntityFrameworkCore;
using APIMag.Models;

var builder = WebApplication.CreateBuilder(args);

// ����������� ��������� ���� ������
builder.Services.AddDbContext<EnvironmentalMonitoringContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ����������� ������������ � ������ ��������
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ��������� ������������� � Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
