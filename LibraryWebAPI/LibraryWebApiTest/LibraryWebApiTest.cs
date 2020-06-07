using LibraryDAO.Models;
using LibraryWebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;

namespace LibraryWebApiTest
{
    public class LibraryWebApiTest
    {

        private LibraryController _libApi;

        [SetUp]
        public void Setup()
        {
            _libApi = new LibraryController(null, null, new LibraryDAO.LibraryDAO("mongodb://localhost:27017", "Library", "Books"));
        }


        [Test]
        [Order(1)]
        public void GetBookByGenreBadRequest_Test()
        {
            IActionResult resp = _libApi.GetByGenre(string.Empty);
            Assert.IsInstanceOf<BadRequestResult>(resp);
        }

        [Test]
        [Order(2)]
        public void GetBookByGenreNotFound_Test()
        {
            IActionResult resp = _libApi.GetByGenre("GeneroInventado");
            Assert.IsInstanceOf<NotFoundResult>(resp);
        }

        [Test]
        [Order(3)]
        public void GetBookByGenre_Test()
        {
            IActionResult resp = _libApi.GetByGenre("Ci-fi");
            Assert.IsInstanceOf<OkObjectResult>(resp);

            OkObjectResult obj = (OkObjectResult)resp;
            IList<BookDTO> booklist = (IList<BookDTO>)obj.Value;
            Assert.IsTrue(booklist.Count > 0);
        }


        [Test]
        [Order(4)]
        public void DeleteBookDontExists_Test()
        {
            IActionResult resp = _libApi.Delete("LibroQueMeInvento");
            Assert.IsInstanceOf<NotFoundResult>(resp);
        }

        [Test]
        [Order(6)]
        public void DeleteBookExists_Test()
        {
            IActionResult resp = _libApi.Delete("La ciudad y la ciudad");
            Assert.IsInstanceOf<OkResult>(resp);
        }

        [Test]
        [Order(5)]
        public void CreateBook_Test()
        {
            IActionResult resp = _libApi.Create("La ciudad y la ciudad", "China Mieville", "Fantasy");
            Assert.IsInstanceOf<OkObjectResult>(resp);
            OkObjectResult obj = (OkObjectResult)resp;
            BookDTO newBook = (BookDTO)obj.Value;
            Assert.IsTrue(newBook.BookName== "La ciudad y la ciudad");
        }

    }
}