using LibraryLekiWebApi.Controllers;
using LibraryLekiWebApi.Models;
using LibraryLekiWebApi.UnitTests.Contexts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryLekiWebApi.UnitTests.Controllers
{
    public class BookControllerUnitTest
    {
        [Fact]
        public async Task get_all_books()
        {
            // Arrange
            var repository = BookContextMocker.GetInMemoryBookRepository(nameof(get_all_books));
            var controller = new BookController(repository);

            // Act
            var response = await controller.GetAll() as ObjectResult;
            var books = response.Value as List<Book>;

            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(5, books.Count);
        }

        [Fact]
        public async Task get_book_with_existing_id()
        {
            // Arrange
            var repository = BookContextMocker.GetInMemoryBookRepository(nameof(get_book_with_existing_id));
            var controller = new BookController(repository);
            var expectedBook = new Book()
            {
                Id = 1,
                Title = "Book_01",
                Isbn = "1234567890123",
                Published = Convert.ToDateTime("2000/10/25")
            };

            // Act
            var response = await controller.Get(1) as ObjectResult;
            var book = response.Value as Book;

            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(expectedBook.Id, book.Id);
            Assert.Equal(expectedBook.Isbn, book.Isbn);
            Assert.Equal(expectedBook.Published, book.Published);
            Assert.Equal(expectedBook.Title, book.Title);
        }

        [Fact]
        public async Task add_new_book()
        {
            // Arrange
            var repository = BookContextMocker.GetInMemoryBookRepository(nameof(get_book_with_existing_id));
            var controller = new BookController(repository);
            int expectedValue = 6;
            Book newBook = new Book()
            {
                Id = 6,
                Title = "New Book",
                Isbn = "9900119922881",
                Published = Convert.ToDateTime("2010/10/10")
            };

            // Act
            await controller.Post(newBook);
            var response = await controller.GetAll() as ObjectResult;
            var books = response.Value as List<Book>;

            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(expectedValue, books.Count);
        }

        [Fact]
        public async Task update_existing_book()
        {
            // Arrange
            var repository = BookContextMocker.GetInMemoryBookRepository(nameof(get_book_with_existing_id));
            var controller = new BookController(repository);
            Book newBook = new Book()
            {
                Title = "New_Book",
                Isbn = "6622557799110",
                Published = Convert.ToDateTime("2002/11/06")
            };

            // Act
            await controller.Put(3, newBook);
            var response = await controller.Get(3) as ObjectResult;
            var book = response.Value as Book;

            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(newBook.Isbn, book.Isbn);
            Assert.Equal(newBook.Published, book.Published);
            Assert.Equal(newBook.Title, book.Title);
        }

        [Fact] async Task delete_existing_book()
        {
            // Arrange
            var repository = BookContextMocker.GetInMemoryBookRepository(nameof(get_book_with_existing_id));
            var controller = new BookController(repository);
            int expectedValue = 3;

            // Act
            await controller.Delete(1);
            await controller.Delete(3);
            var response = await controller.GetAll() as ObjectResult;
            var books = response.Value as List<Book>;

            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(expectedValue, books.Count);
        }
    }
}
