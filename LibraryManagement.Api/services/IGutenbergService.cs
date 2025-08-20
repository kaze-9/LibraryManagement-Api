namespace LibraryManagement.Api.Services
{
    public interface IGutenbergService
    {
        Task ScrapeAndSaveTopBooks();
    }
}