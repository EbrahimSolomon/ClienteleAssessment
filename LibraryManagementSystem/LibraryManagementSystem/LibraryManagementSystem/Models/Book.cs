namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }                  // Primary key
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int PublicationYear { get; set; }     // Year of Publication
    }
}
