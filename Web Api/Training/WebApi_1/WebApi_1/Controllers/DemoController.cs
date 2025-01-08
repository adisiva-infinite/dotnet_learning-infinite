using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi_1.Controllers
{
    public class DemoController : ApiController
    {
        List<string> continents = new List<string>()
        {
            "Asia","Africa","America","Anartica","Europe"
        };
        
        public IEnumerable<string> Get()
        {
            return continents;
        }

        public string Get(int Id)
        {
            return continents[Id - 1];
        }

        public IEnumerable<string> Post([FromBody] string data)
        {
            continents.Add(data);
            return continents;
        }

        public IEnumerable<string> Put(int Id, [FromUri] string edit)
        {
            continents[Id - 1] = edit;
            return continents;
        }

        public IEnumerable<string> Delete(int Id)
        {
            continents.RemoveAt(Id - 1);
            return continents;
        }
    }
}
