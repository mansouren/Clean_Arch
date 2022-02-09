using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Domain.Contracts;
using CleanArch.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Ioc
{
   public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICourseRepositroy, CourseRepository>();
        }
    }
}
