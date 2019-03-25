using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace WebApiConversao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ValuesController(IConfiguration configuration)
        {
            _config = configuration;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var url = Uri();
            string res = String.Empty;

            using (var client = new HttpClient())
            using (var response = client.GetAsync(url).Result)
            {
                if (response.IsSuccessStatusCode)
                    res = await response.Content.ReadAsStringAsync();
            }

            return StatusCode(200, res);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public string Uri()
        {
            return $@"{_config["ConfigWebApi:ApiUri"]}{_config["ConfigWebApi:Endpoint"]}?access_key={_config["ConfigWebApi:AccessKey"]}";
        }
    }
}
