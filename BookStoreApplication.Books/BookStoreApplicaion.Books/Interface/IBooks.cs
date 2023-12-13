using BookStoreApplicaion.Books.Entity;
using BookStoreApplicaion.Books.Entity.CommandEntity;
using BookStoreApplicaion.Books.Entity.QueryEntity;
using System.Collections.Generic;

namespace BookStoreApplicaion.Books.Interface
{
    public interface IBooks
    {
        public BookEntity addBook(commandEntity entity);

        public List<BookEntity> viewBook(string BookName);
        public BookEntity updatebook(string BookName, commandEntity entity);
        public List<BookEntity> viewBookbyid(int Book_id);
        public List<BookEntity> ViewBookOutofStock();
    }

}
