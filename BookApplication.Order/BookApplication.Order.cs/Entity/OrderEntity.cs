using BookStoreApplicaion.Order.Entity;
using BookStoreApplication_User.Entity;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookApplication.Order.cs.Entity
{
    public class OrderEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderId { get; set; }
        public int  BookId{ get; set; }
        public int UserId { get; set; }
        public int Quntity { get; set; }
        public string orderDate { get; set; }
        [NotMapped]
        public BookEntity BookDetails { get; set; }

        [NotMapped]
        public UserEntity UserDetails { get; set; }
        [NotMapped]
        public double OrderAmount { get; set; }

    }
}
