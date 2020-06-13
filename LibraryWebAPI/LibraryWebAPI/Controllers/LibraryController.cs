using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LibraryDAO;
using LibraryDAO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace LibraryWebAPI.Controllers
{
    // [ApiController] --> lo hemos especificado a nivel de ensamblador con el decorador [assembly: ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {

        private readonly ILogger<LibraryController> _logger;
        private ILibraryDAO _lib;
        private IConfiguration _config;

        public LibraryController(ILogger<LibraryController> logger,
                                IConfiguration config,
                                ILibraryDAO lib)
        {
            _logger = logger;
            _lib = lib;
            _config = config;
        }

        /// <summary>
        /// Endpoint que devuelve los libros de un determinado género.
        /// </summary>
        /// <param name="genre">Género que se quiere buscar</param>
        /// <returns>Una lista en formato JSON con los libros del género buscado</returns>
        [HttpGet("GetByGenre/{genre}")] // URL as https://<<server>>:<<port>>/Library/GetByGenre/{genre}
        [ProducesResponseType(StatusCodes.Status404NotFound)]       // Estos atributos documentan en swagger las posibles respuestas de esta acción.
        [ProducesResponseType(StatusCodes.Status200OK)]             // Para evitar poner los atributos ProducesResponseType en todas las acciones: ¡usa convenciones!
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")] // respuesta es JSON.
        public IActionResult GetByGenre(string genre)
        {
            // Example of read a config value
            // var s = _config.GetValue<string>("EntradaConfigEjemplo");

            if (string.IsNullOrWhiteSpace(genre))
                return BadRequest();

            IEnumerable<BookDTO> listBooks = _lib.GetByGenre(genre);
            if (listBooks == null || listBooks.Count() == 0)
                return NotFound();

            return Ok(listBooks);
        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions),
                     nameof(DefaultApiConventions.Get))]
        public IActionResult Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Parámetro incorrecto");

            BookDTO b = _lib.Get(id);
            if (b == null)
                return NotFound("Libro no encontrado");

            return Ok(b);
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions),
                     nameof(DefaultApiConventions.Create))] // Convención básica de cómo se comporta un método create.
        public IActionResult Create(string bookName, string author, string genre)
        {
            if (string.IsNullOrWhiteSpace(bookName))
                return BadRequest();

            BookDTO myNewBook = new BookDTO()
            {
                BookName = bookName,
                Author = author,
                Genre = genre
            };
            _lib.CreateBook(myNewBook);
            return Ok(value: myNewBook); // similar to return Ok(myNewBook); Indicates that the object returned is in the value tag of json
        }

        [HttpDelete]
        [ApiConventionMethod(typeof(DefaultApiConventions),
                     nameof(DefaultApiConventions.Delete))] // Convención para el delete.
        public IActionResult Delete(string bookName)
        {
            if (string.IsNullOrWhiteSpace(bookName))
                return BadRequest();

            if (_lib.DeleteBook(bookName) == 0)
                return NotFound();

            return Ok();
        }

        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions),
                     nameof(DefaultApiConventions.Put))]
        public IActionResult Put(string id, BookDTO book)
        {
            if (string.IsNullOrWhiteSpace(id) || book == null)
                return BadRequest("Parámetros incorrectos");

            long numUpdates = _lib.UpdateBook(id, book);

            if (numUpdates == 0)
                return NotFound("Libro no encontrado, no se ha actualizado");
            else
                return Ok(numUpdates);
        }

        /*
         * We can use type JsonResult to return a Json in an API like this:
         *  [HttpGet]
         *  public JsonResult Get()
         *  {
         *      return Json(_authorRepository.List());
         *  }
         *  
         *  But in these cases we can't control the response code. In other words
         *  we can't use --> return NotFount(); or return Ok();
         *  
         *  So we use IActionResult and we can return a Json with response code.
         *  https://docs.microsoft.com/es-es/dotnet/api/microsoft.aspnetcore.mvc.iactionresult?view=aspnetcore-2.1
        */

    }
}
