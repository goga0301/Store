

using Banking.Infrastructure.Repository.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BankingDbContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("BankingDb"),
        options => options.MigrationsAssembly("Banking.Infrastructure.Migrations")
        .MigrationsHistoryTable("EF_Migrations")));


var app = builder.Build();
app.Run();


