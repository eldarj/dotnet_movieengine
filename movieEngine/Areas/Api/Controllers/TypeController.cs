using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movieEngine.Data;
using movieEngine.Web.Areas.Api.Helpers;

namespace movieEngine.Web.Areas.Api.Controllers
{
    [Route("api/types")]
    public class TypeController : MyBaseApiController
    {
        public TypeController(MyDbContext ctx, IMapper mapper) : base(ctx, mapper) { }

        // GET: api/types
        [HttpGet]
        public IActionResult Get()
        {
            var types = db.TitleTypes.ToList();
            return Ok(types);
        }
    }
}