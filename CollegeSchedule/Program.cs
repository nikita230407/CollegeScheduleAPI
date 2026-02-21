using Microsoft.EntityFrameworkCore;
using CollegeSchedule.Data;
using CollegeSchedule.Models; // Твоя папка с моделями

var builder = WebApplication.CreateBuilder(args);

// 1. Настройка подключения к PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// 2. Настройка CORS (разрешаем мобильному приложению доступ к API)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// 3. Стандартные сервисы API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. Включаем Swagger для тестирования
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Включаем CORS
app.UseCors();

app.UseAuthorization();
app.MapControllers();

app.Run();