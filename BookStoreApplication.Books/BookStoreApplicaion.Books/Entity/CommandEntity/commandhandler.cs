using BookStoreApplicaion.Books.Entity.QueryEntity;

namespace BookStoreApplicaion.Books.Entity.CommandEntity
{
    public class commandhandler
    {
       
            private readonly BookDBContext bookDBContext;

            public commandhandler(BookDBContext bookDBContext)
            {
                this.bookDBContext = bookDBContext;
            }

            public void Handle(commandEntity command)
            {
                var createEntity = new BookEntity
                {
                    Book_Name = command.Book_Name,
                    Author = command.Author,
                    Description = command.Description,
                    category = command.category,
                    Ratings = command.Ratings,
                    OriginalPrice = command.OriginalPrice,
                    DiscountedPrice = command.DiscountedPrice,
                    Quantity = command.Quantity
                };

                bookDBContext.Books.Add(createEntity);
                bookDBContext.SaveChanges();
            }
     }
}


