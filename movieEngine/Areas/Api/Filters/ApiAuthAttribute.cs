using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
