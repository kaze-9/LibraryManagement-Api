using LibraryManagement.Api.Data;
using LibraryManagement.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Api.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly LibraryDbContext _context;

        public LibraryService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> CreateBookAsync(Book newBook)
        {
            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();
            return newBook;
        }
        public async Task<Book?> UpdateBookFilePathAsync(int bookId, string filePath)
        {
            var bookToUpdate = await _context.Books.FindAsync(bookId);
            if (bookToUpdate == null)
            {
                return null; // Kitap bulunamadı
            }
            bookToUpdate.FilePath = filePath;
            await _context.SaveChangesAsync();
            return bookToUpdate;
        }
        public async Task<Book?> UpdateBookAsync(int id, Book updatedBook)
        {
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null)
            {
                return null; // Kitap bulunamadı
            }

            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.PublicationYear = updatedBook.PublicationYear;

            await _context.SaveChangesAsync();
            return existingBook;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var bookToDelete = await _context.Books.FindAsync(id);
            if (bookToDelete == null)
            {
                return false; // Kitap bulunamadı, silme başarısız
            }

            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
            return true; // Silme başarılı
        }
    }
}