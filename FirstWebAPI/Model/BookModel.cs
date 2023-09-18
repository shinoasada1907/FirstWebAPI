using System.ComponentModel.DataAnnotations;

namespace FirstWebAPI.Model
{
    public class BookModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public string? description { get; set; }
        [Range(0, double.MaxValue)]
        public double price { get; set; }
        [Range(0, 100)]
        public int quantity { get; set; }
    }
}
