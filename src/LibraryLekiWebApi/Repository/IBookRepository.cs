using LibraryLekiWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryLekiWebApi.Repository
{
    public interface IBookRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(uint id);
        Task Add(TEntity entity);
        Task Update(Book book, TEntity entity);
        Task Delete(Book book);
    }
}
