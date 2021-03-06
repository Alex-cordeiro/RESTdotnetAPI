using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTdotnetAPI.Business;
using RESTdotnetAPI.Model;
namespace RESTdotnetAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personService)
        {
            _logger = logger;
            _personBusiness = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
  
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {

            var person = _personBusiness.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {

            
            if (person == null) return BadRequest("Deu ruim aqui fera");

            return Ok(_personBusiness.Create(person));

        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var person = _personBusiness.FindByID(id);
            if (person == null) return NotFound();
            return NoContent();
        }
    }
}
