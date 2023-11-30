using BookStoreAppliacation.Admin.Entity;

namespace BookStoreAppliacation.Admin.Interface
{
    public interface IAdmin
    {
        public BookStoreAdminEntity registeradmin(int Id, string name, string password);
        public string admin_Login(int id, string password);
    }
}
