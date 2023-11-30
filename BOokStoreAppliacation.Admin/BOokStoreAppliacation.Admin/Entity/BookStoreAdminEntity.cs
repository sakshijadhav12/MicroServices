using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreAppliacation.Admin.Entity
{
    public class BookStoreAdminEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  AdminId { get; set; }
        public  string  AdminName { get; set; }
        public string Password { get; set; }
    }
}
