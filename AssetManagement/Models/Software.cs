using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class Software
    {
        [Key]
        public int SoftwareID { get; set; }

        [Required]
        public string SoftwareName { get; set; } = string.Empty;

        [Required]
        public int SoftwarePrice { get; set; }

        public int SoftwareWarrenty { get; set; }

        public string SoftwareSpecification { get; set; } = string.Empty;
    }
}
