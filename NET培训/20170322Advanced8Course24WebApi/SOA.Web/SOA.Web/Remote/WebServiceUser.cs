using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOA.Web.Remote
{
    public class WebServiceUser
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public enum WebServiceSex
    {
        Famale,
        Male,
        Other
    }

}