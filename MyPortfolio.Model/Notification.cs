using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Model
{
    public class Notification:BaseEntity
    {
        [Display(Name ="Mesaj")]
       public string Message { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

    }
}
