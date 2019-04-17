using AutoMapper;
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
        protected readonly IMapper mapper;
        protected MyBaseApiController(MyDbContext ctx, IMapper mapper)
        {
            this.db = ctx;
            this.mapper = mapper;
        }
    }
}
