using Store.Admin.Handlers.Queries.Products;
using Store.Infrastructure.Repository;
using Store.Infrastructure.Service;
using Shared;
using Shared.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContexts(builder.Configuration);
builder.Services.AddDomainServices();
builder.Services.AddRepositories();
builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssembly(typeof(GetProductQuery).Assembly);
});
builder.Services.AddRabbitMQServices();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
