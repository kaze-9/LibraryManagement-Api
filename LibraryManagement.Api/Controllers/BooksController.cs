using LibraryManagement.Api.Entities;
using LibraryManagement.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public BooksController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _libraryService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _libraryService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound(); // Kitap bulunamazsa 404 hatası döner
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book newBook)
        {
            var createdBook = await _libraryService.CreateBookAsync(newBook);
            return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
        }
        [HttpPost("{id}/upload")]
        public async Task<IActionResult> UploadBookFile(int id, IFormFile file)
        {
            var book = await _libraryService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound("Kitap bulunamadı.");
            }

            if (file == null || file.Length == 0)
            {
                return BadRequest("Dosya yüklenmedi.");
            }


            var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "BookUploads");
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(uploadsFolderPath, uniqueFileName);


            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            await _libraryService.UpdateBookFilePathAsync(id, filePath);

            return Ok(new { message = "Dosya başarıyla yüklendi.", path = filePath });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var result = await _libraryService.UpdateBookAsync(id, updatedBook);
            if (result == null)
            {
                return NotFound("Güncellenecek kitap bulunamadı.");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var success = await _libraryService.DeleteBookAsync(id);
            if (!success)
            {
                return NotFound("Silinecek kitap bulunamadı.");
            }
            return NoContent();
        }
    }
}