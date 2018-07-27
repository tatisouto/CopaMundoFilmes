using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto.CopaMundo.Filmes.MVC.Controllers
{
    public class FilmeController : ApiController
    {
        

        // GET: api/Filme
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Filme/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Filme
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Filme/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Filme/5
        public void Delete(int id)
        {
        }
    }
}
