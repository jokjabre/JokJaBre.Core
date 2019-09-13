using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JokJaBre.Core.Identity.Extensions
{
    public static class StartupExtensions
    {

        public static void AddJokJaBreIdentity<TContext>(this IServiceCollection services)
            where TContext : DbContext
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 4;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                //options.SignIn.RequireConfirmedEmail = true;

            })
            .AddEntityFrameworkStores<TContext>()
            .AddDefaultTokenProviders();
        }
    }
}
