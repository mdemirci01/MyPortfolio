using MyPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Data.Builders
{
    public class NewsletterBuilder
    {
        public NewsletterBuilder(EntityTypeConfiguration<Newsletter> entity)
        {
            entity.Property(p => p.Email).IsRequired().HasMaxLength(100);
            entity.Property(p => p.FullName).HasMaxLength(200);
        }
    }
}
