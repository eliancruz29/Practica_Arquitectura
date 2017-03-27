using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Main_Web_Api.Models
{
    public class UriApi
    {
        public UriApi() { }

        public string Uri { get; set; }
        public int VisitedAmount { get; set; }
        public bool isAlive { get; set; }
    }
}
