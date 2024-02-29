using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiBlogPage.Models
{
    [Table("BlogInfo")]
    public class BlogInfo
    {
        [Key]
        public int BlogId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Title { get; set; }
        [Required]
        [StringLength(50)]

        public string? Subject { get; set; }
        [Required]
        public DateTime DateOfCreation { get; set; }
        [Required]
        public string? BlogUrl { get; set; }
        [Required]
        public string? EmpEmailId { get; set; }
    }
}
