using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.DependencyInjection;
using movieEngine.Data;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace movieEngine.Web.Areas.Api.Filters
{
    public class ApiAuthAttribute : TypeFilterAttribute
    {
        public ApiAuthAttribute() : base(typeof(ApiAuthImpl))
        {
            Arguments = new object[] { };
        }
    }

    public class ApiAuthImpl : IAsyncActionFilter
    {
        private StringValues auth;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out var auth);
            if (!auth.ToString().Contains("Basic"))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            MyDbContext db = context.HttpContext.RequestServices.GetService<MyDbContext>();

            var basicToken = auth.ToString().Replace("Basic ", "");

            var authorizedClient = db.Clients
                .Where(c => c.Token == basicToken)
                .SingleOrDefault();

            if (authorizedClient != null)
            {
                await next();
                return;
            }

            context.Result = new UnauthorizedResult();
        }
    }
}
