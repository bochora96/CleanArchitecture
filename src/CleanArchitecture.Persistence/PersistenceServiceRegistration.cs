﻿using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Application.Contracts.Persistence;

namespace CleanArchitecture.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<TodoDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Todos"))
        );

        services.AddScoped(typeof(IAsyncRepository<,>), typeof(BaseRepository<,>));
        services.AddScoped<ITodoRepository, TodoRepository>();

        return services;
    }
}