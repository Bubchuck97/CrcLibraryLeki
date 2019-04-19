using LibraryLekiWebApi.DbContexts;
using LibraryLekiWebApi.Models;
using LibraryLekiWebApi.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryLekiWebApi.UnitTests.Contexts
{
    public static class BookContextMocker
    {
        public static IBookRepository<Book> GetInMemoryBookRepository(string dbName)
        {
            var options = new DbContextOptionsBuilder<BookContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            BookContext bookContext = new BookContext(options);
            bookContext.SeedDatabase();

            return new BookRepository(bookContext);
        }
    }
}
