using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Infra.Entidade;
using WebApi.Infra.Entity.Contact;

namespace WebApi.Infra.Data.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactEntity>().Ignore(c => c.Addresses);
        }
        public DbSet<ContactEntity> contact { get; set; }
        public IQueryable<ContactEntity> Query => contact;
        public DbSet<AddressEntity> address { get; set; }
        public IQueryable<AddressEntity> QueryAddress => address;

    }
}
