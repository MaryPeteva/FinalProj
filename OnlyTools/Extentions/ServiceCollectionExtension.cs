using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using OnlyTools.Core.Contracts;
using OnlyTools.Core.Services;
using OnlyTools.Infrastructure.Data;
using OnlyTools.Infrastructure.Data.IdentityModels;
using OnlyTools.Infrastructure.Data.Seed.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddScoped<OnlyToolsSeeder>();
            services.AddScoped<IToolServices, ToolServices>();
            services.AddScoped<ITipServices, TipServices>();
            services.AddScoped<ICategoriesServices, CategoriesServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IPaginationService, PaginationService>();



            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            // Add DbContext
            services.AddDbContext<OnlyToolsDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Add Database Developer Page Exception Filter
            services.AddDatabaseDeveloperPageExceptionFilter();

            // Build the service provider to resolve services
            var serviceProvider = services.BuildServiceProvider();
            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<OnlyToolsDbContext>();
            return services;
        }


    }
}
