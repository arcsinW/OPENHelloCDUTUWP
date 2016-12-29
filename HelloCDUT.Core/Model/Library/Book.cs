using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.Core.Model.Library
{
    public class Book
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

         

    }
}
