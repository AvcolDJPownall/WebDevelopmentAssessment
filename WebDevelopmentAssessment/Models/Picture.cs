using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDevelopmentAssessment.Models
{
    public class Picture
    {
        public int ID;
        public string ImageURL;
        public User Author;
        public ICollection<Tag> Tags { get; set; }
    }
}
