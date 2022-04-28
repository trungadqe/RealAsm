using RealAsm.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealAsm.Models
{
    public class Store
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Slogan { get; set; } = null!;
        public string UId { get; set; } = null!;
        public RealAsmUser User { get; set; }
        public virtual ICollection<Book>? Books { get; set; } = null!;

    }
}
