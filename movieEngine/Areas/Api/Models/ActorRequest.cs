using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieEngine.Web.Areas.Api.Models
{
    public class ActorRequest
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

    }
}
