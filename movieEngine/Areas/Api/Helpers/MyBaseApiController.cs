using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using movieEngine.Data;
using movieEngine.Web.Areas.Api.Filters;

namespace movieEngine.Web.Areas.Api.Helpers
{
    [ApiController]
    [ApiAuthAttribute]
    [Produces("application/json")]
    public class MyBaseApiController : Controller
    {
        protected readonly MyDbContext db;
        protected readonly IMapper mapper;
        protected readonly IHostingEnvironment appEnvironment;

        protected MyBaseApiController(MyDbContext ctx, IMapper mapper)
        {
            this.db = ctx;
            this.mapper = mapper;
        }

        protected MyBaseApiController(MyDbContext ctx, IMapper mapper, IHostingEnvironment hostingEnvironment)
        {
            this.db = ctx;
            this.mapper = mapper;
            this.appEnvironment = hostingEnvironment;
        }
    }
}
