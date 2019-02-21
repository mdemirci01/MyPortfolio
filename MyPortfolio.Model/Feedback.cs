using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Model
{
    public class Feedback:BaseEntity
    {
        [Display(Name ="Ad-Soyad")]
        public string Name { get; set; }
        [Display(Name = "E-posta")]
        public string Email { get; set; }
        [Display(Name = "Konu")]
        public string Subject { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Mesaj")]
        public string Message { get; set; }
    }
}
