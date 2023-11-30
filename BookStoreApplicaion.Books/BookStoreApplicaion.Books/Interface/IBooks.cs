using BookStoreApplicaion.Books.Entity;
using System.Collections.Generic;

namespace BookStoreApplicaion.Books.Interface
{
    public interface IBooks
    {
        public BookEntity addBook(BookModel book);

        public List<BookEntity> viewBook(string BookName);
        public BookEntity updateBook(BookModel book, string BookName);
        public List<BookEntity> viewBookbyid(int Book_id);
    }

}
