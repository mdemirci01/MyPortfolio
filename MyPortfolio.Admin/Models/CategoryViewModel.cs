using MyPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPortfolio.Admin.Models
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Post> Posts { get; set; }
        public bool IsActive { get; set; }
    }
}