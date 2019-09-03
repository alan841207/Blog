using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Model
{
    public class BlogContext:DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleToCategory> ArticleToCategories { get; set; }

        public DbSet<BlogCategory> BlogCategories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }


        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //全局  级联删除 
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                                 .SelectMany(t => t.GetForeignKeys())
                                 .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }



            base.OnModelCreating(modelBuilder);

           

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Blog\Blog.Api\Db\Blogdb.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }
}
