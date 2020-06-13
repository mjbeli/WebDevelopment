using System;
using System.Collections;
using System.Collections.Generic;
using LibraryDAO.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Connections;

namespace LibraryDAO
{
    public class LibraryDAO: ILibraryDAO
    {

        private readonly MongoClient mongodb;
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<BookDTO> _books;

        public LibraryDAO(string dbConn, string dbName, string bookCollectionName)
        {
            if (string.IsNullOrWhiteSpace(dbConn)
                || string.IsNullOrWhiteSpace(dbName)
                || string.IsNullOrWhiteSpace(bookCollectionName))
                throw new Exception("Faltan parámetros para trabajar con la biblioteca.");
            mongodb = new MongoClient(dbConn);
            database = mongodb.GetDatabase(dbName);
            _books = database.GetCollection<BookDTO>(bookCollectionName);
        }

        public BookDTO CreateBook(BookDTO book)
        {
            _books.InsertOne(book);
            return book;
        }

        public BookDTO Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            return _books.Find(b => b.Id == id).FirstOrDefault();
        }

        public IList<BookDTO> GetByGenre(string genre)
        {
            if (string.IsNullOrWhiteSpace(genre))
                return null;

            return _books.Find(b => b.Genre == genre).ToList();
        }

        public long DeleteBook(string bookName) => _books.DeleteOne(b => b.BookName == bookName).DeletedCount;

        public long UpdateBook(string id, BookDTO book) 
        {
            if (book == null || string.IsNullOrWhiteSpace(id)) 
                return -1;
            return _books.ReplaceOne(b => b.Id == id, book).ModifiedCount;            
        }
        
    }
}
