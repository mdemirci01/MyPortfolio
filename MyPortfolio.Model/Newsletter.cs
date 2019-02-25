using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Model
{
   public class Newsletter:BaseEntity
    {
        [Display(Name= "Ad-Soyad")]
        public string FullName { get; set; }
        [Display(Name = "E-Posta")]
        public string Email { get; set; }
    }
}
