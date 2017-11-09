using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JJDev.SoftHost.Web.Models
{
    public class SoftwareViewModels
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Licence Key")]
        public string LicenseKey { get; set; }

        [Required]
        [Display(Name = "Software Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Download")]
        public string DownloadPath { get; set; }
    }
}