using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiBlogPage.Models
{
    [Table("AdminInfo")]
    public class AdminInfo
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        [StringLength(50)]
        public string? EmailId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Password { get; set; }
    }
}
