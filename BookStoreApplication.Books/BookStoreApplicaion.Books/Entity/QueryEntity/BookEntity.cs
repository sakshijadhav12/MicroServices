﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApplicaion.Books.Entity.QueryEntity
{
    public class BookEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Book_id { get; set; }
        public string Book_Name { get; set; }
        public string Author { get; set; }
        public string category { get; set; }
        public string Description { get; set; }
        public float Ratings { get; set; }
        public int Reviews { get; set; }
        public float DiscountedPrice { get; set; }
        public float OriginalPrice { get; set; }
        public int Quantity { get; set; }

    }
}
