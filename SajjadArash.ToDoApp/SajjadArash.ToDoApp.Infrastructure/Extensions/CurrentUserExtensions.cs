using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SajjadArash.ToDoApp.Infrastructure.Common.Interfaces;
using SajjadArash.ToDoApp.Infrastructure.Enums;
using SajjadArash.ToDoApp.Infrastructure.Implementations;
using System.Security.Claims;

namespace SajjadArash.ToDoApp.Infrastructure.Extensions
{
    public static class CurrentUserExtensions
    {
        /// <summary>
        /// معرفی کردن شیوه ایجاد شی CurrentUser برای DI Service 
        /// </summary>
        public static IServiceCollection RegisterCurrentUser(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUser, CurrentUser>(a =>
            {
                var context = a.GetRequiredService<IHttpContextAccessor>();
                var userIsSignedIn = Guid.TryParse(context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value, out Guid id);
                return new CurrentUser
                {
                    Email = context.HttpContext.User.FindFirst(ClaimTypes.Email).Value,
                    Id = id,
                    Permissions = context.HttpContext.User.FindAll("permission").Select(a => Enum.Parse<Permissions>(a.Value)).ToList(),
                    PhoneNumber = context.HttpContext.User.FindFirst(ClaimTypes.MobilePhone).Value
                };
            });
            return services;
        }
    }
}
