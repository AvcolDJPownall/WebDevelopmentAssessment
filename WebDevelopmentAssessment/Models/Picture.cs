using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebDevelopmentAssessment.Models
{
    public class Picture
    {
        public int ID { get; set; }
        public string ImageURL { get; set; }
        public User Author { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
