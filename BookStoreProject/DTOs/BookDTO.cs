namespace BookStoreProject.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? AuthorName { get; set; }
        public string? CategoryName { get; set; }
        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; }
        public decimal? Price { get; set; }
        public DateTime? PublicationDate { get; set; }
    }
}
