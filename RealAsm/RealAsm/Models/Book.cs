using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace RealAsm.Models
{
    public class Book
    {
        [Key]
        public string Isbn { get; set; }
        public int CategoryId { get; set; }

        [ValidateNever]
        public Category Category { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int Pages { get; set; } 
        public string Author { get; set; } = null!;
        public double Price { get; set; }
        public string Desc { get; set; } = null!;
        public string ImgUrl { get; set; } = null!;
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; } = null!;

    }
}
