using HtmlAgilityPack;

namespace LibraryManagement.Api.Services
{
    public class GutenbergService : IGutenbergService
    {
       
        private readonly ILibraryService _libraryService;

        public GutenbergService(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        public async Task ScrapeAndSaveTopBooks()
        {
            Console.WriteLine("Gutenberg'den kitapları çekme ve kaydetme görevi başladı!");

            var web = new HtmlWeb();
       
            var doc = await web.LoadFromWebAsync("https://www.gutenberg.org/browse/scores/top");

            
            var nodes = doc.DocumentNode.SelectNodes("//li[contains(@class, 'booklink')]");

            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    try
                    {
                        var titleNode = node.SelectSingleNode(".//a");
                        var authorNode = node.SelectSingleNode(".//span[@class='subtitle']");

                        if (titleNode != null && authorNode != null)
                        {
                            string title = titleNode.InnerText.Trim();
                            string author = authorNode.InnerText.Trim();

                         
                            var newBook = new LibraryManagement.Api.Entities.Book
                            {
                                Title = title,
                                Author = author,
                                PublicationYear = 0 // Gutenberg'de bu bilgi direkt listede yok, şimdilik 0 bırakalım
                            };

                            await _libraryService.CreateBookAsync(newBook);
                            Console.WriteLine($"EKLENDİ: {title} by {author}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Bir kitap işlenirken hata oluştu: {ex.Message}");
                    }
                }
            }

            Console.WriteLine("Gutenberg'den kitapları çekme görevi tamamlandı!");
        }
    }
}