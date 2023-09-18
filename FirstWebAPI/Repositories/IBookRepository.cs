using FirstWebAPI.Data;
using FirstWebAPI.Model;

namespace FirstWebAPI.Repositories
{
    public interface IBookRepository
    {
        public Task<List<BookModel>> GetAllBookAsync();
        public Task<BookModel> GetBookAsync(int id);
        public Task<int> AddBookAsync(BookModel book);
        public Task UpdateBookAsync(int id, BookModel book);
        public Task<int> DeleteBookAsync(int id);
    }
}
