using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebDevelopmentAssessment.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        [Url]
        public string ProfilePicture { get; set; }
        [Required] [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
