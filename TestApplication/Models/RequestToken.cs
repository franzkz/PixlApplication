using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApplication.Models
{
    public class RequestTokenModel
    {
        public string RequestToken { get; set; }
        public string Expires { get; set; }
        public string Success { get; set; }
    }
}