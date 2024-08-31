using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }

        [Required]
        public string BookName { get; set; } = string.Empty;

        public string AuthorName { get; set; } = string.Empty;

        [Required]
        public double BookPrice { get; set; }

        public int PageNumber { get; set; }
    }
}
