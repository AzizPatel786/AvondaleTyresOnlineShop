﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvondaleTyresOnlineShop.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "Please enter the Item Name of the Product (Min 3 Char)")]
        public string Item { get; set; }

        [Required(ErrorMessage = "Please enter the category name")]
        public string Category { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the price")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Please enter the total quantity left")]
        [Display(Name = "Total amount left")]
        public int? Quantity { get; set; }
    }
}
