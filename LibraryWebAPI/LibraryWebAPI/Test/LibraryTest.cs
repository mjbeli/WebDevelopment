using LibraryWebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LibraryWebAPI.Test
{
    public class LibraryTest
    {
        LibraryController _libApi;
        public LibraryTest()
        {
            _libApi = new LibraryController(null, new LibraryDAO.LibraryDAO("mongodb://localhost:27017", "Library", "Books"));
        }



        [Fact]
        public void GetBookByGenreBadRequest_Test()
        {
            IActionResult resp= _libApi.GetByGenre(string.Empty);
            Assert.IsType<BadRequestObjectResult>(resp);
        }
    }
}
