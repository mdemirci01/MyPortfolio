using MyPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Data.Builders
{
    public class TechnologyBuilder
    {
        public TechnologyBuilder(EntityTypeConfiguration<Technology> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(50);


        }
    }
}
