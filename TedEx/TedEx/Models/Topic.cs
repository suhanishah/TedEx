using System.ComponentModel.DataAnnotations;

namespace TedEx.Models
{
    public class Topic
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}