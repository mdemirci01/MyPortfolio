using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPortfolio.Model;

namespace MyPortfolio.Data.Builders
{
    public class FeedbackBuilder
    {
        private EntityTypeConfiguration<Feedback> entityTypeConfiguration;

        public FeedbackBuilder(EntityTypeConfiguration<Feedback> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Subject).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Message).IsRequired();
        }
    }
}
