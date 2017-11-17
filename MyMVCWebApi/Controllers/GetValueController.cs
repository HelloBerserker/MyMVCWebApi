using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyApi.Controllers
{
    public class GetValueController : ApiController
    {
        // GET: api/GetValue
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GetValue/5
        public string Get(string name)
        {
            return "You input " + name + "message";
        }

        // POST: api/GetValue
        [HttpPost]
        public string Post(string name, string message)
        {
            return "You input " + name + " message"+message;
        }

        // PUT: api/GetValue/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetValue/5
        public void Delete(int id)
        {
        }
    }
}
