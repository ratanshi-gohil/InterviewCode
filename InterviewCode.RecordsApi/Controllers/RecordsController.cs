using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InterviewCode.RecordsApi.Controllers
{
    public class RecordsController : ApiController
    {
        // GET: Records
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: Records/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: Records
        public void Post([FromBody]string value)
        {
        }

        // PUT: Records/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: Records/5
        public void Delete(int id)
        {
        }
    }
}
