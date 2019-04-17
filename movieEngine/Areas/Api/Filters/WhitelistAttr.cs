using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieEngine.Web.Areas.Api.Filters
{
    public class WhitelistAttr : TypeFilterAttribute
    {
        public WhitelistAttr() : base(typeof(WhitelistFilterImpl))
        {
            Arguments = new object[] { };
        }
    }

    public class WhitelistFilterImpl : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var ctx = context;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var ctx = context;
        }
    }
}
