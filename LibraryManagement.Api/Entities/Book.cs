namespace LibraryManagement.Api.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public int PublicationYear { get; set; }
        public string? FilePath { get; set; }
    }
}