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
        public string Titles { get => $"/api/actors/{this.Id}/titles"; }
    }
}
