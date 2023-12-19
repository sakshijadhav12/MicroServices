using BookStoreAppliacation.Admin.Entity;
using BookStoreApplicaion.Books.Entity.QueryEntity;
using System.Threading.Tasks;

namespace BookStoreAppliacation.Admin.Interface
{
    public interface IAdmin
    {
        public BookStoreAdminEntity registeradmin(AdminModel adminModel);
        public string admin_Login(string EmailId, string password);
        
    }
}
 