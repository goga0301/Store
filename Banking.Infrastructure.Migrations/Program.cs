

using Banking.Infrastructure.Repository.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var devartConfig = Devart.Data.Oracle.Entity.Configuration.OracleEntityProviderConfig.Instance;
devartConfig.Workarounds.DisableQuoting = true;

builder.Services.AddDbContext<BankingDbContext>(options =>

    options.UseOracle(builder.Configuration.GetConnectionString("BankingDb"),
        options => options.MigrationsAssembly("Banking.Infrastructure.Migrations")
        .MigrationsHistoryTable("EF_Migrations")));

var app = builder.Build();
app.Run();


