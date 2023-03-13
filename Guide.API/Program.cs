using Guide.Application.Input.Interfaces;
using Guide.Application.Input.Receivers;
using Guide.Application.Output.Interfaces;
using Guide.Domain.Entities;
using Guide.Infrastructure.Input.Repositories;
using Guide.Infrastructure.Output.Repositories;
using Guide.Infrastructure.Shared.Factory;
using Guide.Infrastructure.Shared.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<SqlFactory>();
builder.Services.AddTransient<IYahooFinanceRepository, YahooFinanceRepository>();
builder.Services.AddTransient<IYahooFinanceService, YahooFinanceService>();
builder.Services.AddTransient<IYahooInputRepository, YahooInputRepository>();
builder.Services.AddTransient<InsertReceiver>();

var app = builder.Build();

app.MapGet("/YahooFinance/ABEV3/GetInformations/", ([FromServices] IYahooFinanceRepository repository) =>
{
    return repository.GetAll();
});

app.MapPost("/YahooFinance/ABEV3/InsertInformations/", ([FromServices] InsertReceiver receiver, [FromBody] List<YahooFinanceEntity> entity) =>
{
    return receiver.Action(entity);
});

app.MapGet("/YahooFinance/ABEV3/GetHistorico30Dias/", ([FromServices] IYahooFinanceRepository repository) =>
{
    return repository.GetHistoric30Days();
});

app.Run();
