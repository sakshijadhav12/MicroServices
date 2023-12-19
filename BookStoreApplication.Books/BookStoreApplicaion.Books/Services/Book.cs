using BookStoreApplicaion.Books.Entity;
using BookStoreApplicaion.Books.Entity.CommandEntity;
using BookStoreApplicaion.Books.Entity.QueryEntity;
using BookStoreApplicaion.Books.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreApplicaion.Books.Services
{
    public class Book : IBooks

    {
        private readonly BookDBContext bookDBContext;
        private readonly IConfiguration configuration;

        public Book( BookDBContext bookDBContext ,IConfiguration configuration)
        {
            this.bookDBContext = bookDBContext;
            this.configuration = configuration;
        }

        /// <summary>
        /// Adds the book.
        /// </summary>
 
      public BookEntity addBook(commandEntity entity) 
        {
            try
            {
                BookEntity book = new BookEntity();
                 book.Book_Name = entity.Book_Name;
                  book.Author = entity.Author;
                 book.Description = entity.Description;
                 book.category = entity.category;
                book.Ratings = entity.Ratings;
                book.OriginalPrice = entity.OriginalPrice;
               book.DiscountedPrice = entity.DiscountedPrice;
                book.Quantity= entity.Quantity;
                bookDBContext.Books.Add(book);
                int result = bookDBContext.SaveChanges();
                if (result > 0)
                {
                    return book;
                }
                else
                {
                    return null;
                }


            }
            catch(Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }

        }
        /// <summary>
        /// Views the book.
        /// </summary>
        /// <param name="BookName">Name of the book.
        /// <returns></returns>
       public List<BookEntity> viewBook(string BookName )
        {
            try
            {
                List<BookEntity> result = (List<BookEntity>)bookDBContext.Books.Where(x => x.Book_Name == BookName).ToList();
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Views the bookbyid.
        /// </summary>
        /// <param name="Book_id">The book identifier.</param>
        /// <returns></returns>
        public BookEntity viewBookbyid(int Book_id)
        {
            try
            {
                //var BookExicts = bookDBContext.Books.FirstOrDefault(x => x.Book_Name == BookName);
                var result =bookDBContext.Books.FirstOrDefault(x => x.Book_id == x.Book_id);
                return (BookEntity)result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<BookEntity>ViewBookOutofStock()
            {
            try
            {
                List<BookEntity> result = (List<BookEntity>)bookDBContext.Books.Where(x => x.Quantity == 0). ToList();
                {
                    return result;
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Updatebooks the specified book name.
        /// </summary>
        /// <param name="BookName">Name of the book.</param>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public BookEntity updatebook( string BookName ,commandEntity entity)
        {
            try
            {
                var BookExicts = bookDBContext.Books.FirstOrDefault(x => x.Book_Name== BookName);
                if (BookExicts != null)
                {
                    BookEntity book = new BookEntity();
                    book.Book_Name = entity.Book_Name;
                    book.Author = entity.Author;
                    book.Description = entity.Description;
                    book.category = entity.category;
                    book.Ratings = entity.Ratings;
                    book.OriginalPrice = entity.OriginalPrice;
                    book.DiscountedPrice = entity.DiscountedPrice;
                    book.Quantity = entity.Quantity;
                    int result = bookDBContext.SaveChanges();
                    if (result > 0)
                    {
                        return book;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}

//Create an api which would retrive all the out of stock books.

//Consume this api in admin project