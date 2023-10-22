using Microsoft.AspNetCore.Mvc;
using Obligatorisk_opgave_1_Programmering_og_Teknologi;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestExercises.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BooksRepository _repo;
        public BooksController(BooksRepository repo)
        {
            _repo= repo;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get()
        {
            IEnumerable<Book> books = _repo.Get();
            if (books.ToList().Count == 0) { return NoContent(); }
            return Ok(books);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            
            
                Book BlackBooks = _repo.Getbyid(id);
                if (BlackBooks == null)
                {
                    return NotFound();
                }
                return Ok(BlackBooks);
            
            
        }

        // POST api/<ValuesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
      
        public IActionResult Post([FromBody] Book value)
        {
            Book book = _repo.Add(value);
            return Created($"API/Books/{book.ID}", book);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] Book value)
        {
            Book book = _repo.Update(id, value);
            if (book == null) { return NotFound(); }
            return Ok(book);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            Book book = _repo.Delete(id);
            if (book == null) { return NotFound(); }
            return Ok(book);
        }
    }
}
