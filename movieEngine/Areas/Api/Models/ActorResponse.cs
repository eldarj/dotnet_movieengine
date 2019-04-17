using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieEngine.Web.Areas.Api.Models
{
    public class ActorResponse
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<TitleInfo> Titles { get; set; }

        public class TitleInfo
        {
            public int Id { get; set; }
            public String Name { get; set; }
            public String Type { get; set; }
        }
    }
}
