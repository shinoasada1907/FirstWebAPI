using AutoMapper;
using FirstWebAPI.Data;
using FirstWebAPI.Model;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace FirstWebAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<int> AddBookAsync(BookModel book)
        {
            var newBook = _mapper.Map<Book>(book);
            _context.Books!.Add(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }

        public async Task<int> DeleteBookAsync(int id)
        {
            var deleteBook = _context.Books!.SingleOrDefault(b => b.Id == id);
            if (deleteBook != null)
            {
                _context.Books!.Remove(deleteBook);
                await _context.SaveChangesAsync();
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public async Task<List<BookModel>> GetAllBookAsync()
        {
            var books = await _context.Books!.ToListAsync();
            return _mapper.Map<List<BookModel>>(books);
        }

        public async Task<BookModel> GetBookAsync(int id)
        {
            var book = await _context.Books!.FindAsync(id);
            return _mapper.Map<BookModel>(book);
        }

        public async Task UpdateBookAsync(int id, BookModel book)
        {
            if (id == book.Id)
            {
                var updateBook = _mapper.Map<Book>(book);
                _context.Books!.Update(updateBook);
                await _context.SaveChangesAsync();
            }
        }
    }
}
