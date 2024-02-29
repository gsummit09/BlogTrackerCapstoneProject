using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiBlogPage.Models
{
    [Table("EmoInfo")]
    public class EmpInfo
    {
        [Key]
        public int EmpId { get; set; }

        [Required]
        public string ?EmailId { get; set; }
        [Required]
        [StringLength(50)]
        public string ?Name { get; set; }
        [Required]
        public DateTime DateOfJoining { get; set; }
        [Required]
        public int PassCode { get; set; }
    }
}
