using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movieEngine.Data;
using movieEngine.Web.Areas.Api.Helpers;
using movieEngine.Web.Areas.Api.Models;

namespace movieEngine.Web.Areas.Api.Controllers
{
    [Route("api/titles")]
    public class TitleController : MyBaseApiController
    {
        public TitleController(MyDbContext ctx, IMapper mapper) : base(ctx, mapper) { }

        // GET: api/titles
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(mapper.Map<List<TitleResponse>>(db.Titles.ToList()));
        }
    }
}