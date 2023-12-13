using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApplicaion.Books.Entity.CommandEntity
{
    public class commandEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Book_id { get; set; }
        [Required]
        public string Book_Name { get; set; }
        [Required , RegularExpression("^[a-zA-Z]*$")]
        [StringLength(3, ErrorMessage = "Author must be at least 3 characters long.")]
        public string Author { get; set; }
        [Required]
        public string category { get; set; }
        [Required , MinLength(50),MaxLength(500)]
        public string Description { get; set; }
        [Range(0 ,5)]
        public float Ratings { get; set; }
        public int Reviews { get; set; }
        [Range (10 ,1000)]
        public float DiscountedPrice { get; set; }
        [ Required, Range(10, 10000)]
        public float OriginalPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
