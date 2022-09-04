using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RepositoryUnitOfWork.API.Services;
using RepositoryUnitOfWork.Domain.Departments;
using RepositoryUnitOfWork.Domain.Interfaces;
using RepositoryUnitOfWork.Domain.Salaries;
using RepositoryUnitOfWork.Domain.Users;
using RepositoryUnitOfWork.Infrastructure;
using RepositoryUnitOfWork.Infrastructure.Repositories;
using System;
using System.IO;
using System.Reflection;

namespace RepositoryUnitOfWork.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext with Scoped lifetime
            services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("MyConnection"));
                    options.UseLazyLoadingProxies();
                }
            );

            services.AddScoped<Func<AppDbContext>>((provider) => () => provider.GetService<AppDbContext>());
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IDepartmentRepository, DepartmentRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ISalaryRepository, SalaryRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<DepartmentService>();
        }

        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Repository Unit Of Work",
                        Version = "v1",
                        Description = "API da aplicação consultório legal.",
                        Contact = new OpenApiContact
                        {
                            Name = "Rondinele Guimarães",
                            Email = "rondineleg@gmail.com",
                            Url = new Uri("https://github.com/rondineleg/RepositoryUnitOfWork")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "OSD",
                            Url = new Uri("https://opensource.org/osd")
                        },
                        TermsOfService = new Uri("https://opensource.org/osd")
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "Repository UnitOfWork");
            });
        }
    }
}
