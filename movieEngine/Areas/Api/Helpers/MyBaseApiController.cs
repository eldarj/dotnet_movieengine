using Microsoft.AspNetCore.Mvc;
using movieEngine.Data;
using movieEngine.Web.Areas.Api.Filters;
using System.Web.Http;

namespace movieEngine.Web.Areas.Api.Helpers
{
    [ApiController]
    [Produces("application/json")]
    public class MyBaseApiController : Controller
    {
        protected readonly MyDbContext db;

        protected MyBaseApiController(MyDbContext ctx)
        {
            db = ctx;
        }
    }
}
