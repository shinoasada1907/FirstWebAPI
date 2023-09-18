using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebAPI.Data
{
    [Table("Book")]
    public class Book
    {
        [Key]
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
