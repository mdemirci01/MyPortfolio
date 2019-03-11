using MyPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPortfolio.Admin.Models
{
    public class PostViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid? CategoryId { get; set; }
        public Category Category { get; set; }
        public string Photo { get; set; }
        public bool IsActive { get; set; }
    }
}