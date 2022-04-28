﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        public string Title { get; set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Desc { get; set; }
        public string ImgUrl { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }

    }
}
