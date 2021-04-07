using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTdotnetAPI.Business;
using RESTdotnetAPI.Model;
namespace RESTdotnetAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {

        private readonly ILogger<BookController> _logger;
        private IBookBusiness _bookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness bookService)
        {
            _logger = logger;
            _bookBusiness = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
  
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {

            var book = _bookBusiness.FindByID(id);
            if (book == null) return NotFound();
            return Ok(book);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {

            
            if (book == null) return BadRequest("Deu ruim aqui fera");

            return Ok(_bookBusiness.Create(book));

        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var book = _bookBusiness.FindByID(id);
            if (book == null) return NotFound();
            return NoContent();
        }
    }
}
