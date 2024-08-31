using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class Hardware
    {
        [Key]
        public int HardwareID { get; set; }

        [Required]
        public string HardwareName { get; set; } = string.Empty;

        [Required]
        public int HardwarePrice { get; set; }

        public int HardwareWarrenty { get; set; }

        public string HardwareSpecification { get; set; } = string.Empty;
    }
}
