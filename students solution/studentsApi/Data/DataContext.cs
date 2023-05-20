namespace students_Api.Data
{
    public class DataContext: DbContext
    {
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Parent> Parent { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
