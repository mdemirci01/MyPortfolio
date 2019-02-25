using Microsoft.AspNet.Identity.EntityFramework;
using MyPortfolio.Data.Builders;
using MyPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new PostBuilder(modelBuilder.Entity<Post>());
            new CategoryBuilder(modelBuilder.Entity<Category>());
            new FeedbackBuilder(modelBuilder.Entity<Feedback>());
            new PageBuilder(modelBuilder.Entity<Page>());
            new NotificationBuilder(modelBuilder.Entity<Notification>());
            new ProjectBuilder(modelBuilder.Entity<Project>());
        }
    }
}
