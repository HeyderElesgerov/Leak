using FluentValidation.Results;
using Leak.Application.Interfaces;
using Leak.Application.Services;
using Leak.Domain.Commands.Category;
using Leak.Infrastructure.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leak.Infrastructure.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<LeakDbContext>(options =>
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            // Domain - Commands
            serviceCollection.AddScoped<IRequestHandler<CreateCategoryCommand, ValidationResult>, CategoryCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<UpdateCategoryCommand, ValidationResult>, CategoryCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<DeleteCategoryCommand, ValidationResult>, CategoryCommandHandler>();

            //Repos
            //serviceCollection.AddScoped<ICategoryRepository>();

            //Services
            serviceCollection.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
