using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using ApplicationCore.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Wire up repositories
builder.Services.AddScoped<ICurrencyExchangeRepository, CurrencyExchangeRepository>();

// Wire up services
builder.Services.AddScoped<ICommandService<AddCurrencyExchangeCommand>, AddCurrencyExchangeService>();
builder.Services.AddScoped<ICommandService<UpdateCurrencyExchangeCommand>, UpdateCurrencyExchangeService>();
builder.Services.AddScoped<IQueryService<string, CurrencyRate>, GetCurrencyExchangesService>();

// Add In Memory DB
builder.Services.AddDbContext<CurrencyExchangeContext>(opt => opt.UseInMemoryDatabase("ExchangeCurrencyDb"));
builder.Services.AddScoped<CurrencyExchangeContext>();

builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo()
{
    Title = "Currency Exchange Rates API",
    Description = "This API provides currency exchange rates for the following currencies " +
        "British Pound (GBP), Euro (EUR) United States Dollar (USD), and Peruvian Sol (PEN)."
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

// Add global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
