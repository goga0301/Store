using Microsoft.EntityFrameworkCore;
using Store.Infrastructure.Repository.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StoreDbContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreDb"),
        options => options.MigrationsAssembly("Store.Infrastructure.Migrations")
        .MigrationsHistoryTable("EF_Migrations")));

var app = builder.Build();
app.Run();


