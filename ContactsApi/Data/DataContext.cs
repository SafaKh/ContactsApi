using ContactsApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
