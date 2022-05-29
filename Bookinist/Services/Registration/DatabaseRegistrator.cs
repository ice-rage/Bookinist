﻿using Bookinist.DAL.Context;
using Bookinist.DAL.Repositories.Services.Registration;
using Bookinist.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bookinist.Services.Registration
{
    internal static class DatabaseRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services,
            IConfiguration configuration) => 
                services
                    .AddDbContext<BookinistDb>(options =>
                    {
                        string type = configuration["Type"];              

                        switch (type)
                        {
                            case null:
                                throw new InvalidOperationException(
                                    "The database type is not defined");

                            default:
                                throw new InvalidOperationException(
                                    $"The \"{type}\" connection type is not supported");

                            case "MSSQL":
                                options.UseSqlServer(configuration.GetConnectionString(type));
                                break;
                            case "SQLite":
                                options.UseSqlite(configuration.GetConnectionString(type));
                                break;
                            case "InMemory":
                                options.UseInMemoryDatabase("Bookinist.db");
                                break;

                        }
                    })
                    .AddTransient<DatabaseInitializer>()
                    .AddRepositoriesInDatabase()
        ;
    }
}