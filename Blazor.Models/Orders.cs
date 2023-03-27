using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor.Models
{
    public class Orders
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(2)]
        public string State { get; set; }

        public virtual ICollection<Windows> Windows { get; set; }
    }
}
