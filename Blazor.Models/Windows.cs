using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor.Models
{
    public class Windows
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public int QuantityOfWindows  { get; set; }
        public int TotalSubElements { get; set; }

        public virtual Orders Orders { get; set; }
        public virtual ICollection<SubElements> SubElements { get; set; }
    }
}
