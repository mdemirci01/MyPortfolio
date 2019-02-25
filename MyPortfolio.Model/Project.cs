using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Model
{
    public class Project:BaseEntity
    {
        [Display(Name="Proje Adı")]
        public string Name { get; set; }

        [Display(Name = "Kısa Açıklama")]
        public string ShortDescription { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }


        [Display(Name = "Fotoğraf")]
        public string Photo { get; set; }


        [Display(Name = "Proje Bitiş Tarihi")]
        public int Year { get; set; }


        [Display(Name = "Proje Github Linki")]
        public string GithubLink { get; set; }


        [Display(Name = "Kullanılan Teknoloji")]
        public Guid? TechnologyId { get; set; }

        [Display(Name = "Kullanılan Teknoloji")]
        public virtual Technology Technology { get; set; }

    }
}
