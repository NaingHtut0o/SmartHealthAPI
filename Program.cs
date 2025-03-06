using Microsoft.EntityFrameworkCore;
using Serilog;
using SmartHealthAPI.Data;
using SmartHealthAPI.Extensions;
using SmartHealthAPI.Utilities;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDb>(options => options.UseNpgsql(connectionString));

var baseLogPath = builder.Configuration.GetValue<string>("LogSettings:BaseLogPath");
var maxLines = builder.Configuration.GetValue<int>("LogSettings:MaxLines");

// Logging
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Sink(new LineBasedFileSink(baseLogPath, maxLines))
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddScopedServiceByNamespace("SmartHealthAPI.Businesses.Repositories");
builder.Services.AddScopedServiceByNamespace("SmartHealthAPI.Businesses.Services");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
