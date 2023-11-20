using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Producto3.Models
{
    public class Root
    {
        public int place_id { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string addresstype { get; set; }
        public string name { get; set; }
        public string display_name { get; set; }
        public List<Root> Results { get; set; }
    }

}