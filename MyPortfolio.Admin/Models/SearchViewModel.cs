using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPortfolio.Admin.Models
{
    public class SearchViewModel
    {
        public Guid Id { get; set; }
        [Display(Name ="Başlık")]
        public string Title { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Güncelleme Tarihi")]
        public string UpdatedAt { get; set; }
        [Display(Name = "Aktif Mi ?")]
        public bool IsActive { get; set; }
        [Display(Name = "Tür")]
        public string Type { get; set; }
    }   
}