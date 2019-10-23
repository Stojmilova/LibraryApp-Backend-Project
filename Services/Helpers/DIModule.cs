using DataAccess;
using DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Helpers
{
    public static class DIModule
    {
        public static IServiceCollection RegisterModule(
         IServiceCollection services, string connectionString)
        {
            services.AddDbContext<LibraryAppDbContext>(x =>
                x.UseSqlServer(connectionString));
            services.AddTransient<IRepository<BookDTO>, BookRepository>();
            services.AddTransient<IRepository<UserDTO>, UserRepository>();

            return services;
        }
    }
}
