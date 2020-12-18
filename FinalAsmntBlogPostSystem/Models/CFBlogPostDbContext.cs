using FinalAsmntBlogPostSystem.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalAsmntBlogPostSystem.Models
{
    public class CFBlogPostDbContext:DbContext
    {
        public CFBlogPostDbContext():base("name=CFBlogPostDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CFBlogPostDbContext, Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasKey<int>(k => k.PostId);
            modelBuilder.Entity<Post>().Property(p => p.Text).IsRequired();
            
            modelBuilder.Entity<Comment>().HasKey<int>(k => k.CommentId);
            modelBuilder.Entity<Comment>().Property(c => c.Text).IsRequired();
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}