using LibraryDAO.Models;
using System;
using System.Collections.Generic;

namespace LibraryDAO
{
    public interface ILibraryDAO
    {
        BookDTO Get(string id);
        IList<BookDTO> GetByGenre(string genre);

        BookDTO CreateBook(BookDTO book);

        long DeleteBook(string bookName);
    }
}
