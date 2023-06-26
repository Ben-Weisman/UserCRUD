using Microsoft.EntityFrameworkCore;
using UserCRUD.Models.domain;

namespace UserCRUD.data
{
    public class UserCRUDdbContext : DbContext
    {

        public UserCRUDdbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
