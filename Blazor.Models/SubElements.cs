using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor.Models
{
    public class SubElements
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OrderId { get; set; }
        public int WindowId { get; set; }
        [Required]
        public int Element { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }

        public virtual Windows Windows { get; set; }
    }
}
