using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LibraryDAO;
using LibraryDAO.Models;
using Microsoft.AspNetCore.Http;

namespace LibraryWebAPI.Controllers
{
    // [ApiController] --> lo hemos especificado a nivel de ensamblador con el decorador [assembly: ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {

        private readonly ILogger<LibraryController> _logger;
        private ILibraryDAO _lib;

        public LibraryController(ILogger<LibraryController> logger,
                                ILibraryDAO lib)
        {
            _logger = logger;
            _lib = lib;
        }

        /// <summary>
        /// Endpoint que devuelve los libros de un determinado género.
        /// </summary>
        /// <param name="genre">Género que se quiere buscar</param>
        /// <returns>Una lista en formato JSON con los libros del género buscado</returns>
        [HttpGet("GetByGenre/{genre}")] // URL as https://<<server>>:<<port>>/Library/GetByGenre/{genre}
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")] // Indica que la respuesta es JSON.
        public IActionResult GetByGenre(string genre)
        {
            if (string.IsNullOrWhiteSpace(genre))
                return BadRequest();

            IEnumerable<BookDTO> listBooks = _lib.GetByGenre(genre);
            if (listBooks == null || listBooks.Count() == 0)
                return NotFound();

            return Ok(listBooks);
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
