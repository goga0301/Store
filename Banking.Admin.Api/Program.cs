using Shared;
using Shared.Helpers;
using Banking.Infrastructure.Repository;
using Banking.Infrastructure.Service;
using RabbitMQ.Domains.Core.Bus;
using Banking.Domain.Models.Models;
using Banking.Handlers.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContexts(builder.Configuration);
builder.Services.AddDomainServices();
builder.Services.AddRepositories();


builder.Services.AddRabbitMQServices();
builder.Services.AddScoped<CreateTransactionHandler>(); 
builder.Services.AddScoped<IEventHandler<CreateTransactionEvent>, CreateTransactionHandler>();

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

var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<CreateTransactionEvent, CreateTransactionHandler>();

app.UseError();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
