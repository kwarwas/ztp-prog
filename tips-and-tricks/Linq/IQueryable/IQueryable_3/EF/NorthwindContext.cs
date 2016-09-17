using System.Data.Entity;

namespace IQueryable_3.EF
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext()
            : base("name=NorthwindConnection")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<SchoolEntities>());
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
