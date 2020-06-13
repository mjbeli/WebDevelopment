using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryDAO.Models;
using LibraryDAO;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class LibraryStrongTypedController : ControllerBase
    {
        private ILibraryDAO _lib;
        public LibraryStrongTypedController(ILibraryDAO lib)
        {
            _lib = lib;
        }
        // GET: api/<LibraryStrongTypedController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<BookDTO>> GetByGenre(string genre)
        {
            if (string.IsNullOrWhiteSpace(genre))
                return BadRequest("No se ha reconocido el género");

            IEnumerable<BookDTO> listBooks = _lib.GetByGenre(genre);
            if (listBooks == null || listBooks.Count() == 0)
                return NotFound("Género no encontrado");

            return Ok(listBooks);
        }


        // GET: api/<LibraryStrongTypedController>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public BookDTO Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            BookDTO book = _lib.Get(id);            
            return book;
        }

        /*
        // GET api/<LibraryStrongTypedController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LibraryStrongTypedController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LibraryStrongTypedController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LibraryStrongTypedController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
