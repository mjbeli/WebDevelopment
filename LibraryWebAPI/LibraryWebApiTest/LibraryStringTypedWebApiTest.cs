using LibraryDAO.Models;
using LibraryWebAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryStringTypedWebApiTest
{
    public class LibraryStringTypedWebApiTest
    {

        private LibraryStrongTypedController _libApi;

        [SetUp]
        public void Setup()
        {
            _libApi = new LibraryStrongTypedController(new LibraryDAO.LibraryDAO("mongodb://localhost:27017", "Library", "Books"));
        }


        [Test]
        [Order(1)]
        public void GetBookByGenreBadRequest_Test()
        {
            ActionResult<IEnumerable<BookDTO>> resp = _libApi.GetByGenre(string.Empty);
            Assert.NotNull(resp);
            Assert.IsInstanceOf<BadRequestObjectResult>(resp.Result);
            ObjectResult objRes = (ObjectResult)resp.Result;
            Assert.AreEqual(objRes.StatusCode, StatusCodes.Status400BadRequest);
            Assert.AreEqual(objRes.Value, "No se ha reconocido el g�nero");
        }

        [Test]
        [Order(2)]
        public void GetBookByGenreNotFound_Test()
        {
            ActionResult<IEnumerable<BookDTO>> resp = _libApi.GetByGenre("G�nero inexistente");
            Assert.NotNull(resp);
            Assert.IsInstanceOf<NotFoundObjectResult>(resp.Result);
            ObjectResult objRes = (ObjectResult)resp.Result;
            Assert.AreEqual(objRes.StatusCode, StatusCodes.Status404NotFound);
            Assert.AreEqual(objRes.Value, "G�nero no encontrado");
        }

        [Test]
        [Order(3)]
        public void GetBookByGenre_Test()
        {
            ActionResult<IEnumerable<BookDTO>> resp = _libApi.GetByGenre("Ci-fi");
            Assert.NotNull(resp);
            Assert.IsInstanceOf<OkObjectResult>(resp.Result);
            ObjectResult objRes = (ObjectResult)resp.Result;
            Assert.AreEqual(objRes.StatusCode, StatusCodes.Status200OK);
            IEnumerable<BookDTO> listaLibros = (IEnumerable<BookDTO>)objRes.Value;
            Assert.Positive(listaLibros.Count());
        }

    }
}