using LibraryLekiWebApi.DbContexts;
using LibraryLekiWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryLekiWebApi.Repository
{
    public class BookRepository : IBookRepository<Book>
    {
        private readonly BookContext _dbContext;

        public BookRepository(BookContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Book entity)
        {
            await _dbContext.Books.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Book book)
        {
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Book> Get(uint id)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task Update(Book book, Book entity)
        {
            book.Isbn = entity.Isbn;
            book.Published = entity.Published;
            book.Title = entity.Title;

            await _dbContext.SaveChangesAsync();
        }
    }
}
