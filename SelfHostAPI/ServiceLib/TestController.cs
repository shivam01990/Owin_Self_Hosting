﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace APIServiceLib
{
    public class TestController : ApiController
    {
        // GET api/test 
        public IEnumerable<string> Get()
        {
            return new string[] { "result1", "result2" };
        }

        // GET api/test/5 
        public string Get(int id)
        {
            return "test";
        }

        // POST api/test 
        public void Post([FromBody]string value)
        {

        }

        // PUT api/test/5 
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/test/5 
        public void Delete(int id)
        {

        }
    }
}
