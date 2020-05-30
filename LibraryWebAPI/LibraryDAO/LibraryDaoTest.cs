using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MongoDB.Driver;
using LibraryDAO.Config;
using LibraryDAO.Models;

namespace LibraryDAO.Test
{
    public class LibraryDaoTest
    {
        private LibraryDAO lib;
        public LibraryDaoTest()
        {
            lib = new LibraryDAO(Configuration.DBConfig.LibreryConnectionString,
                                 Configuration.DBConfig.LibraryDbName,
                                 Configuration.DBConfig.BooksCollection);

        }

        [Fact]
        public void ConnectDB_ParametersMissing_Test()
        {
            Exception ex = Assert.Throws<Exception>(() => new LibraryDAO(string.Empty, string.Empty, string.Empty));
            Assert.True(ex.Message == "Faltan parámetros para trabajar con la biblioteca.");
        }

        [Fact]
        public void ConnectDB_ErrorInConnString_Test()
        {
            LibraryDAO lib = new LibraryDAO("mongodb://localhostdfsf:27017", "Library", "Books");
            Assert.Throws<System.TimeoutException>(() => lib.Get("5ed23c9e46f8a5acf7df2af0"));            
        }

        [Fact]
        public void GetBookById_Test()
        {
            Assert.True(lib != null);
            BookDTO b = lib.Get("11111c9e46f8a5acf7df2af0"); // Id no existe en BBDD
            Assert.True(b == null);
            b = lib.Get("5ed23c9e46f8a5acf7df2af0");
            Assert.True(b != null && b.BookName == "Las estrellas son legión");
        }

        [Fact]
        public void GetBooksByGenre_Test()
        {            
            IList<BookDTO> books = lib.GetByGenre("Ci-fi");
            Assert.True(books != null && books.Count == 2);
        }

    }
}
