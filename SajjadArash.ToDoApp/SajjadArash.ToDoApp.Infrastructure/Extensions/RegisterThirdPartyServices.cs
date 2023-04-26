using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SajjadArash.ToDoApp.Infrastructure.Common.Behaviours;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System.Reflection;

namespace SajjadArash.ToDoApp.Infrastructure.Extensions
{
    public static class RegisterThirdPartyServices
    {
        /// <summary>
        /// کانفیگ کردن AutoMapper و MediatR و FluentValidation
        /// </summary>
        /// <param name="serviceAssembly">اسمبلی که سرویس ها داخل اون قرار دارند</param>
        /// <returns></returns>
        public static IServiceCollection RegisterThirdParties(this IServiceCollection services, Assembly serviceAssembly)
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel
                .Override("Microsoft", LogEventLevel.Information).Enrich.FromLogContext().WriteTo
                .File(Path.Combine(Directory.GetCurrentDirectory(), "LogFiles", "Application", "error.txt"),
                        rollingInterval: RollingInterval.Day,
                        fileSizeLimitBytes: 10 * 1024 * 1024,
                        retainedFileCountLimit: 2,
                        rollOnFileSizeLimit: true,
                        shared: true,
                        flushToDiskInterval: TimeSpan.FromSeconds(1)).CreateLogger();
            services.AddAutoMapper(serviceAssembly);
            services.AddValidatorsFromAssembly(serviceAssembly);
            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssembly(serviceAssembly);
                conf.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlerBehaviour<,>));
                conf.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
                conf.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            });
            return services;
        }
    }
}
