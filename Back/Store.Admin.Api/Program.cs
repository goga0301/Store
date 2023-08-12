using Store.Admin.Handlers.Queries.Products;
using Store.Infrastructure.Repository;
using Store.Infrastructure.Service;
using Shared;
using Shared.Helpers;
using Store.Admin.Handlers.Handlers;
using RabbitMQ.Domains.Core.Bus;
using Store.Domain.Models.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContexts(builder.Configuration);
builder.Services.AddDomainServices();
builder.Services.AddRepositories();
builder.Services.AddCacheRepositories();
builder.Services.AddScoped<ExpirationTimeProvider>();

builder.Services.AddMemoryCache();
builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssembly(typeof(GetProductQuery).Assembly);
});
builder.Services.AddRabbitMQServices();

builder.Services.AddScoped<TransactionResultHandler>();
builder.Services.AddScoped<IEventHandler<TransactionResultEvent>, TransactionResultHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseError();
var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<TransactionResultEvent, TransactionResultHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
