using LibraryManagement.Api.Entities;

namespace LibraryManagement.Api.Services
{
    public interface ILibraryService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task<Book> CreateBookAsync(Book newBook);
        Task<Book?> UpdateBookFilePathAsync(int bookId, string filePath);
        Task<Book?> UpdateBookAsync(int id, Book updatedBook);
        Task<bool> DeleteBookAsync(int id);
    }
}
