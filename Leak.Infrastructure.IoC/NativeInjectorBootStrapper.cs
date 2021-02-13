using FluentValidation.Results;
using Leak.Application.Interfaces;
using Leak.Application.Services;
using Leak.Domain.Commands.Blog;
using Leak.Domain.Commands.Category;
using Leak.Domain.Commands.Post;
using Leak.Domain.Commands.SpecialPostsSection;
using Leak.Domain.Commands.Url;
using Leak.Domain.Models;
using Leak.Domain.Repository;
using Leak.Infrastructure.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leak.Infrastructure.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection WithRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBlogRepository>();
            serviceCollection.AddScoped<ICategoryRepository>();
            serviceCollection.AddScoped<IPostRepository>();
            serviceCollection.AddScoped<ISpecialPostsSectionRepository<InterestingPostSection>>();
            serviceCollection.AddScoped<ISpecialPostsSectionRepository<TrendPostSection>>();
            serviceCollection.AddScoped<IUrlRepository>();

            return serviceCollection;
        }

        public static IServiceCollection WithServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBlogService, BlogService>();
            serviceCollection.AddScoped<ICategoryService, CategoryService>();
            serviceCollection.AddScoped<IPostService, PostService>();
            serviceCollection.AddScoped<IPostsSectionService<InterestingPostSection>, PostsSectionService<InterestingPostSection>>();
            serviceCollection.AddScoped<IPostsSectionService<TrendPostSection>, PostsSectionService<TrendPostSection>>();
            serviceCollection.AddScoped<IUrlService, UrlService>();

            return serviceCollection;
        }

        public static IServiceCollection WithDbContext(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<LeakDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return serviceCollection;
        }

        public static IServiceCollection WithRequestHandlers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRequestHandler<CreateBlogCommand, ValidationResult>, BlogCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<DeleteBlogCommand, ValidationResult>, BlogCommandHandler>();

            serviceCollection.AddScoped<IRequestHandler<CreateCategoryCommand, ValidationResult>, CategoryCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<UpdateCategoryCommand, ValidationResult>, CategoryCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<DeleteCategoryCommand, ValidationResult>, CategoryCommandHandler>();

            serviceCollection.AddScoped<IRequestHandler<CreatePostCommand, ValidationResult>, PostCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<UpdatePostCommand, ValidationResult>, PostCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<DeletePostCommand, ValidationResult>, PostCommandHandler>();

            serviceCollection
                .AddScoped<IRequestHandler<AddPostToPostsSectionCommand<InterestingPostSection>, ValidationResult>, PostsSectionCommandHandler<InterestingPostSection>>();
            serviceCollection
                .AddScoped<IRequestHandler<AddPostToPostsSectionCommand<TrendPostSection>, ValidationResult>, PostsSectionCommandHandler<TrendPostSection>>();

            serviceCollection
                .AddScoped<IRequestHandler<RemovePostFromPostsSectionCommand<InterestingPostSection>, ValidationResult>, PostsSectionCommandHandler<InterestingPostSection>>();
            serviceCollection
                .AddScoped<IRequestHandler<RemovePostFromPostsSectionCommand<TrendPostSection>, ValidationResult>, PostsSectionCommandHandler<TrendPostSection>>();

            serviceCollection.AddScoped<IRequestHandler<CreateUrlCommand, ValidationResult>, UrlCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<UpdateUrlCommand, ValidationResult>, UrlCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<DeleteUrlCommand, ValidationResult>, UrlCommandHandler>();

            return serviceCollection;
        }
    }
}
