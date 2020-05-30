using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LibraryDAO;
using LibraryDAO.Models;

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

        [HttpGet("GetByCifiGenre")]
        public IEnumerable<BookDTO> GetByCifiGenre()
        {
            return _lib.GetByGenre("Ci-fi");
        }
    }
}
