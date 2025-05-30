
using Ajudae.App.Configuration;
using MediatR;
using src.Configuration;
using webapi.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.AddSwaggerConfiguration();

builder.Services.AddApiConfiguration(configuration);

builder.Services.AddIdentityConfiguration(configuration);

builder.Services.RegisterServices();

builder.Services.AddMediatR(typeof(Program));

var app = builder.Build();

app.UseApiConfiguration();

app.Run();