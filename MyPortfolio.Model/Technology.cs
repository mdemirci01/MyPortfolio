using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Model
{
    public class Technology:BaseEntity
    {
        public Technology()
        {
            Projects = new HashSet<Project>();
        }
        [Display(Name="Teknoloji Adı")]
        public string Name { get; set; }
        public virtual ICollection<Project> Projects { get; set; } 
    }
}
