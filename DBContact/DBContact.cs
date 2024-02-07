using Api_Databse_CRUD.Model;
using Microsoft.EntityFrameworkCore;

namespace Api_Databse_CRUD.DBContext
{
    public class DBContacts : DbContext
    {
        public DBContacts(DbContextOptions options) : base (options) { }
        public DbSet<model> Employee { get; set; }
        public DbSet<model2> salary { get ; set; }
    }
}
