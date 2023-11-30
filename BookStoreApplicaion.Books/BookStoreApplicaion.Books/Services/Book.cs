using BookStoreApplicaion.Books.Entity;
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

        public BookEntity addBook(BookModel book) 
        {
            try
            {
                BookEntity bookEntity = new BookEntity();
                bookEntity.Book_Name = book.Book_Name;
                bookEntity.Author = book.Author;
                bookEntity.category = book.category;
                bookEntity.Description = book.Description;
                bookEntity.Ratings = book.Ratings;
                bookEntity.Reviews = book.Reviews;
                bookEntity.OriginalPrice = book.OriginalPrice;
                bookEntity.DiscountedPrice = book.DiscountedPrice;
                bookEntity.Quantity = book.Quantity;
                bookDBContext.Books.Add(bookEntity);
                int result = bookDBContext.SaveChanges();
                if (result > 0)
                {
                    return bookEntity;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

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
        public List<BookEntity> viewBookbyid(int Book_id)
        {
            try
            {
                List<BookEntity> result = (List<BookEntity>)bookDBContext.Books.Where(x => x.Book_id== x.Book_id).ToList();
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public BookEntity updatebook(BookModel book , string BookName)
        {
            try
            {
                var BookExicts = bookDBContext.Books.FirstOrDefault(x => x.Book_Name== BookName);
                if (BookExicts != null)
                {
                    BookEntity bookEntity = new BookEntity();
                    bookEntity.Book_Name = book.Book_Name;
                    bookEntity.Author = book.Author;
                    bookEntity.category = book.category;
                    bookEntity.Description = book.Description;
                    bookEntity.Ratings = book.Ratings;
                    bookEntity.Reviews = book.Reviews;
                    bookEntity.OriginalPrice = book.OriginalPrice;
                    bookEntity.DiscountedPrice = book.DiscountedPrice;
                    bookEntity.Quantity = book.Quantity;
                    int result = bookDBContext.SaveChanges();
                    if (result > 0)
                    {
                        return bookEntity;
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

        public BookEntity updateBook(BookModel book, string BookName)
        {
            throw new NotImplementedException();
        }
    }
}