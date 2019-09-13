
using JokJaBre.Core.Objects;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace JokJaBre.Core.API.Extensions
{
    public static class StartupExtensions
    {
        //public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        //{
        //    app.UseExceptionHandler(appError =>
        //    {
        //        appError.Run(async context =>
        //        {
        //            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //            context.Response.ContentType = "application/json";

        //            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        //            if (contextFeature != null)
        //            {
        //                await context.Response.WriteAsync(ApiExceptions.Error("Unknown error").ToString());
        //            }
        //        });
        //    });
        //}

        public static void AddJokJaBreScopedModel<TModel, TService, TRepository>(this IServiceCollection services)
            where TModel : class, IJokJaBreModel
            where TService : JokJaBreService<TModel>
            where TRepository : JokJaBreRepository<TModel>
        {
            services.AddTransient<IJokJaBreService<TModel>, TService>();
            services.AddTransient<IJokJaBreRepository<TModel>, TRepository>();
        }
        public static void AddJokJaBreScopedModel<TModel, TService>(this IServiceCollection services)
            where TModel : class, IJokJaBreModel
            where TService : JokJaBreService<TModel>
        {
            services.AddJokJaBreScopedModel<TModel, TService, JokJaBreRepository<TModel>>();
        }

        public static void AddJokJaBreScopedModel<TModel>(this IServiceCollection services)
            where TModel : class, IJokJaBreModel
        {
            services.AddJokJaBreScopedModel<TModel, JokJaBreService<TModel>>();
        }



    }
}