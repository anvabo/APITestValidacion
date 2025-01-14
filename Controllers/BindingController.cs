using APITestValidacion.Models.Binding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APITestValidacion.Controllers
{

    public class ClaseConRangoFecha
    {
        [Required(ErrorMessage = "El periodo de reserva es obligatorio")]
        public RangoFecha FechasReserva { get; set; }
        public bool Requerido { get; set; }
    }

    public class CustomModelStateErrorFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(ms => ms.Value.Errors.Count > 0)
                    .Select(ms => new
                    {
                        Field = ms.Key,
                        Errors = ms.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    });


                // Personalizamos el mensaje de error para que sea con este formato: e.Field: [e.Errors]
                var customErrors = errors.ToDictionary(
                    e => e.Field,
                    e => e.Errors.Select(err => err.Contains("System.Nullable`1[System.DateOnly]")
                        ? "El formato de la fecha es incorrecto. Debe ser dd/mm/yyyy."
                        : err).ToArray()
                );

                context.Result = new BadRequestObjectResult(customErrors);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }

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
        public IActionResult RangoFechas([FromQuery] RangoFecha range)
        {
            if (!ModelState.IsValid)
            {
                // Personalizamos el mensaje de error
                if (ModelState.ContainsKey("range"))
                {
                    var rangeErrors = ModelState["range"].Errors;
                    rangeErrors.Clear();
                    rangeErrors.Add(new ModelError("El formato es incorrecto. Debe ser dd/mm/yyyy,dd/mm/yyyy"));
                }

                return BadRequest(ModelState);

            }

            return Ok();
        }

        // GET api/<BindingController>/5
        [HttpPost]
        [Route("RangoFechas2")]
        public IActionResult RangoFechas2([FromBody] ClaseConRangoFecha reserva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);                
            }

            return Ok();
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
