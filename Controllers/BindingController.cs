using APITestValidacion.Models.Binding;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APITestValidacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BindingController : ControllerBase
    {
        // GET: api/<BindingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BindingController>/5
        [HttpGet]
        [Route("RangoFechas")]
        public string RangoFechas([FromQuery] RangoFecha range)
        {
            return "value";
        }

        // GET api/<BindingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BindingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BindingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BindingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
