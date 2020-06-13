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

        [Test]
        [Order(7)]
        public void PutBook_Null_Test()
        {
            IActionResult resp = _libApi.Put("123",null);
            Assert.IsInstanceOf<BadRequestObjectResult>(resp);

            BadRequestObjectResult objResp = (BadRequestObjectResult)resp;
            Assert.IsTrue("Parámetros incorrectos" == objResp.Value.ToString());
        }

        [Test]
        [Order(8)]
        public void PutBook_NotFound_Test()
        {
            IActionResult resp = _libApi.Put("5ed23c3346f8a5acf7df2123", new BookDTO());
            Assert.IsInstanceOf<NotFoundObjectResult>(resp);

            NotFoundObjectResult objResp = (NotFoundObjectResult)resp;
            Assert.IsTrue("Libro no encontrado, no se ha actualizado" == objResp.Value.ToString());
        }

        [Test]
        [Order(9)]
        public void PutBook_Test()
        {
            IActionResult resp = _libApi.Get("5ed23c3346f8a5acf7df2ad5"); 
            OkObjectResult objResp = (OkObjectResult)resp;
            BookDTO bookToUpdate = (BookDTO)objResp.Value;

            bookToUpdate.Author = "Patrick Rohtfuss";
            bookToUpdate.Genre = "Epic Fantasy";       
            
            resp = _libApi.Put(bookToUpdate.Id, bookToUpdate);
            Assert.IsInstanceOf<OkObjectResult>(resp);

            objResp = (OkObjectResult)resp;
            Assert.IsTrue(objResp.Value.ToString() == "1"); 
        }

        [Test]
        [Order(10)]
        public void GetBook_Null_Test()
        {
            IActionResult resp = _libApi.Get(null);
            Assert.IsInstanceOf<BadRequestObjectResult>(resp);

            BadRequestObjectResult objResp = (BadRequestObjectResult)resp;
            Assert.IsTrue(objResp.Value.ToString() == "Parámetro incorrecto");
        }

        [Test]
        [Order(11)]
        public void GetBook_NotFound_Test()
        {
            IActionResult resp = _libApi.Get("5ed23c3346f8a5acf7df2123");
            Assert.IsInstanceOf<NotFoundObjectResult>(resp);

            NotFoundObjectResult objResp = (NotFoundObjectResult)resp;
            Assert.IsTrue(objResp.Value.ToString() == "Libro no encontrado");
        }

        [Test]
        [Order(12)]
        public void GetBook_Test()
        {
            IActionResult resp = _libApi.Get("5ed26e4a46f8a5acf7df2f5d");
            Assert.IsInstanceOf<OkObjectResult>(resp);

            OkObjectResult objResp = (OkObjectResult)resp;
            BookDTO b = (BookDTO)objResp.Value;
            Assert.IsTrue(b.BookName == "Fundación" && b.Author == "Asimov");
        }
    }
}