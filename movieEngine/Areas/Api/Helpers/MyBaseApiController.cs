using Microsoft.AspNetCore.Mvc;
using movieEngine.Data;
using movieEngine.Web.Areas.Api.Filters;

namespace movieEngine.Web.Areas.Api.Helpers
{
    [ApiAuthAttribute]
    [Produces("application/json")]
    public class MyBaseApiController
    {
        protected readonly MyContext db;

        protected MyBaseApiController(MyContext ctx)
        {
            db = ctx;
        }
    }
}
