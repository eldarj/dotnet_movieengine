using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieEngine.Web.Areas.Api.Models
{
    public class TitleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string ImagePath { get; set; }
        public string ImageBase64 { get; set; }

        public string Released { get; set; }
        public double Rating { get; set; }
        public string Type { get; set; }


        public string Actors { get => $"/api/titles/{this.Id}/actors"; }

        // avoid serializing the base64 string, but still accept it for deserialization in requests
        public bool ShouldSerializeImageBase64() => false;
    }
}
