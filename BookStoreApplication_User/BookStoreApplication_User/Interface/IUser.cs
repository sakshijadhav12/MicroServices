using BookStoreApplication_User.Entity;
using BookStoreApplication_User.model;

namespace BookStoreApplication_User.Interface
{
    public interface IUser
    {
        public UserEntity UserResgistrations(Registration registration);
        public string Login(string emailid, string password);
        public UserEntity getprofile(int User_Id);
    }
}
