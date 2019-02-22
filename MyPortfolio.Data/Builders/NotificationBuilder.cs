using MyPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Data.Builders
{
    public class NotificationBuilder
    {
        public NotificationBuilder(EntityTypeConfiguration<Notification> entity) {

            entity.Property(e => e.UserName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Message).IsRequired().HasMaxLength(200);


        }

    }
}
