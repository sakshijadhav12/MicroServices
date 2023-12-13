namespace BookStoreApplicaion.Books.Entity
{
    public class BookModel
    {
       
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
