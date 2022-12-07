using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public partial class SqlLiteDbContext : DbContext
{
    public SqlLiteDbContext()
    {
    }

    public SqlLiteDbContext(DbContextOptions<SqlLiteDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=testDb.db");
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

}
