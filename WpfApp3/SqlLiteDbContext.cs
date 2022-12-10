using Microsoft.EntityFrameworkCore;

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

    public virtual DbSet<Employee> Employee { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=testDb.db");
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

}
