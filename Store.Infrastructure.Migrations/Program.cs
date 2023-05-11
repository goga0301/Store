using Microsoft.EntityFrameworkCore;
using Store.Infrastructure.Repository.DbContexts;

var builder = WebApplication.CreateBuilder(args);
var devartConfig = Devart.Data.Oracle.Entity.Configuration.OracleEntityProviderConfig.Instance;
devartConfig.Workarounds.DisableQuoting = true;

builder.Services.AddDbContext<StoreDbContext>(options =>

    options.UseOracle(builder.Configuration.GetConnectionString("StoreDb"),
        options => options.MigrationsAssembly("Store.Infrastructure.Migrations")
        .MigrationsHistoryTable("EF_Migrations")));

var app = builder.Build();
app.Run();


