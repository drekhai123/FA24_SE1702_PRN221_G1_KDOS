
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishManagementRespository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FishHealthManagementDAO;
using Microsoft.Extensions.Hosting;
using KDOS.Data.Data;

namespace KoiFishManagementService
{
    public static class DependencyServices
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<FA24_SE1702_PRN221_G1_KDOSContext>>();
            return services;
        }
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            services.AddDbContext<FA24_SE1702_PRN221_G1_KDOSContext>(options =>
                options.UseSqlServer(CreateConnectionString(configuration)));

            return services;
        }

        private static string CreateConnectionString(IConfiguration configuration)
        {

            var connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionStringDB");
            return connectionString;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
           
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IFishHelthRepository, FishHelthRepository>();
            services.AddScoped<IFishHelthDAO, FishHelthDAO>();
            services.AddScoped<IFishHelthService, FishHelthService>();
            services.AddScoped<IAccountRespository, AccountRespository>();
            services.AddSingleton<IHostedService, KoiFishWorkerService>();

            return services;
        }

    }
}
