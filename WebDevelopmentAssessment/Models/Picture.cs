using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebDevelopmentAssessment.Models
{
    public class Picture
    {
        public int PictureID { get; set; }
        [StringLength(80, MinimumLength = 2)]
        public string Title { get; set; }
        [Url]
        [StringLength(128)]
        [Required]
        public string ImageURL { get; set; }
        public int UserID { get; set; }
        public int TagID { get; set; }
    }
}
