using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dima.Core.Models

{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } 
        public string UserId { get; set; } = string.Empty;
    }
}
