using DummySample.Server.Data;
using DummySample.Server.Interface;
using DummySample.Server.Service;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IDemo,DemoService>();
builder.Services.AddScoped<ISP,SPService>();
builder.Services.AddTransient<IDT,DTService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(policy=>policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
