using MediatR;
using SajjadArash.ToDoApp.Infrastructure.Common.Authorization;
using SajjadArash.ToDoApp.Infrastructure.Common.Exceptions;
using SajjadArash.ToDoApp.Infrastructure.Common.Interfaces;
using SajjadArash.ToDoApp.Infrastructure.Enums;
using SajjadArash.ToDoApp.Infrastructure.Extensions;
using System.Reflection;

namespace SajjadArash.ToDoApp.Infrastructure.Common.Behaviours
{

    /// <summary>
    /// چک کردن دسترسی کاربر و تطابق با درخواستی که از سامانه دارد
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TResponse : ResponseBase, new()
    {
        private readonly ICurrentUser _user;

        public AuthorizationBehaviour(ICurrentUser user)
        {
            _user = user;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var neededPermissions = request.GetType().GetCustomAttributes<ToDoAppAuthorizeAttribute>();
            if (neededPermissions.Count() < 1)
                return await next();
            if (neededPermissions.Any(p => _user.Permissions.All(a => a != p.Permission)))
                throw new NotAccessException();
            return await next();
        }
    }
}
