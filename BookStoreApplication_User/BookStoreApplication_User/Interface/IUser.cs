using BookStoreApplication_User.Entity;
using BookStoreApplication_User.model;
using System.Collections.Generic;

namespace BookStoreApplication_User.Interface
{
    public interface IUser
    {
        public UserEntity UserResgistrations(Registration registration);
        public string Login(string emailid, string password);
        public UserEntity getprofile(int User_Id);
        public List<UserEntity> GetUsers();
    }
}
