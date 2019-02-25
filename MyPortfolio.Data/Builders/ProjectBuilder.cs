using MyPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Data.Builders
{
    public class ProjectBuilder
    {
        public ProjectBuilder(EntityTypeConfiguration<Project> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.ShortDescription).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Photo).HasMaxLength(200);
            entity.HasOptional(p => p.Technology).WithMany(m => m.Projects).HasForeignKey(f => f.TechnologyId);

        }
    }
}
