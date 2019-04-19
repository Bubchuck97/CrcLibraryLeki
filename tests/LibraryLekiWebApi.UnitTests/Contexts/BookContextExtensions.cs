using LibraryLekiWebApi.DbContexts;
using LibraryLekiWebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryLekiWebApi.UnitTests.Contexts
{
    public static class BookContextExtensions
    {
        public static void SeedDatabase(this BookContext dbContext)
        {
            dbContext.Books.Add
            (
                new Book
                {
                    Id = 1,
                    Title = "Book_01",
                    Isbn = "1234567890123",
                    Published = Convert.ToDateTime("2000/10/25")
                }
            );

            dbContext.Add
            (
                new Book
                {
                    Id = 2,
                    Title = "Book_02",
                    Isbn = "2345678901231",
                    Published = Convert.ToDateTime("2009/10/25")
                }
            );

            dbContext.Add
            (
                new Book
                {
                    Id = 3,
                    Title = "Book_03",
                    Isbn = "3456789012312",
                    Published = Convert.ToDateTime("2019/01/11")
                }
            );

            dbContext.Add
            (
                new Book
                {
                    Id = 4,
                    Title = "Book_04",
                    Isbn = "4567890123123",
                    Published = Convert.ToDateTime("1999/02/09")
                }
            );

            dbContext.Add
            (
                new Book
                {
                    Id = 5,
                    Title = "Book_05",
                    Isbn = "5678901231234",
                    Published = Convert.ToDateTime("2015/06/28")
                }
            );

            dbContext.SaveChanges();
        }
    }
}
