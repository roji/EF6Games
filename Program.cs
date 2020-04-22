using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;

namespace EF6Games
{
    class Program
    {
        static void Main(string[] args)
        {
            using var ctx = new BlogContext();
            ctx.Database.Log = Console.Write;

            ctx.Database.Delete();
            ctx.Database.Create();
        }
    }
    
    public class BlogContext : DbContext
    {
        public BlogContext() : base(@"Server=localhost;Database=ef6test;User=SA;Password=Abcd5678") {}
        
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }

    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class MyConfiguration : DbConfiguration
    {
        public MyConfiguration()
        {
            SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
            SetDefaultConnectionFactory(new SqlConnectionFactory());
        }
    }
}