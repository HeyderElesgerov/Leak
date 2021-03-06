﻿using FluentValidation.Results;
using Leak.Application.AutoMapper;
using Leak.Application.Interfaces;
using Leak.Application.Services;
using Leak.Domain.Commands.Blog;
using Leak.Domain.Commands.Category;
using Leak.Domain.Commands.Post;
using Leak.Domain.Commands.SentPost;
using Leak.Domain.Commands.SpecialPostsSection;
using Leak.Domain.Models;
using Leak.Domain.Repository;
using Leak.Domain.UnitOfWork;
using Leak.Infrastructure.Data.Context;
using Leak.Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Leak.Infrastructure.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection WithAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(DomainToViewModelMappingProfile).Assembly,
                typeof(ViewModelToDomainMappingProfile).Assembly);

            return services;
        }

        public static IServiceCollection WithUnitOfWork(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IUnitOfWork, UnitOfWork>();
            return serviceDescriptors;
        }

        public static IServiceCollection WithRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBlogRepository, BlogRepository>();
            serviceCollection.AddScoped<IAppUserRepository, AppUserRepository>();
            serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddScoped<IPostRepository, PostRepository>();
            serviceCollection.AddScoped<ISentPostRepository, SentPostRepository>();
            serviceCollection.AddScoped<ISpecialPostsSectionRepository<InterestingPostSection>, SpecialPostsSectionRepository<InterestingPostSection>>();
            serviceCollection.AddScoped<ISpecialPostsSectionRepository<TrendPostSection>, SpecialPostsSectionRepository<TrendPostSection>>();

            return serviceCollection;
        }

        public static IServiceCollection WithServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBlogService, BlogService>();
            serviceCollection.AddScoped<IFileService, FileService>();
            serviceCollection.AddScoped<ICategoryService, CategoryService>();
            serviceCollection.AddScoped<IPostService, PostService>();
            serviceCollection.AddScoped<ISentPostService, SentPostService>();
            serviceCollection.AddScoped<IPostsSectionService<InterestingPostSection>, PostsSectionService<InterestingPostSection>>();
            serviceCollection.AddScoped<IPostsSectionService<TrendPostSection>, PostsSectionService<TrendPostSection>>();

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
            serviceCollection.AddScoped<IRequestHandler<UpdateBlogCommand, ValidationResult>, BlogCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<DeleteBlogCommand, ValidationResult>, BlogCommandHandler>();

            serviceCollection.AddScoped<IRequestHandler<CreateCategoryCommand, ValidationResult>, CategoryCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<UpdateCategoryCommand, ValidationResult>, CategoryCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<DeleteCategoryCommand, ValidationResult>, CategoryCommandHandler>();

            serviceCollection.AddScoped<IRequestHandler<CreatePostCommand, ValidationResult>, PostCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<UpdatePostCommand, ValidationResult>, PostCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<DeletePostCommand, ValidationResult>, PostCommandHandler>();

            serviceCollection.AddScoped<IRequestHandler<CreateSentPostCommand, ValidationResult>, SentPostCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<ApproveSentPostCommand, ValidationResult>, SentPostCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<DeleteSentPostCommand, ValidationResult>, SentPostCommandHandler>();

            serviceCollection
                .AddScoped<IRequestHandler<AddPostToPostsSectionCommand<InterestingPostSection>, ValidationResult>, PostsSectionCommandHandler<InterestingPostSection>>();
            serviceCollection
                .AddScoped<IRequestHandler<AddPostToPostsSectionCommand<TrendPostSection>, ValidationResult>, PostsSectionCommandHandler<TrendPostSection>>();

            serviceCollection
                .AddScoped<IRequestHandler<RemovePostFromPostsSectionCommand<InterestingPostSection>, ValidationResult>, PostsSectionCommandHandler<InterestingPostSection>>();
            serviceCollection
                .AddScoped<IRequestHandler<RemovePostFromPostsSectionCommand<TrendPostSection>, ValidationResult>, PostsSectionCommandHandler<TrendPostSection>>();

            return serviceCollection;
        }
    }
}
