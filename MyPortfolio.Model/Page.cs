using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Model
{
    public class Page:BaseEntity
    {
        [Display(Name ="Başlık")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
    }
}
