namespace BookManagemant.Models
{
    public class BookModel
    {
        public Guid Id { get; set; }
        public string BookName { get; set; }
        public string PublisherName { get; set; }
        public int Age { get; set; }
        public int PageNo { get; set; }
        public DateTime PublishDate { get; set; }
        public string BookType { get; set; }
    }
}
